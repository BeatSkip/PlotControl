using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SerialPortLib2;
using Microsoft.VisualBasic;
using Handshake = SerialPortLib2.Port.Handshake;
using Parity = SerialPortLib2.Port.Parity;
using StopBits = SerialPortLib2.Port.StopBits;

namespace PlotControl
{
    public partial class SerialControl : UserControl
    {
        private WhiteBoard mainBoard;
        private PlotControl Parent;
        private SerialPortInput SerialConnection;
        private string SerialBuffer = string.Empty;
        private StreamReader lineReader;
        public PlotterSettings currentSettings;
        private List<string> drawingBuffer;

        public bool SerialConnected = false;

        private bool safe = false;
        private bool sending = false;
        private bool Init = false;

        private SerialFlow SerialFlower;

        public string GState { get; set; }

        public SerialControl(PlotControl p,WhiteBoard b)
        {
            InitializeComponent();
            mainBoard = b;
            SerialConnection = new SerialPortInput();
            btnConnectSerial.Text = "Connect";
            cmbComPorts.DropDown += CmbComPorts_DropDown;
            SerialStatus("Idle...");
            currentSettings = new PlotterSettings();
            currentSettings.LoadDefault();
            Parent = p;
            drawingBuffer = new List<string>();
            btnDrawOnPlotter.Enabled = false;
            GState = "";
        }

        private void CmbComPorts_DropDown(object sender, EventArgs e)
        {
            LoadComPorts();
        }

        private void cmbComPorts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SerialControl_Load(object sender, EventArgs e)
        {
            //LoadComPorts();
        }

        private void LoadComPorts()
        {
            if (cmbComPorts.Items.Count > 0)
                cmbComPorts.Items.Clear();

            string[] ports = SerialPort.GetPortNames();

            //Console.WriteLine("The following serial ports were found:");

            // Display each port name to the console.
            foreach (string port in ports)
            {
                //Console.WriteLine(port);
                cmbComPorts.Items.Add(port);
            }
        }

        private void btnConnectSerial_Click(object sender, EventArgs e)
        {
            if (!SerialConnected && cmbComPorts.SelectedItem.ToString() != "")
            {
                Console.WriteLine("Attempting connection with: " + cmbComPorts.SelectedText);
                SerialStatus("Connecting! port: " + cmbComPorts.SelectedItem.ToString());
                cmbComPorts.Enabled = false;
                SerialFlower = new SerialFlow(this, cmbComPorts.SelectedItem.ToString());
                btnConnectSerial.Text = "Disconnect";
                SerialConnected = true;
                return;
            }

            if (SerialConnected)
            {
                //btnConnectSerial.Enabled = false;
                btnConnectSerial.Text = "Connect";
                SerialFlower.Disconnect();
                
                
                SerialConnected = false;

            }
        }

        private void SerialStatus(string status)
        {
            if (this.lblStatus.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(SerialStatus);
                this.Invoke(d, new object[] { status });
            }
            else
            {
                lblStatus.Text = "Status: " + status;

            }
            
        }
       

        public void PrintLine(string text)
        {
            var w = text.Trim();
            if (this.lstSerial.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(PrintLine);
                this.Invoke(d, new object[] { w });
            }
            else
            {
                this.lstSerial.Items.Add(w);
                if (lstSerial.Items.Count > 500)
                {
                    lstSerial.Items.RemoveAt(0);
                }

                lstSerial.SelectedIndex = lstSerial.Items.Count - 1;

            }
            
        }

        delegate void StringArgReturningVoidDelegate(string text);

        public PlotterSettings getSettings()
        {
            return currentSettings;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SerialFlower.writeDirect("$H");
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SerialFlower.writeDirect("$X");
        }

 

        private async void btnParseBoardForPlotter_Click(object sender, EventArgs e)
        {
            Parent.lblStatusBtmLeft.Text = "Starting G-code Export Parse!";
            /*
            var exportFile = new BoardExporter(mainBoard, "Workfile.nc", 4000.0f, 2500.0f, 119);
            drawingBuffer = exportFile.getLines();
            btnDrawOnPlotter.Enabled = true;
            Clipboard.SetText(listToStringLines(drawingBuffer));
            */
            string smove = "6000.0";
            string sdraw = "4500.0";
            string spen = "119";
            var h = Util.ShowInputDialog("Verplaatsings snelheid",ref smove);
            var i = Util.ShowInputDialog("Teken snelheid",ref sdraw);
            var j = Util.ShowInputDialog("Pen hoogte",ref spen);

            float move = 0;
            float draw = 0;
            int pen = 0;

            if (h == DialogResult.OK && i == DialogResult.OK && j == DialogResult.OK )
            {
                 move = float.Parse(smove);
                draw = float.Parse(sdraw);
                pen = int.Parse(spen);
                await DoWork(mainBoard, "Workfile.nc", move, draw, pen);
            }

            
            


        }

        private string listToStringLines(List<string> d)
        {
            string data = "";
            foreach (var v in d)
            {
                data += v + "\n";
            }

            return data;
        }

        private void btnDrawOnPlotter_Click(object sender, EventArgs e)
        {
            SerialFlower.StartDrawing(drawingBuffer);

        }

        private void btnStopDrawing_Click(object sender, EventArgs e)
        {
            SerialFlower.EStop();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
           SerialFlower.PauseToggle();
        }

        private List<string> ParseExport(WhiteBoard w, string workfile, float moveSpeed,float drawSpeed,int downVal)
        {
            var exportFile = new BoardExporter(mainBoard, "Workfile.nc", 4000.0f, 2500.0f, 119);
            var drawingbuffer = exportFile.getLines();
            

            return drawingbuffer;
        }

        public async Task DoWork(WhiteBoard w, string workfile, float moveSpeed, float drawSpeed, int downVal)
        {
            Func<List<string>> function = new Func<List<string>>(() => ParseExport(w, workfile, moveSpeed, drawSpeed, downVal));
            var res = await Task.Factory.StartNew<List<string>>(function);
            drawingBuffer = res;

            if (res != null)
            {
                Clipboard.SetText(listToStringLines(drawingBuffer));
                btnDrawOnPlotter.Enabled = true;
                Parent.lblStatusBtmLeft.Text = "Done Parsing G-code for Export!";
            }
         
           
            
        }
    }
}

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SkiaSharp.Views.Desktop;
using SkiaSharp;
using SkiaSharp.Extended;
using SkiaSharp.Extended.Svg;
using OpenTK;
using Sgv = SkiaSharp.Extended.Svg.SKSvg;

namespace PlotControl
{
    public partial class MainForm : Form
    {
        private WhiteBoard mainBoard;
        private List<GCodeFile> gFiles;
        private TabPage drawingTab;
        private SerialControl serialConControl;
        private string defaultFolder = @"C:\Users\Administrator\Documents\Gcode";

        private PlotterSettings MachineSettings;

        public ListBox lstDraw { get; set; }
        public ToolStripStatusLabel lblStatusBtmLeft { get; set; }

        public MainForm()
        {
            InitializeComponent();
            mainBoard = new WhiteBoard(this,1000, 700, skControl1, RatioLabel, MouseLabel);
            //ParseTest();
            gFiles = new List<GCodeFile>();

            btnLeft.Click += TranslationButton_clicked;
            btnRight.Click += TranslationButton_clicked;
            btnUp.Click += TranslationButton_clicked;
            btnDown.Click += TranslationButton_clicked;
            btnRotRight.Click += TranslationButton_clicked;
            btnRotLeft.Click += TranslationButton_clicked;
            btnScaleN.Click += TranslationButton_clicked;
            btnScaleP.Click += TranslationButton_clicked;
            serialConControl = new SerialControl(this, mainBoard);
            this.panelSerial.Controls.Add(serialConControl);
            serialConControl.Dock = DockStyle.Fill;
            lstDraw = lstDrawings;
            lblStatusBtmLeft = lblStatusMain;
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            MachineSettings = new PlotterSettings();
            MachineSettings.LoadDefault();

            lstSettings.View = View.Details;
            lstSettings.Columns.Add("Setting");
            lstSettings.Columns.Add("Value");
            tabMachSettings.Enter += TabMachSettingsOnEnter;
            refreshSettings();

        }

        private void TabMachSettingsOnEnter(object sender, EventArgs eventArgs)
        {
            refreshSettings();
        }

        private void refreshSettings()
        {
            if (lstSettings.Items.Count > 0)
            {
                lstSettings.Items.Clear();
            }

            var w = serialConControl.getSettings();


            foreach (var set in w.Settings)
            {
                string value ="";
                if (set.Value.ValueType == typeof(int))
                {
                    value = ((int) set.Value.Value).ToString();
                }

                if (set.Value.ValueType == typeof(bool))
                {
                    value = ((bool)set.Value.Value).ToString();
                }

                if (set.Value.ValueType == typeof(float))
                {
                    float v = (float) set.Value.Value;
                    value = v.ToString("0.##");
                }
                lstSettings.Items.Add(new ListViewItem(new string[] { set.Value.Title, value }));
            }
            
        }

        private void UpdateCodeList()
        {
            if (lstDrawings.Items.Count > 0)
            {
                lstDrawings.Items.Clear();
            }
            foreach (var drawing in mainBoard.AllDrawings)
            {
                lstDrawings.Items.Add(drawing.Name);
            }
            lblStatusMain.Text = "Idle..";
        }




        private async void btnLoadNew_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Gcode File";
            theDialog.InitialDirectory = defaultFolder;
            
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = theDialog.FileName;


                //var res = await Task.FromResult<GcodeDrawing>(importDrawing(filename, theDialog.SafeFileName));

                //var newGcode = new GcodeDrawing(filename, theDialog.SafeFileName);
                //mainBoard.AllDrawings.Add(res);
                lblStatusMain.Text = "Loading gcode..";
                await DoWork(filename, theDialog.SafeFileName);



            }

            //UpdateCodeList();
        }

        public async Task DoWork(string file, string fileName)
        {
            Func<GcodeDrawing> function = new Func<GcodeDrawing>(() => importDrawing(file, fileName));
            var res = await Task.Factory.StartNew<GcodeDrawing>(function);
            mainBoard.AllDrawings.Add(res);
            //var w = new PreviewCodeDialog(res);
            //w.Show();
            lblStatusMain.Text = "Done!";
            UpdateCodeList();
        }


        private GcodeDrawing importDrawing(string file, string fileName)
        {
            return new GcodeDrawing(file, fileName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lstDrawings.SelectedIndex >= 0)
            {
                mainBoard.DrawDrawing(lstDrawings.SelectedIndex);

            }

        }


        private void lstDrawings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDrawings.SelectedIndex >= 0)
            {
                lblZeroPoint.Text = "Offset: " + mainBoard.AllDrawings[lstDrawings.SelectedIndex].zeroPoint.X + ", " +
                                    mainBoard.AllDrawings[lstDrawings.SelectedIndex].zeroPoint.X + " mm";
                lblRotation.Text = "Rotation: " + mainBoard.AllDrawings[lstDrawings.SelectedIndex].RotationDeg +
                                   " degrees";
                //TabMain.TabPages.Insert(1,drawingTab);
                //drawingTab.Text = mainBoard.AllDrawings[lstDrawings.SelectedIndex].Name;
                
                
            }else
            if (lstDrawings.SelectedIndex == -1)
            {
                //drawingTab = TabMain.TabPages[1];
                //TabMain.TabPages.RemoveAt(1);
            }

            SelectedIndexLabel.Text = "SelectedIndex = " + lstDrawings.SelectedIndex;
        }

        private void TranslationButton_clicked(object sender, EventArgs e)
        {
            string s = (sender as Button).Text;
            if (lstDrawings.SelectedIndex >= 0)
            {
                var drawing = mainBoard.AllDrawings[lstDrawings.SelectedIndex];
                switch (s)
                {
                    case ("Up"):
                        drawing.move(0,float.Parse(txtMoveStep.Text));
                        break;
                    case ("<"):
                        drawing.move(float.Parse(txtMoveStep.Text), 0);
                        break;
                    case (">"):
                        drawing.move(-1 * float.Parse(txtMoveStep.Text), 0);
                        break;
                    case ("Down"):
                        drawing.move(0,-1* float.Parse(txtMoveStep.Text));
                        break;
                    case ("Rotate Right"):
                        drawing.RotateStep(-1 * float.Parse(txtDegStep.Text));
                        break;
                    case ("Rotate Left"):                   
                        drawing.RotateStep(float.Parse(txtDegStep.Text));
                        break;
                    case ("Scale +"):
                        drawing.ScaleStep(0.1f);
                        break;
                    case ("Scale -"):
                        drawing.ScaleStep(-0.1f);
                        break;
                }
                skControl1.Refresh();
                
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstDrawings.SelectedIndex >= 0)
            {
                if (mainBoard.AllDrawings.Count > lstDrawings.SelectedIndex)
                {
                    
                    mainBoard.AllDrawings.RemoveAt(lstDrawings.SelectedIndex);
                    lstDrawings.Items.RemoveAt(lstDrawings.SelectedIndex);
                    skControl1.Refresh();
                }
            }
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (txtFile.Text != "")
            {
                var exportFile = new BoardExporter(mainBoard, txtFile.Text, 4000.0f, 2500.0f, 119);

                
            }
        }

        private void btnDrawOnPlotter_Click(object sender, EventArgs e)
        {

        }
    }
}

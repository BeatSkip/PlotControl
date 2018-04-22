using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerialPortLib2;
using SerialPortLib2.Port;

namespace PlotControl
{
    public class SerialFlow
    {
        private SerialPortInput SerialConnection;
        private SerialControl Parent;

        private List<string> sendBuffer;

        private int SendCounter = 0;
        private int AckCounter = -1;

        private string SerialBuffer = String.Empty;
        private string lastCommand = String.Empty;
        public bool IsConnected { get; set; }
        public bool IsInitiated { get; set; }
        public bool IsPaused { get; set; }
        public bool logging = true;

        public SerialFlow(SerialControl parent,string port)
        {
            Parent = parent;
            sendBuffer = new List<string>();
            Console.WriteLine("STARTED SERIAL! Port: " + port);
            SerialConnection = new SerialPortInput(port, 115200, Parity.None, 8, StopBits.One, Handshake.None,false);
            SerialConnection.ConnectionStatusChanged += Handler_SerialStatus;
            SerialConnection.MessageReceived += Handler_SerialMessage;

            SerialConnection.Connect();
            IsConnected = false;
            IsInitiated = false;
            IsPaused = false;
        }

        public void PauseToggle()
        {
            if (IsPaused)
            {
                IsPaused = false;
                NextBuffer();
            }
            else
            {
                IsPaused = true;
            }
        }

        public void EStop()
        {
            if (sendBuffer.Count > 0)
            {
                sendBuffer.Clear();
            }
            SendCounter = 0;
            AckCounter = 0;
            
            sendBuffer.Add("M3S0");
            IsPaused = false;
            NextBuffer();
        }

        private void Handler_SerialMessage(object sender, MessageReceivedEventArgs args)
        {
            SerialBuffer += Encoding.ASCII.GetString(args.Data);
            Console.Write(SerialBuffer);
            if (SerialBuffer.Contains('\n'))
            {
                var w = SerialBuffer.Split('\n');
                foreach (var v in w)
                {
                    if (v != "")
                    {
                        ParseLine(v.Trim());

                    }
                }
                SerialBuffer = String.Empty;
            }
        }

        private void Handler_SerialStatus(object sender, ConnectionStatusChangedEventArgs args)
        {
            this.IsConnected = args.Connected;
        }

        private void ParseLine(string line)
        {
            Parent.PrintLine(line);
            if (line == "ok" && IsInitiated)
            {
                AckCounter++;
                NextBuffer();
                //Console.WriteLine(" 4. Done and ready!");
            }

            if (line.Contains("[GC:"))
            {
                Parent.GState = line;
                Console.WriteLine(line);
            }

            if (line == "ok" && !IsInitiated && AckCounter == 0)
            {
                sendBuffer.Add("$G");
                SendCounter++;

                IsInitiated = true;
                //Console.WriteLine(" 3. Done homing!");
            }

            if (line == "ok" && !IsInitiated && AckCounter == -1)
            {
                writeDirect("$H");
                AckCounter++;
                Console.WriteLine(" 2. Homing starting");
            }

           

            if (line.Contains("[MSG:'$H'|'$X' to unlock]") && lastCommand.Contains("Grbl 1.1f ['$' for help]"))
            {
                writeDirect("M3 S0");
                writeDirect("$$");
                
                Console.WriteLine(" 1. Inititation starting");
            }
            

            if (line.Contains('$') && line.Contains('='))
            {
                Parent.currentSettings.ParseSetting(line);
            }

            lastCommand = line;
        }

        private void NextBuffer()
        {
            
            while (AckCounter > SendCounter - 2 && sendBuffer.Count > 0 && !IsPaused)
            {
                if (logging)
                {
                    Console.WriteLine("SendCounter: " + SendCounter + " | AckCounter: " + AckCounter + " buffercnt: " + sendBuffer.Count);
                }
                writeDirect(sendBuffer[0]);

                if(logging)
                    Console.WriteLine(sendBuffer[0]);

                SendCounter++;
                sendBuffer.RemoveAt(0);
            }
        }

        public void StartDrawing(List<string> drawing)
        {
            sendBuffer.AddRange(drawing);
            NextBuffer();

        }

        public void Disconnect()
        {
            if (SerialConnection.IsConnected)
            {
                SerialConnection.Disconnect();
            }
        }

        public void writeDirect(string data)
        {
            if (SerialConnection.IsConnected)
            {
                // This text is always added, making the file longer over time
                // if it is not deleted.
                if (logging)
                {
                    Log(data);
                    
                }
                
                SerialConnection.SendMessage(Encoding.ASCII.GetBytes(data + '\r'));
            }
        }

        public void WriteBuffered(string data)
        {
            sendBuffer.Add(data);
            NextBuffer();
        }

        private void Log(string text)
        {
            using (StreamWriter sw = File.AppendText("LogFile.txt"))
            {
                sw.WriteLine(text);

            }
        }
    }
}

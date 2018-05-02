using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using SkiaSharp;

namespace PlotControl
{
    public static class Util
    {
        public static Dictionary<char, object> ExecuteLine(string line)
        {
            Regex Gcode = new Regex("[ngxyzfijrpsm][+-]?[0-9]*\\.?[0-9]*", RegexOptions.IgnoreCase);
            MatchCollection m = Gcode.Matches(line);
            Dictionary<char, object> result = new Dictionary<char, object>();

            foreach (var Parameter in m)
            {
                char param = Parameter.ToString().ToUpper()[0];

                switch (param)
                {
                    case ('G'): //Command codes
                    case ('M'):
                    case ('S'): //Integer parameters
                        result.Add(param, (int) int.Parse(Parameter.ToString().Substring(1)));
                        //Console.WriteLine("Matched: " + Parameter.ToString() + " | " + param + " " +
                        //                 int.Parse(Parameter.ToString().Substring(1)));
                        break;
                    case ('P'): //Float parameters
                    case ('X'):
                    case ('Y'):
                    case ('I'):
                    case ('J'):
                    case ('R'):
                    case ('F'):
                        result.Add(param, (float) float.Parse(Parameter.ToString().Substring(1)));
                        //Console.WriteLine("Matched: " + Parameter.ToString() + " | " + param + " " +
                        //                  float.Parse(Parameter.ToString().Substring(1)));
                        break;
                }
            }

            return result;
        }

        public static SKPoint getXY(string command)
        {
            Regex Gcode = new Regex("[xy][+-]?[0-9]*\\.?[0-9]*", RegexOptions.IgnoreCase);
            MatchCollection m = Gcode.Matches(command);
            float x = 0;
            float y = 0;

            foreach (var Parameter in m)
            {
                char param = Parameter.ToString().ToUpper()[0];

                switch (param)
                {
                   
                    case ('X'):
                        x = (float)float.Parse(Parameter.ToString().Substring(1));
                       
                        break;
                    case ('Y'):
                        y = (float)float.Parse(Parameter.ToString().Substring(1));
                        
                        break;
                }
            }

            return new SKPoint(x, y);
        }

        public static int ClassifyCommand(GCodeCommand input)
        {
            /*
             *CLASSIFICATIONS:
             *   Motion Commands
             *    0 - Feed rate        [G1 Fxxxx]
             *    1 - Rapid Move       [G0 X0 Y0]
             *    2 - Linear Move      [G1 X10 Y10]
             *    3 - Arc Move IJ      [G2 X303.6584 Y78.2006 I-140.515 J-2.321]
             *    4 - Arc Move R
             *
             *   Machine
             *    10 - Delay
             *    11 - Pen Up
             *    12 - Pen Down
             *
             *   Coordinate
             *    20 - Absolute Programming [G90]
             *    21 - Incremental Programmming [G91]
             *
             *
             */

            if (input.getParameters().ContainsKey('G'))
            {
                switch ((int) input.getParameters()['G'])
                {
                    case (0): //G0
                        return 1;
                        break;
                    case (1): //G1
                        return ClassifyLine(input);
                        break;
                    case (2): //G2 and G3
                    case (3):
                        return ClassifyArc(input);
                        break;
                    case (4): //G4
                        return 10;
                        break;
                }
            }
            else if (input.getParameters().ContainsKey('M'))
            {
                switch ((int) input.getParameters()['M'])
                {
                    case (3):
                        if ((int) input.getParameters()['S'] == 0) //Pen UP
                        {
                            return 11;
                        }
                        else
                        {
                            return 12;
                        }

                        break;

                    case (4): //G4
                        return 10;
                        break;
                }
            }
            else
            {
                return -1;
            }

            return -1;
        }


        public static int ClassifyArc(GCodeCommand input)
        {
            if (input.getParameters().ContainsKey('R'))
            {
                return 4;
            }
            else
            {
                return 3;
            }
        }

        public static int ClassifyLine(GCodeCommand input)
        {
            if (input.getParameters().ContainsKey('F'))
            {
                return 0;
            }
            else
            {
                return 2;
            }
        }

        public static DialogResult ShowInputDialog(string title, ref string input)
        {
            System.Drawing.Size size = new System.Drawing.Size(200, 70);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = title;

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 5);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;
            inputBox.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            return result;
        }
    }
}
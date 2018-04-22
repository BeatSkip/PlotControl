using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using SkiaSharp;

namespace GcodeParse
{
    public class GcodeDrawing
    {
        public string Name { get; set; }
        public bool isDrawn { get; set; }
        public Dictionary<int, GcodeDrawCommand> DrawCommands;
        public Dictionary<int, string> CodeCommands;
        public SKPoint zeroPoint { get; set; }

        public float ScaleFactor { get; set; }
        public float RotationDeg { get; set; }

        private float maxX { get; set; }
        private float maxY { get; set; }
        private float minX { get; set; }
        private float minY { get; set; }

        public GcodeDrawing(string FileName, string name)
        {
            DrawCommands = new Dictionary<int, GcodeDrawCommand>();
            CodeCommands = new Dictionary<int, string>();
            LoadFile(FileName);
            Name = name;
            isDrawn = false;
            ScaleFactor = 1;
            RotationDeg = 0;

            maxX = 0;
            maxY = 0;
            minX = 0;
            minY = 0;
        }

        public void ScaleStep(float sc)
        {
            ScaleFactor += sc;
            if (ScaleFactor < 0.01f)
            {
                ScaleFactor = 0.01f;
            }
        }

        public void RotateStep(float deg)
        {
            RotationDeg += deg;
        }

        public void move(float x, float y)
        {
            zeroPoint = new SKPoint(zeroPoint.X + x, zeroPoint.Y + y);
        }

        public void Draw(WhiteBoard w, SKCanvas h, SKPaint lines, SKPaint moves)
        {
            Parallel.ForEach(DrawCommands, (command) =>
            {

                //command.Value.Draw(w, h, zeroPoint, lines, moves, ScaleFactor, RotationDeg);
                var r = (GcodeDrawCommand) command.Value;

                if (r.DrawType == typeof(GcodeArc))
                {
                    var q = (GcodeArc) command.Value;
                    var i = q.getArc(zeroPoint, ScaleFactor, RotationDeg);
                    SKPaint p;
                    if (q.PenDown)
                    {
                        p = lines;
                    }
                    else
                    {
                        p = moves;
                    }
                    //h.DrawPath(Transformations.CreateArc(i,w),p);
                    h.DrawLine(w.BoardToCanvas(i.Start), w.BoardToCanvas(i.End), p);
                    //TODO: Teken daadwerkelijk een arc!!
                }
                else if (r.DrawType == typeof(GcodeLine))
                {
                    var q = (GcodeLine) command.Value;
                    var i = q.getLine(zeroPoint, ScaleFactor, RotationDeg);
                    SKPaint p;
                    if (q.PenDown)
                    {
                        p = lines;
                    }
                    else
                    {
                        p = moves;
                    }

                    h.DrawLine(w.BoardToCanvas(i.Start), w.BoardToCanvas(i.End), p);
                    //Console.WriteLine("Draw Line!");
                    
                }
                else
                {
                    Console.WriteLine("Not Line or arc!");

                }
            });
        }

        private void LoadFile(string file)
        {
            bool penDown = false;
            string[] Glines = System.IO.File.ReadAllLines(file);
            int counter = 0;

            foreach (var v in Glines)
            {
                CodeCommands.Add(counter, v);
                counter++;
            }

            ParseCommands();
        }

        private void ParseCommands()
        {
            bool penDown = false;

            SKPoint last = new SKPoint(0, 0);
           
            foreach (var v in CodeCommands)
            {
                if (v.Value.Length != 0)
                {
                    var codeCommand = new GCodeCommand(v.Value, v.Key);
                    int classif = Util.ClassifyCommand(codeCommand);


                    switch (classif)
                    {
                        case (-1):
                            Console.WriteLine("UNKOWN! :" + v.Value);
                            break;
                        case (0):
                            //FeedRate = (int)codeCommand.getParameters()['F'];
                            break;
                        case (1):
                        case (2):
                        case (4)://TODO REDO R-ARC classification
                            //Line
                            //Console.WriteLine("Line! :" + v.Value);
                            DrawCommands.Add(v.Key, new GcodeLine(codeCommand, penDown, last));
                            last = new SKPoint((float) codeCommand.getParameters()['X'],
                                (float) codeCommand.getParameters()['Y']);

                           
                            break;
                        case (3):
                            //ARC
                            //Console.WriteLine("Arc! :" + v.Value);
                            DrawCommands.Add(v.Key, new GcodeArc(codeCommand, penDown, last, classif));
                            last = new SKPoint((float)codeCommand.getParameters()['X'],
                                (float)codeCommand.getParameters()['Y']);
                            break;
                        case (11):
                            penDown = false;
                            //Console.WriteLine("Pen Up! :" + v.Value);

                            break;
                        case (12):
                            penDown = true;
                            //Console.WriteLine("Pen Down! :" + v.Value);
                            break;


                    }
                }
            }

        }

        public List<string> getGCodes(float moveSpeed, float drawSpeed, int PDown)
        {
            List<string> commands = new List<string>();
            bool pendown = false;

            foreach (var command in DrawCommands)
            {
                
                if (pendown == false && command.Value.PenDown == true)
                {
                    commands.Add("G1 F" + moveSpeed);
                    commands.Add(command.Value.getStartGcode(zeroPoint, ScaleFactor, RotationDeg));//EDITED
                    commands.Add("G1 F" + drawSpeed);
                    commands.Add("M3 S" + PDown);
                    commands.Add("G4 P0.4");


                    pendown = true;
                }
                if (pendown == true && command.Value.PenDown == false)
                {
                    commands.Add("G1 F" + moveSpeed);
                    commands.Add("M3 S0");
                    commands.Add("G4 P0.4");
                    pendown = false;
                }


                commands.Add(command.Value.getGcode(zeroPoint, ScaleFactor, RotationDeg));

               
            }

            commands.Add("G1 F" + moveSpeed);
            commands.Add("M3 S0");

            return commands;
        }

        public float[] getBounds()
        {
            Console.WriteLine("minX: " + minX + "minY: " + minY + "maxX: " + maxX + "maxY: " + maxY);
            return new float[] { minX, minY, maxX, maxY};
        }



        
    }



    public abstract class GcodeDrawCommand
    {
        public int Index { get; set; }
        public GCodeCommand OriginalCommand { get; set; }
        public bool PenDown { get; set; }
        public SKPoint Start { get; set; }
        public SKPoint End { get; set; }
        public Type DrawType { get; set; }

        public GcodeDrawCommand()
        {
        }

        public virtual void Draw(SKPaint move, float scale, float rot)
        {

        }

        public virtual string getGcode(SKPoint move, float scale, float rot)
        {
            return "";
        }

        public virtual string getStartGcode(SKPoint move, float scale, float rot)
        {
            return "";
        }

    }

    public class GcodeLine : GcodeDrawCommand
    {

        public GcodeLine()
        {
        }


        public GcodeLine(GCodeCommand command, bool drawn, SKPoint start)
        {
            
            this.OriginalCommand = command;
            this.PenDown = drawn;
           
            Start = start;
            End = new SKPoint((float)command.getParameters()['X'], (float)command.getParameters()['Y']);
            DrawType = typeof(GcodeLine);

        }

        public override void Draw(SKPaint move, float scale, float rot)
        {
            
        }

        public LineSegment getLine(SKPoint move, float scale, float rot)
        {
            return new LineSegment(Transformations.GetTransformed(Start,move,scale,rot), Transformations.GetTransformed(End, move, scale, rot));
        }

        public LineSegment getLineOrig()
        {
            return new LineSegment(Start,End);
        }

        public override string getGcode(SKPoint move, float scale, float rot)
        {
            var line = this.getLine(move, scale, rot);
            
            return "G1 X" + line.End.X + " Y" + line.End.Y;
        }

        public override string getStartGcode(SKPoint move, float scale, float rot)
        {
            var line = this.getLine(move, scale, rot);

            return "G1 X" + line.Start.X + " Y" + line.Start.Y;
        }
    }

    public class GcodeArc : GcodeDrawCommand
    {
        public bool ClockWise { get; }
        public SKPoint Center { get; set; }
        public SKPoint CenterAbs { get; set; }

        public GcodeArc()
        {
        }

        public GcodeArc(GCodeCommand command, bool drawn, SKPoint start, int classification)
        {

            this.OriginalCommand = command;
            this.PenDown = drawn;


            /*
            Regex Gcode = new Regex("[ngxyzfijrps][+-]?[0-9]*\\.?[0-9]*", RegexOptions.IgnoreCase);
            MatchCollection m = Gcode.Matches(command);

            float x = 0;
            float y = 0;
            float i = 0;
            float j = 0;
            float r = float.NaN;

            foreach (var Parameter in m)
            {
                char param = Parameter.ToString().ToUpper()[0];

                switch (param)
                {
                    case ('X'):
                        x = float.Parse(Parameter.ToString().Substring(1));
                        break;
                    case ('Y'):
                        y = float.Parse(Parameter.ToString().Substring(1));
                        break;
                    case ('I'):
                        i = float.Parse(Parameter.ToString().Substring(1));
                        break;
                    case ('J'):
                        j = float.Parse(Parameter.ToString().Substring(1));
                        break;
                    case ('R'):
                        r = float.Parse(Parameter.ToString().Substring(1));
                        break;
                }
            }
            */


            End = new SKPoint((float) command.getParameters()['X'], (float) command.getParameters()['Y']);


            Start = start;
            //End = new SKPoint(x, y);
            //TODO: Arc Centerpoint control

            if (classification == 3)
            {
                Center = new SKPoint((float) command.getParameters()['I'], (float) command.getParameters()['J']);
                CenterAbs = new SKPoint(Start.X + Center.X, Start.Y + Center.Y);
            }
            else
            {
                //TODO: R arc classification calculations
            }

            if ((int) command.getParameters()['G'] == 2)
            {
                ClockWise = true;
            }
            else
            {
                ClockWise = false;
            }
            
            DrawType = typeof(GcodeArc);
        }
        

        public override void Draw(SKPaint moves, float scale, float rot)
        {
            
            
        }

        public ArcSegment getArc(SKPoint move, float scale, float rot)
        {
            return new ArcSegment(Transformations.GetTransformed(Start, move, scale, rot), Transformations.GetTransformed(End, move, scale, rot), Transformations.GetTransformed(CenterAbs, move, scale, rot),ClockWise);
        }

        public ArcSegment getArcOrig()
        {
                return new ArcSegment(Start,End,CenterAbs, ClockWise);
        }

        public override string getGcode(SKPoint move, float scale, float rot)
        {
            var c = this.getArc(move, scale, rot);

            var x = c.End.X;
            var y = c.End.Y;
            var i = c.Center.X - c.Start.X;
            var j = c.Center.Y - c.Start.Y;

            
            string result = "";

            if (ClockWise)
            {
                result += "G2 ";
            }
            else
            {
                result += "G3 ";
            }

            result += "X" + x + " Y" + y + " I" + i + " J" + j;
            
            return result;
            

            //return "G1 X" + c.End.X + " Y" + c.End.Y;
        }

        public override string getStartGcode(SKPoint move, float scale, float rot)
        {
            var c = this.getArc(move, scale, rot);
            /*
            var x = c.End.X;
            var y = c.End.Y;
            var i = c.Center.X - c.Start.X;
            var j = c.Center.Y - c.Start.Y;

            string result = "";

            if (ClockWise)
            {
                result += "G2 ";
            }
            else
            {
                result += "G2 ";
            }

            //result += "X" + x + " Y" + y + " I" + i + " J" + j;
            */
            return "G1 X" + c.Start.X + " Y" + c.Start.Y;
            //return result;
        }

    }

    public class LineSegment
    {
        public SKPoint Start { get; set; }
        public SKPoint End { get; set; }
        public LineSegment(SKPoint start, SKPoint end)
        {
            Start = start;
            End = end;
        }
    }

    public class ArcSegment
    {
        public SKPoint Start { get; set; }
        public SKPoint End { get; set; }
        public SKPoint Center { get; set; }
        public bool CW { get; set; }

        public ArcSegment(SKPoint start, SKPoint end, SKPoint center, bool cwV)
        {
            Start = start;
            End = end;
            Center = center;
            CW = cwV;
        }
    }
}

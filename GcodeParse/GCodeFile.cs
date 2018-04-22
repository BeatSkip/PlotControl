using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SkiaSharp;

namespace GcodeParse
{
    public class GCodeFile
    {
        private Dictionary<int, string> fileLines;
        private Dictionary<int, GCodeCommand> CodeLines;

        private Dictionary<int, DrawSegment> OriginalSegments;
        private Dictionary<int, DrawSegment> ResultSegments;

        public float RotationDegrees { get; set; }
        public float ScaleFactor { get; set; }
        public SKPoint Transformation { get; set; }

        public GCodeFile(string file)
        {
            fileLines = new Dictionary<int, string>();
            CodeLines = new Dictionary<int, GCodeCommand>();
            OriginalSegments = new Dictionary<int, DrawSegment>();
            ResultSegments = new Dictionary<int, DrawSegment>();

            LoadFile(file);
        }

        private void LoadFile(string file)
        {
            string[] Glines = System.IO.File.ReadAllLines(file);
            int counter = 0;

            foreach (var v in Glines)
            {
                if (v != "")
                {
                    fileLines.Add(counter, v);
                    counter++;
                }           
            }

            foreach (var Entry in fileLines)
            {
                var command = new GCodeCommand(Entry.Value,Entry.Key);
                CodeLines.Add(Entry.Key,command);
            }

            DrawSegment lastSegment = null;
            bool PDown = false;
            float FeedRate = 0;

            for (int i = 0; i < CodeLines.Count; i++)
            {
                int classif = Util.ClassifyCommand(CodeLines[i]);

                switch (classif)
                {
                    case (0):
                        FeedRate = (int) CodeLines[i].getParameters()['F'];
                        break;
                    case (1):
                    case (2):
                        SegmentLine d = new SegmentLine(CodeLines[i], PDown, FeedRate,lastSegment);
                        lastSegment = d;
                        OriginalSegments.Add(d.Index,d);
                        break;
                    case (3):
                    case (4):
                        SegmentArc a = new SegmentArc(CodeLines[i], PDown, FeedRate, lastSegment);
                        lastSegment = a;
                        OriginalSegments.Add(a.Index, a);
                        break;
                    case (11):
                        PDown = false;
                        break;
                    case (12):
                        PDown = true;
                        break;


                }
                
            }
        }

        private void Mutate()
        {
            
        }





        
    }
}

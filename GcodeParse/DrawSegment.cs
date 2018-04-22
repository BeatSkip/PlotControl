using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;

namespace GcodeParse
{
    public abstract class DrawSegment
    {
        public int Index { get; set; }
        public GCodeCommand Command { get; set; }
        public bool PenDown { get; set; }
        public float FeedRate { get; set; }

        public SKPoint Start { get; set; }
        public SKPoint End { get; set; }

        public DrawSegment()
        {

        }
    }

    public class SegmentLine : DrawSegment
    {
        public SegmentLine() { }

        public SegmentLine(GCodeCommand command,bool pen,float feed, DrawSegment Previous = null)
        {
            if (Previous == null)
            {
                End = new SKPoint(0.0f, 0.0f);
            }
            else
            {
                Start = Previous.End;
            }
           
            End = command.getEndPoint();
            Command = command;
            Index = command.getIndex();
            PenDown = pen;
            FeedRate = feed;
        }
    }

    public class SegmentArc : DrawSegment
    {
        public SKPoint Center { get; set; }
        
        public SegmentArc()
        {
        }

        public SegmentArc(GCodeCommand command, bool pen, float feed, DrawSegment Previous = null)
        {
            if (Previous == null)
            {
                End = new SKPoint(0.0f, 0.0f);
            }
            else
            {
                Start = Previous.End;
            }

            End = command.getEndPoint();
            Command = command;
            Index = command.getIndex();
            PenDown = pen;
            FeedRate = feed;
            Center = command.getCenterPoint(this.Start);


        }

        public SKPoint getAbsCenter()
        {
            return new SKPoint(Start.X + Center.X, Start.Y + Center.Y);
        }
    }
}

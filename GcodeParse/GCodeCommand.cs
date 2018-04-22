using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SkiaSharp;

namespace PlotControl
{
    public class GCodeCommand
    {
        private string Command { get; set; }
        private int LineNr { get; set; }
        private Dictionary<char, object> Parameters;

        public GCodeCommand(string line, int nr)
        {
            Command = line;
            LineNr = nr;
            Parameters = Util.ExecuteLine(line);
        }

        public SKPoint getEndPoint()
        {
            if (Parameters.ContainsKey('X') && Parameters.ContainsKey('Y'))
            {
                return new SKPoint((float)Parameters['X'], (float)Parameters['Y']);
            }
            else
            {
                return new SKPoint(float.NaN, float.NaN);
            }
        }

        public SKPoint getCenterPoint(SKPoint prev)
        {
            if (Parameters.ContainsKey('I') && Parameters.ContainsKey('J'))
            {
                return new SKPoint((float)Parameters['I'], (float)Parameters['J']);
            }
            else if(Parameters.ContainsKey('R'))
            {
                SKPoint a = new SKPoint();
                SKPoint b = new SKPoint();
                var W = Transformations.FindCircleCircleIntersections(prev, this.getEndPoint(), (float) Parameters['R'],
                    out a, out b);
                if ((float) Parameters['R'] < 0)
                {
                    return a;
                }
                else
                {
                    return b;
                }
            }
            else
            {
                return new SKPoint(float.NaN, float.NaN);
            }
        }


        public int getIndex()
        {
            return LineNr;
        }

        public Dictionary<char, object> getParameters()
        {
            return Parameters;
        }

        public KeyValuePair<char, object> getParameter(char c, Type t)
        {
            if (Parameters.ContainsKey(c.ToString().ToUpper()[0]))
            {
                return new KeyValuePair<char, object>(c,Parameters[c.ToString().ToUpper()[0]]);
            }

            return new KeyValuePair<char,object>(c,new object());
        }


        public void setParameter(KeyValuePair<char,object> Parameter)
        {
            if (Parameters.ContainsKey(Parameter.Key))
            {
                Parameters[Parameter.Key] = Parameter.Value;
            }
        }
    }
}

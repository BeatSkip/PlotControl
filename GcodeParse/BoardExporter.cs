using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotControl
{
    public class BoardExporter
    {
        private WhiteBoard board;
        private string exportFile;
        private float MoveSpeed;
        private float DrawSpeed;
        private int PenDownVal;
        private List<string> lines;


        public BoardExporter(WhiteBoard w, string filename, float moveSpeed, float drawSpeed, int PDown)
        {
            board = w;
            exportFile = filename;
            
            MoveSpeed = moveSpeed;
            DrawSpeed = drawSpeed;
            PenDownVal = PDown;
            Parse();
            //Save();
        }

        public void Parse()
        {
            lines = new List<string>();
            bool penIsDown = false;

            lines.Add("G90");
            lines.Add("G21");
            lines.Add("G53");
            lines.Add("M3 S0");           
            lines.Add("G1 F" + MoveSpeed);


            foreach (var Drawing in board.AllDrawings)
            {
                if (Drawing.isDrawn)
                {
                    var list = Drawing.getGCodes(MoveSpeed, DrawSpeed, PenDownVal);
                    lines.AddRange(list);
                    lines.Add("M3 S0");
                    lines.Add("G1 F" + MoveSpeed);
                }
                
            }
            lines.Add("M3 S0");
            lines.Add("$H");
        }

        public List<string> getLines()
        {
            Parse();
            return lines;

        }

        public void Save()
        {
            
            if (!exportFile.Contains('.'))
            {
                exportFile += ".nc";
            }
            System.IO.File.WriteAllLines(exportFile, lines);
        }




    }
}

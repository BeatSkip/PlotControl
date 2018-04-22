using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using SkiaSharp;
using SkiaSharp.Views.Desktop;

namespace GcodeParse
{
    public class WhiteBoard
    {
        private PlotControl Parent;
        public SKControl mainControl;
        public SKSize BoardSize;
        public SKSize CanvasSize;
        public SKPoint BottomRight;
        public float Scale;

        public ToolStripStatusLabel StatusLabel;
        public ToolStripStatusLabel MouseLabel;

        public List<GcodeDrawing> AllDrawings { get; set; }
        public List<GCodeFile> AllFiles { get; set; }

        public SKPaint gLines;
        public SKPaint gLinesSelected;
        public SKPaint gMoves;
        public SKPaint BoardBorder;
        private int drawingToDraw = -1;

        private int closesToMouse = -1;
        private int moveIndex = -1;
        private SKPoint mouse;
        private SKPoint dragStart;
        


        public WhiteBoard(PlotControl parent,int w, int h, SKControl controller, ToolStripStatusLabel status, ToolStripStatusLabel mouse)
        {
            BoardSize = new SKSize((float) w, (float)h);
            StatusLabel = status;
            MouseLabel = mouse;
            mainControl = controller;
            mainControl.PaintSurface += PaintSurface;
            mainControl.MouseMove += MouseLocation;
            mainControl.MouseLeave += MouseLeave;
            mainControl.MouseDown += MouseDown;
            mainControl.MouseUp += MouseUp;
            mainControl.MouseDoubleClick += mouseDoubleClick;
            Parent = parent;

            BoardBorder = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Black,
                StrokeWidth = 2
            };


            gMoves = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Red,
                StrokeWidth = 1.0f
            };

            gLines = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.DarkGray,
                StrokeWidth = 1.5f
            };

            gLinesSelected = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Black,
                StrokeWidth = 1.5f
            };
            AllDrawings = new List<GcodeDrawing>();
        }

        

        private void PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var mainGraphic = e.Surface.Canvas;
            
            CanvasSize = new SKSize((float)e.Info.Width, (float)e.Info.Height);

            float RatioCanvas = CanvasSize.Height / CanvasSize.Width;
            float RatioBoard = BoardSize.Height / BoardSize.Width;

            

            bool wide = false;

            if (RatioCanvas < RatioBoard)
            {
                wide = true;
            }

            StatusLabel.Text = "| Canvas: " + RatioCanvas + " | Board: " + RatioBoard + " | Wide = " + wide;

            SKPoint CenterPoint = new SKPoint(CanvasSize.Width/2,CanvasSize.Height/2);



            float top;
            float left;
            float right;
            float bottom;
            

            if (!wide)
            {
                left = CenterPoint.X * 0.05f;
                right = CenterPoint.X + (CenterPoint.X - left);
                top = CenterPoint.Y-((((right - left) / BoardSize.Width) * BoardSize.Height)/2);                
                bottom = CenterPoint.Y + (CenterPoint.Y - top);
            }
            else
            {
                top = CenterPoint.Y * 0.05f;
                bottom = CenterPoint.Y + (CenterPoint.Y - top);

                left = CenterPoint.X - ((((bottom - top) / BoardSize.Height) * BoardSize.Width) / 2);
                right = CenterPoint.X + (CenterPoint.X - left);

            }

            Scale = (right - left) / BoardSize.Width;
            StatusLabel.Text = "| Canvas: " + RatioCanvas + " | Board: " + RatioBoard + " | Wide = " + wide + " | Width: " + (right-left);
            SKPoint TopLeft = new SKPoint(left,top);
            SKPoint TopRight = new SKPoint(right, top); ;
            SKPoint BottomLeft = new SKPoint(left, bottom);
            BottomRight = new SKPoint(right, bottom);
            mainGraphic.Clear(SystemColors.Control.ToSKColor());

            SKRect board = new SKRect(left,top,right,bottom);
            BoardBorder.Style = SKPaintStyle.Fill;
            BoardBorder.Color = SKColors.White;
            mainGraphic.DrawRect(board,BoardBorder);
            BoardBorder.Style = SKPaintStyle.Stroke;
            BoardBorder.Color = SKColors.Black;
            mainGraphic.DrawRect(board, BoardBorder);

            //mainGraphic.DrawLine(TopLeft,TopRight,BoardBorder);
            //mainGraphic.DrawLine(TopLeft,BottomLeft,BoardBorder);
            //mainGraphic.DrawLine(BottomLeft,BottomRight,BoardBorder);
            //mainGraphic.DrawLine(BottomRight,TopRight,BoardBorder);

            if (AllDrawings.Count > 0)
            {
                /*
                foreach (var b in AllDrawings)
                {
                    if (b.isDrawn)
                    {
                        
                        b.Draw(this,mainGraphic, gLines, gMoves);
                    }
                }
                */
                for (int i = 0; i < AllDrawings.Count; i++)
                {
                    
                    if (AllDrawings[i].isDrawn)
                    {
                        if (i != Parent.lstDraw.SelectedIndex && AllDrawings.Count > 1)
                        {
                            AllDrawings[i].Draw(this, mainGraphic, gLines, gMoves);
                        }
                        else
                        {
                            AllDrawings[i].Draw(this, mainGraphic, gLinesSelected, gMoves);
                        }
                        
                    }
                }
                   
                

                if (closesToMouse != -1)
                {
                    //TODO:TESTTHIS
                    mainGraphic.DrawLine(BoardToCanvas(AllDrawings[closesToMouse].zeroPoint), mouse, gMoves);
                }

            }

            


        }

        private void mouseDoubleClick(object sender, MouseEventArgs e)
        {
            Parent.lstDraw.SelectedIndex = closesToMouse;
        }

        private void MouseLocation(object sender, MouseEventArgs e)
        {
            var w = new SKPoint(e.X, e.Y);

            if (AllDrawings.Count > 0)
            {
                closesToMouse = closestIndex(w);
                mouse = w;
               
            }

            var b = CanvasToBoard(w);

            MouseLabel.Text = " | cX: " + b.X + " | cY: " + b.Y;
            mainControl.Refresh();
        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            if (closesToMouse != -1)
            {
                var dragNow = CanvasToBoard(e.X, e.Y);
                AllDrawings[moveIndex].move(dragNow.X - dragStart.X, dragNow.Y - dragStart.Y);
                //dragStart = CanvasToBoard(e.X, e.Y);
            }
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            if (closesToMouse != -1)
            {
                dragStart = CanvasToBoard(e.X, e.Y);
                moveIndex = closesToMouse;
            }
        }

        private void MouseLeave(object sender, EventArgs e)
        {
            closesToMouse = -1;
            mainControl.Refresh();
        }

        public SKPoint BoardToCanvas(float x, float y)
        {
            return new SKPoint((BottomRight.X - (y*Scale)), (BottomRight.Y - (x * Scale)));
        }

        public SKPoint BoardToCanvas(SKPoint point)
        {
            return BoardToCanvas(point.X, point.Y);
        }


        public SKPoint CanvasToBoard(float x, float y)
        {
            
            return Transformations.InvertXY(new SKPoint((x - BottomRight.X) / -Scale, (y - BottomRight.Y) / -Scale));
        }

        public SKPoint CanvasToBoard(SKPoint point)
        {
            return CanvasToBoard(point.X,point.Y);
        }

        public float GetScale()
        {
            return Scale;

        }

        

        public void AddDrawing(GcodeDrawing drawing)
        {
            AllDrawings.Add(drawing);
        }

        public void DrawDrawing(int index)
        {
            mainControl.MouseClick += DrawDrawing;
            drawingToDraw = index;
            Console.WriteLine("DrawDrawing initiated");
        }

        private void DrawDrawing(object sender, MouseEventArgs e)
        {
            Console.WriteLine("DrawDrawing started");
            if (drawingToDraw != -1)
            {
                
                AllDrawings[drawingToDraw].zeroPoint = CanvasToBoard(e.X, e.Y);
                AllDrawings[drawingToDraw].isDrawn = true;
                Console.WriteLine("DrawDrawing index: " + drawingToDraw + " | Location: " + AllDrawings[drawingToDraw].zeroPoint.X + ", " + AllDrawings[drawingToDraw].zeroPoint.Y);
            }

            mainControl.MouseClick -= DrawDrawing;
            mainControl.Refresh();
        }

        private int closestIndex(SKPoint location)
        {
            if (AllDrawings.Count == 0)
            {
                return -1;
            }
            int closest = 0;
            float distance = float.MaxValue;
            int counter = 0;
            foreach (var v in AllDrawings)
            {
                float d = Transformations.DistanceBetween(v.zeroPoint, CanvasToBoard(location));
                if (d < distance)
                {
                    closest = counter;
                    distance = d;
                }

                counter++;
            }

            return closest;
        }
    }
}

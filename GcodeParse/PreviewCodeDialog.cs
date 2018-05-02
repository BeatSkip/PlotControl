using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SkiaSharp;
using SkiaSharp.Views.Desktop;

namespace PlotControl
{
    public partial class PreviewCodeDialog : Form
    {
        private GcodeDrawing drawing;
        private SKPaint gMoves;
        private SKPaint gLines;
        private float w;
        private float h;

        public PreviewCodeDialog(GcodeDrawing d)
        {
            InitializeComponent();
            drawing = d;
            gMoves = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Red,
                StrokeWidth = 1.5f
            };

            gLines = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Black,
                StrokeWidth = 2.0f
            };
            bounds();
        }

        private void PreviesCodeDialog_Load(object sender, EventArgs e)
        {
            skControl1.PaintSurface += PaintSurface;
        }

        private void bounds()
        {
            float maxX = 0.0f;
            float maxY = 0.0f;


            foreach (var comm in drawing.DrawCommands)
            {
                var r = (GcodeDrawCommand) comm.Value;

                if (r.DrawType == typeof(GcodeArc))
                {
                    var q = (GcodeArc) comm.Value;
                    var i = q.getArc(new SKPoint(0, 0), 1.0f, 0);
                    if (i.Start.X > maxX)
                    {
                        maxX = i.Start.X;
                    }

                    if (i.Start.Y > maxY)
                    {
                        maxY = i.Start.Y;
                    }

                    if (i.End.X > maxX)
                    {
                        maxX = i.End.X;
                    }

                    if (i.End.Y > maxY)
                    {
                        maxY = i.End.Y;
                    }
                }

                if (r.DrawType == typeof(GcodeLine))
                {
                    var q = (GcodeLine) comm.Value;
                    var i = q.getLine(new SKPoint(0, 0), 1.0f, 0);

                    if (i.Start.X > maxX)
                    {
                        maxX = i.Start.X;
                    }

                    if (i.Start.Y > maxY)
                    {
                        maxY = i.Start.Y;
                    }

                    if (i.End.X > maxX)
                    {
                        maxX = i.End.X;
                    }

                    if (i.End.Y > maxY)
                    {
                        maxY = i.End.Y;
                    }
                }
            }

            w = (float) maxX * 1.05f;
            h = (float) maxY * 1.05f;

            int iw = (int) Math.Round(w);
            int ih = (int) Math.Round(h);

            this.ClientSize = new Size(iw, ih);
            Console.WriteLine("maxX: " + maxX + "maxY: " + maxY);
        }

        private void PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            canvas.Clear(SKColors.White);
            Parallel.ForEach(drawing.DrawCommands, (command) =>
            {
                //command.Value.Draw(w, h, zeroPoint, lines, moves, ScaleFactor, RotationDeg);
                var r = (GcodeDrawCommand) command.Value;

                if (r.DrawType == typeof(GcodeArc))
                {
                    var q = (GcodeArc) command.Value;
                    var i = q.getArc(new SKPoint(0, 0), 1.0f, 0);
                    SKPaint p;
                    if (q.PenDown)
                    {
                        p = gLines;
                    }
                    else
                    {
                        p = gMoves;
                    }

                    //h.DrawPath(Transformations.CreateArc(i,w),p);
                    canvas.DrawLine(flipY(i.Start), flipY(i.End), p);
                    //TODO: Teken daadwerkelijk een arc!!
                }
                else if (r.DrawType == typeof(GcodeLine))
                {
                    var q = (GcodeLine) command.Value;
                    var i = q.getLine(new SKPoint(0, 0), 1.0f, 0);
                    SKPaint p;
                    if (q.PenDown)
                    {
                        p = gLines;
                    }
                    else
                    {
                        p = gMoves;
                    }

                    canvas.DrawLine(flipY(i.Start), flipY(i.End), p);
                    //Console.WriteLine("Draw Line!");
                }
                else
                {
                    Console.WriteLine("Not Line or arc!");
                }
            });
        }

        private SKPoint flipY(SKPoint inPoint)
        {
            return new SKPoint(inPoint.X, h - inPoint.Y);
        }
    }
}
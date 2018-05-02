using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;

namespace PlotControl
{
    public static class Transformations
    {
        public static SKPoint RotateRadians(SKPoint point, float radians)
        {
            var ca = Math.Cos(radians);
            var sa = Math.Sin(radians);
            return new SKPoint((float) (ca * point.X - sa * point.Y), (float) (sa * point.X + ca * point.Y));
        }

        public static SKPoint RotateDegrees(SKPoint point, float degrees)
        {
            return RotateRadians(point, ConvertToRadians(degrees));
        }

        public static SKPoint RotateRadiansRelative(SKPoint zero, SKPoint point, float radians)
        {
            var w = new SKPoint(point.X - zero.X, point.Y - zero.Y);

            var ca = Math.Cos(radians);
            var sa = Math.Sin(radians);

            var rotated = new SKPoint((float) (ca * point.X - sa * point.Y), (float) (sa * point.X + ca * point.Y));

            return new SKPoint(rotated.X + zero.X, rotated.Y + zero.Y);
            ;
        }


        public static SKPoint RotatePoint(SKPoint point, float degrees)
        {
            return new SKPoint((float) ((point.X * Math.Cos(degrees)) - (point.Y * Math.Sin(degrees))),
                (float) ((point.X * Math.Sin(degrees)) - (point.Y * Math.Cos(degrees))));
        }

        public static SKPoint GetTransformed(SKPoint point, SKPoint zero, float scale, float rotation)
        {
            //var pointinverted = RotateDegrees(InvertXY(point), rotation);
            var pointinverted = RotateDegrees(point, rotation);

            return new SKPoint((zero.X + (pointinverted.X * scale)), (zero.Y + (pointinverted.Y * scale)));
        }

        public static SKPoint GetTransformedToBoard(WhiteBoard v, SKPoint point, SKPoint zero, float scale,
            float rotation)
        {
            var pointinverted = RotateDegrees(InvertXY(point), rotation);

            var w = new SKPoint((zero.X + (pointinverted.X * scale)), (zero.Y + (pointinverted.Y * scale)));

            return v.BoardToCanvas(w);
        }

        public static SKPoint InvertXY(SKPoint point)
        {
            return new SKPoint(point.Y, point.X);
        }

        public static float ConvertToRadians(float angle)
        {
            return (float) ((Math.PI / 180) * angle);
        }

        public static float RadianToDegree(float angle)
        {
            return (float) (angle * (180.0 / Math.PI));
        }

        public static float DistanceBetween(SKPoint A, SKPoint B)
        {
            float X = A.X - B.X;
            float Y = A.Y - B.Y;

            if (X < 0)
            {
                X = -1 * X;
            }

            if (Y < 0)
            {
                Y = -1 * Y;
            }

            return (float) Math.Sqrt((X * X) + (Y * Y));
        }

        public static int FindCircleCircleIntersections(
            SKPoint start, SKPoint end, float radius,
            out SKPoint intersection1, out SKPoint intersection2)
        {
            // Find the distance between the centers.
            float dx = end.X - start.X;
            float dy = end.Y - start.Y;
            double dist = Math.Sqrt(dx * dx + dy * dy);

            // See how many solutions there are.
            if (dist > radius + radius)
            {
                // No solutions, the circles are too far apart.
                intersection1 = new SKPoint(float.NaN, float.NaN);
                intersection2 = new SKPoint(float.NaN, float.NaN);
                return 0;
            }

            else
            {
                // Find a and h.
                double a = (radius * radius -
                            radius * radius + dist * dist) / (2 * dist);
                double h = Math.Sqrt(radius * radius - a * a);

                // Find P2.
                double cx2 = end.X + a * (start.X - end.X) / dist;
                double cy2 = end.Y + a * (start.Y - end.Y) / dist;

                // Get the points P3.
                intersection1 = new SKPoint(
                    (float) (cx2 + h * (start.Y - end.Y) / dist),
                    (float) (cy2 - h * (start.X - end.X) / dist));
                intersection2 = new SKPoint(
                    (float) (cx2 - h * (start.Y - end.Y) / dist),
                    (float) (cy2 + h * (start.X - end.X) / dist));

                // See if we have 1 or 2 solutions.
                if (dist == radius + radius) return 1;
                return 2;
            }
        }

        public static float angle(SKPoint center, SKPoint point)
        {
            float xDiff = point.X - center.X;
            float yDiff = point.Y - center.Y;

            return (float) (Math.Atan2(yDiff, xDiff));
        }

        public static SKPoint SubtractPoints(SKPoint A, SKPoint B)
        {
            return new SKPoint(A.X - B.X, A.Y - B.Y);
        }

        public static SKPath CreateArc(SKPoint start, SKPoint end, SKPoint center, bool cw)
        {
            float radius = DistanceBetween(start, center);

            float startAngle = (float) Math.Atan2(start.Y - center.Y,
                start.X - center.X);

            float sweepAngle = (float) Math.Atan2(end.Y - center.Y,
                end.X - center.X);

            if (!cw)
            {
                startAngle += (float) Math.PI;
                sweepAngle += (float) Math.PI;
            }

            startAngle = RadianToDegree(startAngle);
            sweepAngle = RadianToDegree(sweepAngle);
            Console.WriteLine("Start angle: " + startAngle + "Sweep angle: " + sweepAngle);

            SKRect rect = new SKRect(center.X - radius, center.Y - radius, center.X + radius, center.Y + radius);
            SKPath p = new SKPath();

            p.AddArc(rect, startAngle, sweepAngle);

            return p;
        }

        public static SKPath CreateArc(ArcSegment a, WhiteBoard w = null)
        {
            if (w == null)

            {
                return CreateArc(a.Start, a.End, a.End, a.CW);
            }
            else
            {
                return CreateArc(w.BoardToCanvas(a.Start), w.BoardToCanvas(a.End), w.BoardToCanvas(a.Center), a.CW);
            }
        }
    }
}
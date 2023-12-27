using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC24
{
    internal record LineEquation
    {
        public double A;
        public double B;
        public double C;
        public Coord Pos;
        public Coord Delta;

        public LineEquation(double x, double y, double dx, double dy, double a, double b, double c)
        {
            A= a;
            B= b;
            C= c;
            Pos = new Coord(x,y);
            Delta = new Coord(dx,dy);
        }

        public static LineEquation GetGeneralFormEquation(double x1, double y1, double deltaX, double deltaY)
        {
            // get a second point
            double x2 = x1 + deltaX;
            double y2 = y1 + deltaY;

            // Ax + By + C = 0
            double a = y1 - y2;
            double b = x2 - x1;
            double c = x1 * y2 - x2 * y1;

            return new LineEquation(x1, y1, deltaX, deltaY, a, b, c);
        }

        public double TryFindIntersection(LineEquation line2)
        {
            // parallel (A1/B1 == A2/B2)
            if (A * line2.B == line2.A * B)
            {
                return double.NaN;
            }

            // Cramers Rule
            var intersectX = (B * line2.C - line2.B * C) / (A * line2.B - line2.A * B);

            // intersectX = X + t * Dx
            return (intersectX - Pos.X)/Delta.X;
        }

        public Coord GetPosAtTime(double t)
        {
            var x = Pos.X + Delta.X * t;
            var y = Pos.Y + Delta.Y * t;
            return new Coord(x, y);
        }

        public override string ToString()
        {
            return $"{Pos.X} {Pos.Y} @ {Delta.X} {Delta.Y}";
        }
    }
}

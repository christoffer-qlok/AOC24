using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC24
{
    internal struct Coord
    {
        public double X, Y;

        public Coord(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X:0.00}, {Y:0.00})";
        }
    }
}

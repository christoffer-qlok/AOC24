using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
    public class Line
    {
        public Vec Pos { get; set; }
        public Vec Delta { get; set; }

        public Line(long x, long y, long z, long dx, long dy, long dz)
        {
            Pos = new Vec(x, y, z);
            Delta = new Vec(dx, dy, dz);
        }
    }
}

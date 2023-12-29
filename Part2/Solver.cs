using System;
using Microsoft.Z3;
using System;
using System.Numerics;

namespace Part2
{
    public class Solver
    {
        public static BigInteger SolveSystem(Line[] lines)
        {
            using (Context ctx = new Context())
            {
                IntExpr x = ctx.MkIntConst("x");
                IntExpr y = ctx.MkIntConst("y");
                IntExpr z = ctx.MkIntConst("z");
                IntExpr dx = ctx.MkIntConst("dx");
                IntExpr dy = ctx.MkIntConst("dy");
                IntExpr dz = ctx.MkIntConst("dz");

                Microsoft.Z3.Solver s = ctx.MkSolver();

                for (int i = 0; i < lines.Length; i++)
                {
                    Line l = lines[i];
                    IntExpr t = ctx.MkIntConst($"t{i}");
                    // x + t * dx = xi + t * dxi
                    s.Assert(ctx.MkEq(ctx.MkAdd(x, ctx.MkMul(dx, t)), ctx.MkAdd(ctx.MkInt(l.Pos.X), ctx.MkMul(ctx.MkInt(l.Delta.X), t))));
                    s.Assert(ctx.MkEq(ctx.MkAdd(y, ctx.MkMul(dy, t)), ctx.MkAdd(ctx.MkInt(l.Pos.Y), ctx.MkMul(ctx.MkInt(l.Delta.Y), t))));
                    s.Assert(ctx.MkEq(ctx.MkAdd(z, ctx.MkMul(dz, t)), ctx.MkAdd(ctx.MkInt(l.Pos.Z), ctx.MkMul(ctx.MkInt(l.Delta.Z), t))));
                }

                if (s.Check() == Status.SATISFIABLE)
                {
                    Model m = s.Model;
                    Console.WriteLine($"Solution: ({m.Evaluate(x).Simplify()}, {m.Evaluate(y).Simplify()}, {m.Evaluate(z).Simplify()}) @ ({m.Evaluate(dx).Simplify()}, {m.Evaluate(dy).Simplify()}, {m.Evaluate(dz).Simplify()})");
                    var resultX = ((IntNum)m.Evaluate(x)).BigInteger;
                    var resultY = ((IntNum)m.Evaluate(y)).BigInteger;
                    var resultZ = ((IntNum)m.Evaluate(z)).BigInteger;
                    return resultX + resultY + resultZ;
                }
                else
                {
                    Console.WriteLine("No solution found.");
                    return 0;
                }
            }
        }
    }
}
namespace Part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double boundMin = 200000000000000;
            double boundMax = 400000000000000;

            var lines = File.ReadAllLines("input.txt");
            var vecs = new List<Line>();
            foreach ( var line in lines )
            {
                var parts = line.Split(" @ ");
                var pos = parts[0].Split(", ").Select(long.Parse).ToArray();
                var delta = parts[1].Split(", ").Select(long.Parse).ToArray();

                vecs.Add(new Line(pos[0], pos[1], pos[2], delta[0], delta[1], delta[2]));
            }



            var ans = SolverExample.SolveSystem(vecs.ToArray());
            Console.WriteLine($"Answer is: {ans}");
            //Console.WriteLine($"{ans.Item1} {ans.Item2} {ans.Item3} {ans.Item4} {ans.Item5} {ans.Item6}");
        }
    }
}

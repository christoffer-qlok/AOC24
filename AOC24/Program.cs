namespace AOC24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double boundMin = 200000000000000;
            double boundMax = 400000000000000;

            var lines = File.ReadAllLines("input.txt");
            var vecs = new List<LineEquation>();
            foreach ( var line in lines )
            {
                var parts = line.Split(" @ ");
                var pos = parts[0].Split(", ").Select(double.Parse).ToArray();
                var delta = parts[1].Split(", ").Select(double.Parse).ToArray();
                vecs.Add(LineEquation.GetGeneralFormEquation(pos[0], pos[1], delta[0], delta[1]));
            }

            int count = 0;
            for (int i = 0; i < vecs.Count() - 1; i++)
            {
                for (int j = i + 1; j < vecs.Count(); j++)
                {
                    var t = vecs[i].TryFindIntersection(vecs[j]);
                    if(t < 0) continue;
                    var t2 = vecs[j].TryFindIntersection(vecs[i]);
                    if(t2 < 0) continue;
                    var pos = vecs[i].GetPosAtTime(t);

                    if(pos.X >= boundMin && pos.X <= boundMax && pos.Y >= boundMin && pos.Y <= boundMax)
                    {
                        count++;
                        //Console.WriteLine(vecs[i]);
                        //Console.WriteLine(vecs[j]);
                        //Console.WriteLine($"@{pos}");
                        //Console.WriteLine();
                    }
                }
            }

            Console.WriteLine($"Total: {count}");
        }
    }
}

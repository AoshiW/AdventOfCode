using System;
using System.Linq;

namespace AdventOfCode.Y2015
{
    public class D06 : BaseDay
    {
        public D06(string input) : base(2015, 1, input)
        {

        }

        /// <inheritdoc/>
        public override string Part1()
        {
            var lines = Input.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            var grid = new bool[1000][];
            for (int i = 0; i < grid.Length; i++)
                grid[i] = new bool[1000];
            for (int i = 0; i < lines.Length; i++)
                Sw(lines[i]);
            return grid.Sum(x => x.Sum(y => y ? 1 : 0)).ToString();
            void Sw(string str)
            {
                if (str[4] == ' ')
                    str = str.Remove(4, 1);
                var par = str.Split(new[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);
                int x1 = int.Parse(par[2]),
                    y1 = int.Parse(par[1]),
                    x2 = int.Parse(par[5]),
                    y2 = int.Parse(par[4]);
                for (; x1 <= x2; x1++)
                {
                    for (var y3 = y1; y3 <= y2; y3++)
                    {
                        grid[y3][x1] = par[0] == "turnoff" ? false : par[0] == "turnon" ? true : !grid[y3][x1];
                    }
                }
            }
        }

        /// <inheritdoc/>
        public override string Part2()
        {
            var lines = Input.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            var grid = new int[1000][];
            for (int i = 0; i < grid.Length; i++)
                grid[i] = new int[1000];
            for (int i = 0; i < lines.Length; i++)
                Sw(lines[i]);
            return grid.Sum(x => x.Sum()).ToString();
            void Sw(string str)
            {
                if (str[4] == ' ')
                    str = str.Remove(4, 1);
                var par = str.Split(new[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);
                int x1 = int.Parse(par[2]),
                    y1 = int.Parse(par[1]),
                    x2 = int.Parse(par[5]),
                    y2 = int.Parse(par[4]);
                for (; x1 <= x2; x1++)
                {
                    for (var y3 = y1; y3 <= y2; y3++)
                    {
                        grid[y3][x1] += par[0] == "turnoff" ? (grid[y3][x1] == 0 ? 0 : -1) : par[0] == "turnon" ? 1 : 2;
                    }
                }
            }
        }
    }
}

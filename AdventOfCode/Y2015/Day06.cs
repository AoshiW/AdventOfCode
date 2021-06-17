using System;
using System.Linq;

namespace AdventOfCode.Y2015
{
    public class Day06 : BaseDay<int>
    {
        public Day06(string input) : base(2015, 6, input)
        {

        }

        /// <inheritdoc/>
        public override int Part1()
        {
            var lines = Input.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            var grid = new bool[1000][];
            for (int i = 0; i < grid.Length; i++)
                grid[i] = new bool[1000];
            for (int i = 0; i < lines.Length; i++)
                Sw(lines[i]);
            return grid.Sum(x => x.Sum(y => y ? 1 : 0));
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
#pragma warning disable IDE0075 // Simplify conditional expression
                        grid[y3][x1] = par[0] == "turnoff" ? false : par[0] == "turnon" ? true : !grid[y3][x1];
#pragma warning restore IDE0075 // Simplify conditional expression
                    }
                }
            }
        }

        /// <inheritdoc/>
        public override int Part2()
        {
            var lines = Input.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            var grid = new int[1000][];
            for (int i = 0; i < grid.Length; i++)
                grid[i] = new int[1000];
            for (int i = 0; i < lines.Length; i++)
                Sw(lines[i]);
            return grid.Sum(x => x.Sum());
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

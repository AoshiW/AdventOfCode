using AdventOfCode.Y2015;
using System;
using System.Threading.Tasks;

namespace AdventOfCode.ConsoleApp
{
    public class Program
    {
        static readonly Aoc aoc = new("");

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello Advent Of Code!");
            var inp = await aoc.GetInput(2015, 18);
            var d = new Day18(inp);
            Console.WriteLine(d.Part1());
            Console.WriteLine(d.Part2());
        }
    }
}

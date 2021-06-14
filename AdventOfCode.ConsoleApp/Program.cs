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
            var inp = await aoc.GetInput(new DateTime(2015, 12, 7));
            Console.WriteLine(new D07(inp).Part1());
            Console.WriteLine(new D07(inp).Part2());
        }
    }
}

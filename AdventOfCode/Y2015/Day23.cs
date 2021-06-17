using System;

namespace AdventOfCode.Y2015
{
    public class Day23 : BaseDay<int>
    {
        public Day23(string input) : base(2015, 23, input)
        {

        }

        /// <inheritdoc/>
        public override int Part1()
        {
            var lines = Input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            int a = 0, b = 0;
            for (int pos = 0; pos < lines.Length;)
            {
                pos += Instrukce(ref (lines[pos].Contains('a') ? ref a : ref b), lines[pos]);
            }
            return b;
        }

        public static int Instrukce(ref int register, string instruction)
        {
            var line = instruction.Split(new[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);
            switch (line[0])
            {
                case "hlf": register /= 2; break;
                case "tpl": register *= 3; break;
                case "inc": register++; break;
                case "jmp": return int.Parse(line[1]);
                case "jie":
                    if (register % 2 == 0)
                    {
                        return int.Parse(line[2]);
                    }
                    break;
                case "jio":
                    if (register == 1)
                    {
                        return int.Parse(line[2]);
                    }
                    break;
            }
            return 1;
        }

        /// <inheritdoc/>
        public override int Part2()
        {
            var lines = Input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            int a = 1, b = 0;
            for (int pos = 0; pos < lines.Length;)
            {
                pos += Instrukce(ref lines[pos].Contains('a') ? ref a : ref b, lines[pos]);
            }
            return b;
        }
    }
}

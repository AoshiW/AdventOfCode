using System;
using System.Collections.Generic;

namespace AdventOfCode.Y2015
{
    public class Day03 : BaseDay<int>
    {
        public Day03(string input) : base(2015, 3, input)
        {

        }

        /// <inheritdoc/>
        public override int Part1()
        {
            var house = new HashSet<(int, int)>();
            int x = 0, y = 0;
            for (int i = 0; i < Input.Length; i++)
            {
                switch (Input[i])
                {
                    case '>': x++; break;
                    case '<': x--; break;
                    case '^': y--; break;
                    case 'v': y++; break;
                    default: break;
                }
                house.Add((x, y));
            }
            return house.Count;
        }

        /// <inheritdoc/>
        public override int Part2()
        {
            var house = new HashSet<(int, int)>();
            int x1 = 0, y1 = 0,
                x2 = 0, y2 = 0;
            bool isSanta = false;
            for (int i = 0; i < Input.Length; i++)
            {
                if (isSanta)
                {
                    switch (Input[i])
                    {
                        case '>': x1++; break;
                        case '<': x1--; break;
                        case '^': y1--; break;
                        case 'v': y1++; break;
                        default: throw new ArgumentException($"Illegal  char, {Input[i]}", nameof(Input));
                    }
                    house.Add((x1, y1));
                }
                else
                {
                    switch (Input[i])
                    {
                        case '>': x2++; break;
                        case '<': x2--; break;
                        case '^': y2--; break;
                        case 'v': y2++; break;
                        default: throw new ArgumentException($"Illegal  char, {Input[i]}", nameof(Input));
                    }
                    house.Add((x2, y2));
                }
                isSanta = !isSanta;
            }
            return house.Count;
        }
    }
}

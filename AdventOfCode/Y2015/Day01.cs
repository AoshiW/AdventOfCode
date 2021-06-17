using System;

namespace AdventOfCode.Y2015
{
    public class Day01 : BaseDay<int>
    {
        public Day01(string input) : base(2015, 1, input)
        {
        }

        /// <inheritdoc/>
        public override int Part1()
        {
            int sum = 0;
            for (int i = 0; i < Input.Length; i++)
            {
                sum += Input[i] == '(' ? 1 : -1;
            }
            return sum;
            //return Input.Sum(x => x == '(' ? 1 : -1); slower, but easier
        }

        /// <inheritdoc/>
        public override int Part2()
        {
            int florr = 0;
            for (int i = 0; i < Input.Length; i++)
            {
                florr += Input[i] == '(' ? 1 : -1;
                if (florr == -1)
                    return i + 1;
            }
            throw new Exception("Wrong data.");
        }
    }
}

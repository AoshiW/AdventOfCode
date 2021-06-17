namespace AdventOfCode.Y2015
{
    public class Day25 : BaseDay<long>
    {
        public Day25(string input) : base(2015, 14, input)
        {

        }

        /// <inheritdoc/>
        public override long Part1()
        {
            int row = 2_978,
                column = 3_083;
            var number = 20151125L;
            for (int l = 2; ; l++)
            {
                for (int r = l, c = 1; r > 0; r--, c++)
                {
                    number = number * 252533L % 33554393L;
                    if (r == row && c == column)
                    {
                        return number;
                    }
                }
            }
        }

        /// <inheritdoc/>
        public override long Part2()
        {
            return -1L;
        }
    }
}

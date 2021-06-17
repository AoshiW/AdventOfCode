using System;

namespace AdventOfCode.Y2015
{
    public class Day08 : BaseDay<int>
    {
        public Day08(string input) : base(2015, 8, input)
        {

        }

        /// <inheritdoc/>
        public override int Part1()
        {
            var lines = Input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            int sum = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                var isEscaped = false;
                int hex = 0;
                sum += 2;
                for (int i2 = 1; i2 < lines[i].Length - 1; i2++)
                {
                    var c = lines[i][i2];
                    if (isEscaped)
                    {
                        sum++;
                        if (hex == 0)
                        {
                            if (c == 'x')
                            {
                                hex++;
                            }
                            else
                            {
                                isEscaped = false;
                            }
                        }
                        else
                        {
                            hex++;
                            if (hex == 3)
                            {
                                isEscaped = false;
                                hex = 0;
                            }
                        }
                    }
                    else
                    {
                        if (c == '\\')
                        {
                            isEscaped = true;
                        }
                    }
                }
            }
            return sum;
        }

        /// <inheritdoc/>
        public override int Part2()
        {
            var lines = Input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            int sum = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                var isEscaped = false;
                int hex = 0;
                sum += 4;
                for (int i2 = 1; i2 < lines[i].Length - 1; i2++)
                {
                    var c = lines[i][i2];
                    if (isEscaped)
                    {
                        if (hex == 0)
                        {
                            if (c == 'x')
                            {
                                hex++;
                            }
                            else
                            {
                                sum++;
                                isEscaped = false;
                            }
                        }
                        else
                        {
                            hex++;
                            if (hex == 3)
                            {
                                isEscaped = false;
                                hex = 0;
                            }
                        }
                    }
                    else
                    {
                        if (c == '\\')
                        {
                            sum++;
                            isEscaped = true;
                        }
                    }
                }
            }
            return sum;
        }
    }
}

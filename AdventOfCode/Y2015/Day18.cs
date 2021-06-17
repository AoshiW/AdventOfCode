using System;

namespace AdventOfCode.Y2015
{
    public class Day18 : BaseDay<int>
    {
        public Day18(string input) : base(2015, 14, input)
        {

        }

        /// <inheritdoc/>
        public override int Part1()
        {
            var lines = Input.Split(new[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
            bool[][,] light = new bool[2][,] {
                new bool[lines.Length, lines[0].Length],
                new bool[lines.Length, lines[0].Length]
            };
            for (int r = 0; r < lines.Length; r++)
            {
                for (int c = 0; c < lines[0].Length; c++)
                {
                    light[0][ r, c] = lines[r][c] == '#';
                }
            }
            var moves = new (int r, int c)[] {
               (-1,-1), (-1,0), (-1,1),
                (0,-1),          (0,1),
                (1,-1),  (1,0),  (1,1)
            };
            for (int i = 0; i < 100; i++)
            {
                for (int r = 0; r < lines.Length; r++)
                {
                    for (int c = 0; c < lines[0].Length; c++)
                    {
                        int sum = 0, rp, cp;
                        foreach (var item in moves)
                        {
                            rp = r + item.r;
                            cp = c + item.c;
                            if (cp != -1 && cp != lines[0].Length && rp != -1 && rp != lines.Length)
                            {
                                if (light[i % 2][rp, cp])
                                {
                                    sum++;
                                }
                            }      }

                        if (light[i % 2][r, c])
                        {
                            light[(i + 1) % 2][r, c] = sum is 2 or 3;
                        }
                        else
                        {
                            light[(i + 1) % 2][r, c] = sum == 3;
                        }
                    }
                }
            }//1276 moc,  767?
            int on = 0;
            foreach (var isOn in light[0])
            {
                if (isOn)
                {
                    on++;
                }
            }
            return on;
        }

        /// <inheritdoc/>
        public override int Part2()
        {
            var lines = Input.Split(new[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
            bool[][,] light = new bool[2][,] {
                new bool[lines.Length, lines[0].Length],
                new bool[lines.Length, lines[0].Length]
            };
            for (int r = 0; r < lines.Length; r++)
            {
                for (int c = 0; c < lines[0].Length; c++)
                {
                    light[0][r, c] = lines[r][c] == '#';
                }
            }
            var moves = new (int r, int c)[] {
               (-1,-1), (-1,0), (-1,1),
                (0,-1),          (0,1),
                (1,-1),  (1,0),  (1,1)
            };
            for (int i = 0; i < 100; i++)
            {
                light[0][0, 0] = light[1][0, 0] =
                    light[0][0, lines.Length - 1] = light[1][0, lines.Length - 1] =
                    light[0][lines.Length - 1, 0] = light[1][lines.Length - 1, 0] =
                    light[0][lines.Length - 1, lines.Length - 1] = light[1][lines.Length - 1, lines.Length - 1] = true;
                for (int r = 0; r < lines.Length; r++)
                {
                    for (int c = 0; c < lines[0].Length; c++)
                    {
                        int sum = 0, rp, cp;
                        foreach (var item in moves)
                        {
                            rp = r + item.r;
                            cp = c + item.c;
                            if (cp != -1 && cp != lines[0].Length && rp != -1 && rp != lines.Length)
                            {
                                if (light[i % 2][rp, cp])
                                {
                                    sum++;
                                }
                            }
                        }

                        if (light[i % 2][r, c])
                        {
                            light[(i + 1) % 2][r, c] = sum is 2 or 3;
                        }
                        else
                        {
                            light[(i + 1) % 2][r, c] = sum == 3;
                        }
                    }
                }
            }
            light[0][0, 0] = light[1][0, 0] =
                light[0][0, lines.Length - 1] = light[1][0, lines.Length - 1] =
                light[0][lines.Length - 1, 0] = light[1][lines.Length - 1, 0] =
                light[0][lines.Length - 1, lines.Length - 1] = light[1][lines.Length - 1, lines.Length - 1] = true;
            int on = 0;
            foreach (var isOn in light[0])
            {
                if (isOn)
                {
                    on++;
                }
            }
            return on;
        }
    }
}

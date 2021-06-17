using System;
using System.Linq;

namespace AdventOfCode.Y2015
{
    public class Day14 : BaseDay<int>
    {
        public Day14(string input) : base(2015, 14, input)
        {
        }

        const int _time = 2503;

        /// <inheritdoc/>
        public override int Part1()
        {
            var parsed = Input.Split(new[] { '\n', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[][] data = new int[parsed.Length / 15][];
            for (int i = 0; i < parsed.Length / 15; i++)
            {
                var temp = i * 15;
                data[i] = new[]
                {
                    int.Parse(parsed[temp + 3]), // km/s
                    int.Parse(parsed[temp + 6]), // for
                    int.Parse(parsed[temp + 13]) // rest
                };
            }
            for (int i = 0; i < data.Length; i++)
            {
                var periodTime = data[i][1] + data[i][2];
                var countPeriod = _time / periodTime;
                var modulo = _time % periodTime;
                if (modulo > data[i][1])
                    modulo = data[i][1];
                data[i][0] = data[i][0] * (countPeriod * data[i][1] + modulo);
            }
            return data.Max(x => x[0]);
        }

        /// <inheritdoc/>
        public override int Part2()
        {
            var parsed = Input.Split(new[] { '\n', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[][] data = new int[parsed.Length / 15][];
            for (int i = 0; i < parsed.Length / 15; i++)
            {
                var temp = i * 15;
                data[i] = new[]
                {
                    int.Parse(parsed[temp + 3]), // km/s
                    int.Parse(parsed[temp + 6]), // for
                    int.Parse(parsed[temp + 13]),// rest
                    0, // km
                    0, // s
                    0  // point
                };
            }
            int maxKm = 0;
            for (int i = 0; i < _time; i++)
            {
                for (int s = 0; s < data.Length; s++)
                {
                    if (data[s][4] % (data[s][1] + data[s][2]) < data[s][1])
                    {
                        data[s][3] += data[s][0];
                        if (data[s][3] > maxKm)
                        {
                            maxKm = data[s][3];
                        }
                    }
                    data[s][4]++;
                }
                for (int s = 0; s < data.Length; s++)
                {
                    if(data[s][3] == maxKm)
                    {
                        data[s][^1]++;
                    }
                }
            }
            return data.Max(x => x[^1]);
        }
    }
}

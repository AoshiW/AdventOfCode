using System;

namespace AdventOfCode.Y2015
{
    public class Day02 : BaseDay<long>
    {
        public Day02(string input) : base(2015, 2, input)
        {

        }

        /// <inheritdoc/>
        public override long Part1()
        {
            var lines = Input.Split(new[] { "\n", "x" }, StringSplitOptions.RemoveEmptyEntries);
            var sum = 0L;
            for (int i = 0; i < lines.Length; i += 3)
            {
                int l = int.Parse(lines[i]),
                    w = int.Parse(lines[i + 1]),
                    h = int.Parse(lines[i + 2]),
                    min = Math.Min(l, Math.Min(w, h));
                sum += 2 * (w * (l + h) + h * l) + min * (l + w + h - min - Math.Max(l, Math.Max(w, h)));
            }
            return sum;
        }

        /// <inheritdoc/>
        public override long Part2()
        {
            var lines = Input.Split(new[] { "\n", "x" }, StringSplitOptions.RemoveEmptyEntries);
            var sum = 0L;
            for (int i = 0; i < lines.Length; i += 3)
            {
                int l = int.Parse(lines[i]),
                    w = int.Parse(lines[i + 1]),
                    h = int.Parse(lines[i + 2]);
                sum += l * w * h + 2 * (l + w + h - Math.Max(l, Math.Max(w, h)));
            }
            return sum;
        }
    }
}

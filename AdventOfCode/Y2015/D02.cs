using System;

namespace AdventOfCode.Y2015
{
    public class D02 : BaseDay
    {
        public D02(string input) : base(2015, 2, input)
        {

        }

        /// <inheritdoc/>
        public override string Part1()
        {
            var lines = Input.Split(new[] { "\n", "x" }, StringSplitOptions.RemoveEmptyEntries);
            var sum = 0;
            for (int i = 0; i < lines.Length; i += 3)
            {
                int l = int.Parse(lines[i]),
                    w = int.Parse(lines[i + 1]),
                    h = int.Parse(lines[i + 2]);
                int a = 2 * l * w,
                    b = 2 * w * h,
                    c = 2 * h * l,
                    min = Math.Min(l, Math.Min(w, h));
                sum += a + b + c + min * (l + w + h - min - Math.Max(l, Math.Max(w, h)));
            }
            return sum.ToString();
        }

        /// <inheritdoc/>
        public override string Part2()
        {
            var lines = Input.Split(new[] { "\n", "x" }, StringSplitOptions.RemoveEmptyEntries);
            var sum = 0L;
            for (int i = 0; i < lines.Length; i += 3)
            {
                int l = int.Parse(lines[i]),
                    w = int.Parse(lines[i + 1]),
                    h = int.Parse(lines[i + 2]),
                    min = Math.Min(l, Math.Min(w, h));
                sum += l * w * h + 2 * min + 2 * (l + w + h - min - Math.Max(l, Math.Max(w, h)));
            }
            return sum.ToString();
        }
    }
}

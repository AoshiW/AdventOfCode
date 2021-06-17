using System;
using System.Collections.Generic;

namespace AdventOfCode.Y2015
{
    public class Day05 : BaseDay<int>
    {
        const string aeiou = "aeiou";

        public Day05(string input) : base(2015, 5, input)
        {

        }

        /// <inheritdoc/>
        public override int Part1()
        {
            var lines = Input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            int nice = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (isNice(lines[i]))
                    nice++;
            }
            return nice;
            static bool isNice(string str)
            {
                var hs = new List<char>();
                if (Throw2(str))
                    return false;
                for (int i = 0; i < str.Length; i++)
                {
                    if (aeiou.Contains(str[i]))
                        hs.Add(str[i]);
                }
                if (hs.Count > 2 && TwoSame(str))
                    return true;
                return false;
            }
            static bool TwoSame(string str)
            {
                for (int i = 0; i < str.Length - 1; i++)
                    if (str[i] == str[i + 1])
                        return true;
                return false;
            }
            static bool Throw2(string str)
            {
                foreach (var item in new[] { "ab", "cd", "pq", "xy" })
                {
                    if (str.Contains(item))
                        return true;
                }
                return false;
            }
        }

        /// <inheritdoc/>
        public override int Part2()
        {
            var lines = Input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            int nice = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (OzO(lines[i]) && Dbl(lines[i]))
                    nice++;
            }
            return nice;
        }
        static bool OzO(string str)
        {
            for (int i = 0; i < str.Length - 2; i++)
            {
                if (str[i] == str[i + 2])
                    return true;
            }
            return false;
        }
        static bool Dbl(string str)
        {
            for (int i = 2; i < str.Length; i++)
            {
#pragma warning disable IDE0057 // Use range operator
                if (str.Substring(i).Contains(str.Substring(i - 2, 2)))
#pragma warning restore IDE0057 // Use range operator
                    return true;
            }
            return false;
        }
    }
}

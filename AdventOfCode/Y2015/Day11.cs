using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Y2015
{
    public class Day11 : BaseDay<string>
    {
        public Day11(string input) : base(2015, 11, input)
        {

        }

        /// <inheritdoc/>
        public override string Part1()
        {
            var sb = new StringBuilder(Input);
            UpdateString(sb);
            while (!ValidateString(sb))
            {
                UpdateString(sb);
            }
            return sb.ToString();
        }

        static void UpdateString(StringBuilder sb)
        {
            for (int i = sb.Length - 1; i >= 0; i--)
            {
                if(sb[i] != 'z')
                {
                    sb[i]++;
                    return;
                }
                sb[i] = 'a';
            }
        }

        static bool ValidateString(StringBuilder sb)
        {
            var ilc = new HashSet<char> { 'i', 'l', 'o' };
            bool p1 = false, p3 = false;

            for (int i = 0; i < sb.Length - 2; i++)
            {
                if (sb[i + 1] == (sb[i] + 1) && sb[i + 2] == (sb[i] + 2))
                {
                    p1 = true;
                    break;
                }

            }
            for (int i = 0; i < sb.Length; i++)
            {
                if (ilc.Contains(sb[i]))
                {
                    return false;
                }
            }
            char c = 'o';
            for (int i = 0; i < sb.Length - 1; i++)
            {
                if (sb[i] == sb[i + 1])
                {
                    if (c == 'o')
                    {
                        c = sb[i];
                    }
                    else if (sb[i] != c)
                    {
                        p3 = true;
                        break;
                    }
                }
            }
            return p1 & p3;
        }

        /// <inheritdoc/>
        public override string Part2()
        {
            var sb = new StringBuilder(Input);
            UpdateString(sb);
            while (!ValidateString(sb))
            {
                UpdateString(sb);
            }
            UpdateString(sb);
            while (!ValidateString(sb))
            {
                UpdateString(sb);
            }
            return sb.ToString();
        }
    }
}

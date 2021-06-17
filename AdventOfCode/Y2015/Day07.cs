using System;
using System.Collections.Generic;

namespace AdventOfCode.Y2015
{
    public class Day07 : BaseDay<int>
    {
        public Day07(string input) : base(2015, 7, input)
        {

        }

        /// <inheritdoc/>
        public override int Part1()
        {
            var lines = Input.Split(new[] { "\n", "->" }, StringSplitOptions.RemoveEmptyEntries);
            var dic = new Dictionary<string, object>();
            for (int i = 0; i < lines.Length; i += 2)
            {
                var trim = lines[i].Trim();
                dic.Add(lines[i + 1].Trim(), int.TryParse(trim, out var value) ? value : trim);
            }
            return Get("a", dic);
        }

        static int Get(string key, Dictionary<string, object> dic)
        {
            var value = dic[key];
            if (value is int num)
            {
                return num;
            }
            var valueStr = value as string;
            var split = valueStr!.Split(new[] { " ", }, StringSplitOptions.RemoveEmptyEntries);
            if (split.Length == 1)
            {
                var res = Get(split[0], dic);
                dic[key] = res;
                return res;
            }
            else if (split.Length == 2)
            {
                var res = ~Get(split[1], dic);
                dic[key] = res;
                return res;
            }
            else
            {
                if (!int.TryParse(split[0], out var x))
                {
                    x = Get(split[0], dic);
                }
                if (!int.TryParse(split[2], out var y))
                {
                    y = Get(split[2], dic);
                }
                int res;
#pragma warning disable IDE0066 // Convert switch statement to expression
                switch (split[1])
#pragma warning restore IDE0066 // Convert switch statement to expression
                {
                    case "AND": res= x & y; break;
                    case "OR": res = x | y; break;
                    case "LSHIFT": res = x << y; break;
                    case "RSHIFT": res = x >> y; break;
                    default: throw new Exception();
                }
                dic[key] = res;
                return res;
            }
        }

        /// <inheritdoc/>
        public override int Part2()
        {
            var lines = Input.Split(new[] { "\n", "->" }, StringSplitOptions.RemoveEmptyEntries);
            var dic = new Dictionary<string, object>();
            for (int i = 0; i < lines.Length; i += 2)
            {
                var trim = lines[i].Trim();
                dic.Add(lines[i + 1].Trim(), int.TryParse(trim, out var value) ? value : trim);
            }
            dic["b"] = Part1();
            return Get("a", dic);
        }
    }
}

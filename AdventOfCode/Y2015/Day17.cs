using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Y2015
{
    public class Day17 : BaseDay<int>
    {
        public Day17(string input) : base(2015, 14, input)
        {

        }

        /// <inheritdoc/>
        public override int Part1()
        {
            var args = Input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            int[] nums = new int[args.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = int.Parse(args[i]);
            }
            int count = 0,
                maxCount =(int)Math.Pow(2, nums.Length),
                sum;
            for (int i = 1; i < maxCount; i++)
            {
                sum = 0;

                var str = Convert.ToString(i, 2).PadLeft(nums.Length,'0');
                for (int num = 0; num < nums.Length; num++)
                {
                    if(str[num] == '1')
                    {
                        sum += nums[num];
                    }
                }
                if (sum == 150)
                {
                    count++;
                }
            }
            return count;
        }

        /// <inheritdoc/>
        public override int Part2()
        {
            var args = Input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            var dic = new Dictionary<int, int>();
            int[] nums = new int[args.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = int.Parse(args[i]);
            }
            int maxCount = (int)Math.Pow(2, nums.Length),
                sum;
            for (int i = 1; i < maxCount; i++)
            {
                sum = 0;
                var str = Convert.ToString(i, 2).PadLeft(nums.Length, '0');
                for (int num = 0; num < nums.Length; num++)
                {
                    if (str[num] == '1')
                    {
                        sum += nums[num];
                    }
                }
                if (sum == 150)
                {
                    var key = str.Count(c => c == '1');
                    if (dic.ContainsKey(key))
                    {
                        dic[key]++;
                    }
                    else
                    {
                        dic[key] = 1;
                    }
                }
            }
            return dic.OrderBy(x=>x.Key).First().Value;
        }
    }
}

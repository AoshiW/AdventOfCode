using System;

namespace AdventOfCode
{
    public abstract class BaseDay<T>
    {
        public int Year { get; }
        public int Day { get; }
        public string Input { get; }

        public BaseDay(int year, int day, string input)
        {
            Input = input?.Trim() ?? throw new ArgumentNullException(nameof(input));
            Year = year;
            Day = day;
        }

        public abstract T Part1();
        public abstract T Part2();
    }
}

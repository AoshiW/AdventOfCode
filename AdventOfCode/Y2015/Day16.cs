using System;
using System.Linq;
using static System.Reflection.BindingFlags;

namespace AdventOfCode.Y2015
{
    class AuntSue
    {
        public string Id { get; set; }
        public string? Children { get; set; }
        public string? Cats { get; set; }
        public string? Samoyeds { get; set; }
        public string? Pomeranians { get; set; }
        public string? Akitas { get; set; }
        public string? Vizslas { get; set; }
        public string? Goldfish { get; set; }
        public string? Trees { get; set; }
        public string? Cars { get; set; }
        public string? Perfumes { get; set; }

        private readonly string _toString;
        static readonly Type _thiType = typeof(AuntSue);

        public AuntSue(string line)
        {
            _toString = line;
            var args = line.Split(new[] { ":", ",", " " }, StringSplitOptions.RemoveEmptyEntries);
            Id = args[1];
            for (int i = 2; i < args.Length; i += 2)
            {
                _thiType.GetProperty(args[i], IgnoreCase | Instance | Public)!.SetValue(this, args[i + 1]);
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return _toString;
        }
    }

    public class Day16 : BaseDay<string>
    {
        public Day16(string input) : base(2015, 20, input)
        {
        }

        /// <inheritdoc/>
        public override string Part1()
        {
            var lines = Input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < lines.Length; i++)
            {
                var aunt = new AuntSue(lines[i]);
                if (aunt.Children is "3" or null
                && aunt.Cats is "7" or null
                && aunt.Samoyeds is "2" or null
                && aunt.Pomeranians is "3" or null
                && aunt.Akitas is "0" or null
                && aunt.Vizslas is "0" or null
                && aunt.Goldfish is "5" or null
                && aunt.Trees is "3" or null
                && aunt.Cars is "2" or null
                && aunt.Perfumes is "1" or null)
                    return aunt.Id;
            }
            throw new InvalidOperationException();
        }

        /// <inheritdoc/>
        public override string Part2()
        {
            var lines = Input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < lines.Length; i++)
            {
                var aunt = new AuntSue(lines[i]);
                if (aunt.Children is "3" or null

                && (aunt.Cats is null || int.Parse(aunt.Cats) > 7)
                && (aunt.Trees is null || int.Parse(aunt.Trees) > 3)

                && (aunt.Pomeranians is null || int.Parse(aunt.Pomeranians) < 3)
                && (aunt.Goldfish is null || int.Parse(aunt.Goldfish) < 5)

                && aunt.Samoyeds is "2" or null
                && aunt.Akitas is "0" or null
                && aunt.Vizslas is "0" or null
                && aunt.Cars is "2" or null
                && aunt.Perfumes is "1" or null)
                    return aunt.Id;
            }
            throw new InvalidOperationException();
        }
    }
}

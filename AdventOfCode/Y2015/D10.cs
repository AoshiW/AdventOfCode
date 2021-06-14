using System.Text;

namespace AdventOfCode.Y2015
{
    public class D10 : BaseDay
    {
        public D10(string input) : base(2015, 10, input)
        {

        }

        /// <inheritdoc/>
        public override string Part1()
        {
            StringBuilder input = new(Input), sb = new(), temp;
            for (int ir = 0; ir < 40; ir++)
            {
                char c = input[0];
                int count = 1;
                sb.Clear();
                for (int i = 1; i < input.Length; i++)
                {
                    if (c != input[i])
                    {
                        sb.Append(count).Append(c);
                        c = input[i];
                        count = 1;
                    }
                    else
                    {
                        count++;
                    }
                }
                sb.Append(count).Append(c);
                temp = input;
                input = sb;
                sb = temp;
            }
            return input.Length.ToString();
        }

        /// <inheritdoc/>
        public override string Part2()
        {
            StringBuilder input = new(Input), sb = new(), temp;
            for (int ir = 0; ir < 50; ir++)
            {
                char c = input[0];
                int count = 1;
                sb.Clear();
                for (int i = 1; i < input.Length; i++)
                {
                    if (c != input[i])
                    {
                        sb.Append(count).Append(c);
                        c = input[i];
                        count = 1;
                    }
                    else
                    {
                        count++;
                    }
                }
                sb.Append(count).Append(c);
                temp = input;
                input = sb;
                sb = temp;
            }
            return input.Length.ToString();
        }
    }
}

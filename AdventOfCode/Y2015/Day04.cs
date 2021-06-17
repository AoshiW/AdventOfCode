using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Y2015
{
    public class Day04 : BaseDay<int>
    {
        public Day04(string input) : base(2015, 4, input)
        {

        }

        /// <inheritdoc/>
        public override int Part1()
        {
            var sb = new StringBuilder();
            using var md5 = MD5.Create();
            for (int i = 0; ; i++)
            {
                sb.Clear();
                var inputBytes = Encoding.ASCII.GetBytes(Input + i.ToString());
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                for (int i2 = 0; i2 < 3; i2++)
                {
                    sb.Append(hashBytes[i2].ToString("X2"));
                }
                if (sb[0] == '0' && sb[1] == '0' && sb[2] == '0' && sb[3] == '0' && sb[4] == '0')
                    return i;
            }
        }

        /// <inheritdoc/>
        public override int Part2()
        {
            var sb = new StringBuilder();
            using var md5 = MD5.Create();
            for (int i = 0; ; i++)
            {
                sb.Clear();
                var inputBytes = Encoding.ASCII.GetBytes(Input + i.ToString());
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                for (int i2 = 0; i2 < 3; i2++)
                {
                    sb.Append(hashBytes[i2].ToString("X2"));
                }
                if (sb[0] == '0' && sb[1] == '0' && sb[2] == '0' && sb[3] == '0' && sb[4] == '0' && sb[5] == '0')
                    return i;
            }
        }
    }
}

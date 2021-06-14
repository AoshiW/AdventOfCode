using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Y2015
{
    public class D04 : BaseDay
    {
        public D04(string input) : base(2015, 4, input)
        {

        }

        /// <inheritdoc/>
        public override string Part1()
        {
            using var md5 = MD5.Create();
            var sb = new StringBuilder();
            for (int i = 0; true; i++)
            {
                sb.Clear();
                var inputBytes = Encoding.ASCII.GetBytes(Input + i.ToString());
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                for (int i2 = 0; i2 < 5; i2++)
                {
                    sb.Append(hashBytes[i2].ToString("X2"));
                }
                if (sb[0] == '0' && sb[1] == '0' && sb[2] == '0' && sb[3] == '0' && sb[4] == '0')
                    return i.ToString();
            }
        }

        /// <inheritdoc/>
        public override string Part2()
        {
            var sb = new StringBuilder();
            using var md5 = MD5.Create();
            for (int i = 0; true; i++)
            {
                sb.Clear();
                var inputBytes = Encoding.ASCII.GetBytes(Input + i.ToString());
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                for (int i2 = 0; i2 < 6; i2++)
                {
                    sb.Append(hashBytes[i2].ToString("X2"));
                }
                if (sb[0] == '0' && sb[1] == '0' && sb[2] == '0' && sb[3] == '0' && sb[4] == '0' && sb[5] == '0')
                    return i.ToString();
            }
        }
    }
}

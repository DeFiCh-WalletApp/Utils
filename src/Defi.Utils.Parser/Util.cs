using System;
using System.Linq;
using System.Text;
using NBitcoin;

namespace Defi.Utils.Parser
{
    public static class Util
    {

        public static string ToHexString(this Span<byte> data)
        {
            if (data == null)
            {
                return String.Empty;
            }
            string hex = BitConverter.ToString(data.ToArray()); //TODO: fix as far .net has implemented that api
            return hex.Replace("-", "");
        }

        public static byte[] ToByteArray(this string hex)
        {
            return Enumerable.Range(0, hex.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                .ToArray();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Defi.Utils.Parser.Txs
{
    public class AnyAccountToAccount : BaseTransaction
    {
        public List<DefiAccount> From { get; private set; }
        public List<DefiAccount> To { get; private set; }

        private AnyAccountToAccount()
        {

        }

        public static AnyAccountToAccount Parse(int pos, Span<byte> script)
        {
            var ret = new AnyAccountToAccount
            {
                From = DefiAccount.FromBuffer(ref pos, ref script), To = DefiAccount.FromBuffer(ref pos, ref script)
            };

            return ret;
        }
    }
}

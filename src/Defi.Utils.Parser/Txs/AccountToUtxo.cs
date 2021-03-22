using System;
using System.Collections.Generic;
using System.Text;

namespace Defi.Utils.Parser.Txs
{
    public class AccountToUtxo : BaseTransaction
    {
        public DefiScript From { get; private set; }
        public List<DefiBalance> Balances { get; private set; }
        public int MintintOutputStart { get; set; }

        private AccountToUtxo()
        {

        }

        public static AccountToUtxo Parse(int pos, Span<byte> script)
        {
            var ret = new AccountToUtxo
            {
                From = DefiScript.FromBuffer(ref pos, ref script),
                Balances = DefiBalance.FromBuffer(ref pos, ref script),
                MintintOutputStart = Convert.ToInt32(script[pos])
            };

            return ret;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Defi.Utils.Parser.Txs
{
    public class AccountToAccount : BaseTransaction
    {
        public DefiScript From { get; private set; }
        public List<DefiAccount> To { get; private set; }

        private AccountToAccount()
        {

        }

        public static AccountToAccount Parse(int pos, Span<byte> script)
        {
            var ret = new AccountToAccount
            {
                From = DefiScript.FromBuffer(ref pos, ref script), 
                To = DefiAccount.FromBuffer(ref pos, ref script)
            };

            return ret;
        }
    }
}

using System;
using System.Collections.Generic;

namespace Defi.Utils.Parser.Txs
{
    public class AddLiquidity : BaseTransaction
    {
        public List<DefiAccount> From { get; private set; } = new List<DefiAccount>();
        public DefiScript ShareAddress { get; private set; }


        private AddLiquidity()
        {

        }

        public static AddLiquidity Parse(int pos, Span<byte> script)
        {
            var addLi = new AddLiquidity();
            addLi.From = DefiAccount.FromBuffer(ref pos, ref script);
            addLi.ShareAddress = DefiScript.FromBuffer(ref pos, ref script);


            return addLi;
        }
    }
}

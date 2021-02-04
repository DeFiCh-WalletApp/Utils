using System;
using Defi.Utils.Parser.Txs;

namespace Defi.Utils.Parser
{
    public class DefiScriptParser
    {
        public static byte[] DefiTxHeader = {0x44, 0x66, 0x54, 0x78};
        
        public static BaseTransaction Parse(Span<byte> script)
        {
            var pos = 0;
            var dfiHeader = script.Slice(pos, 4);
            pos = 4;
            

            if (!dfiHeader.SequenceEqual(DefiTxHeader.AsSpan()))
            {
                throw new ArgumentException("This is not a valid DeFi TX!");
            }

            var txType = (DefiTransactions.CustomTxType)script.Slice(pos, 1)[0];
            pos++;

            if (txType == DefiTransactions.CustomTxType.AnyAccountsToAccounts)
            {
                return AnyAccountToAccount.Parse(pos, script);
            }
            else if (txType == DefiTransactions.CustomTxType.AccountToAccount)
            {
                return AccountToAccount.Parse(pos, script);
            }



            return null;
        }
    }
}

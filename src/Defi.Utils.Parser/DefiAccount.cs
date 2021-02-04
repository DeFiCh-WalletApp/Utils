using System;
using System.Collections.Generic;

namespace Defi.Utils.Parser
{
    public class DefiAccount
    {
        public DefiScript Script { get; }
        public List<DefiBalance> Balances { get; }

        private DefiAccount(DefiScript script, List<DefiBalance> balances)
        {
            Script = script;
            Balances = balances;
        }

        public static List<DefiAccount> FromBuffer(ref int pos, ref Span<byte> input)
        {
            var count = input[pos];
            var ret = new List<DefiAccount>();
            pos++;

            for (var i = 0; i < count; i++)
            {
                var script = DefiScript.FromBuffer(ref pos, ref input);
                var balances = DefiBalance.FromBuffer(ref pos, ref input);
                ret.Add(new DefiAccount(script, balances));
            }




            return ret;
        }
    }
}

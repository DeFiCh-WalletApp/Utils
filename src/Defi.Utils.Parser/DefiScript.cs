using System;
using NBitcoin;
using NBitcoin.DataEncoders;

namespace Defi.Utils.Parser
{
    
    
    public class DefiScript
    {
        private readonly byte[] _script;
        private readonly Script _defiScript;
        private readonly string _strScript;

        private DefiScript(Span<byte> script)
        {
            _script = script.ToArray();

            _defiScript = new Script(_script, false);

            _strScript = script.ToHexString();
            var publicKeyHash = new KeyId(_strScript);
            
        

        }

        public static DefiScript FromBuffer(ref int pos, ref Span<byte> data)
        {
            var count = data[pos];
            pos++;

            var buffer = data.Slice(pos, count);
            pos += count;

            var ret = new DefiScript(buffer);
            return ret;
        }
    }
}

using System;

namespace Defi.Utils.Parser.Txs
{
    public class PoolSwap : BaseTransaction
    {
        public DefiScript From { get; private set; }
        public DefiScript To { get; private set; }

        public ulong FromToken { get; set; }
        public ulong ToToken { get; set; }
        
        public ulong FromAmount { get; set; }

        public ulong MaxPrice { get; set; }
        public ulong MaxPriceFraction { get; set; }


        public double MaxPriceDisplay => MaxPrice > 0 ? MaxPrice / 100000000.0 : 0.0;
        public double MaxPriceFractionDisplay => MaxPriceFraction > 0 ? MaxPriceFraction / 100000000.0 : 0.0;

        private PoolSwap()
        {

        }

        public static PoolSwap Parse(int pos, Span<byte> script)
        {
            var from = DefiScript.FromBuffer(ref pos, ref script);
            var fromToken = script.ReadVarIntNum(ref pos);
            var fromTokenAmount = script.ReadUint64(ref pos);

            var to = DefiScript.FromBuffer(ref pos, ref script);
            var toToken = script.ReadVarIntNum(ref pos);
         
            var maxPrice = script.ReadUint64(ref pos);
            var maxPriceFraction = script.ReadUint64(ref pos);

            var ret = new PoolSwap
            {
                From = from,
                FromToken = fromToken,
                FromAmount = fromTokenAmount,
                
                To = to,
                ToToken = toToken,
                
                MaxPrice = maxPrice,
                MaxPriceFraction = maxPriceFraction
            };

            return ret;
        }
    }
}

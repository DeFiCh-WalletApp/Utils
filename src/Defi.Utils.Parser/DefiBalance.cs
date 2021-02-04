using System;
using System.Collections.Generic;

namespace Defi.Utils.Parser
{
    public enum DefiToken
    {
        DFI = 0,
        BTC = 1,
        ETH = 2,
        DFI_BTC = 3,
        DFI_ETH = 4,
        USDT = 5,
        DFI_USDT = 6
    }
   
    public class DefiBalance
    {
        public double Value { get; }
        public DefiToken Token { get; }
        public ulong RawValue { get; }
        public byte[] Data { get; }

        private DefiBalance(double value, DefiToken token, ulong rawValue, Span<byte> data)
        {
            Value = value;
            Token = token;
            RawValue = rawValue;
            Data = data.ToArray();
        }

        public static List<DefiBalance> FromBuffer(ref int pos, ref Span<byte> input)
        {
            var ret = new List<DefiBalance>();
            var count = input[pos];
            pos++;

            for (var i = 0; i < count; i++)
            {
                var int32Bytes = input.Slice(pos, 4);
                pos += 4;
                
                var int64Bytes = input.Slice(pos, 8);
                pos += 8;

                var tokenVal = (DefiToken)BitConverter.ToUInt32(int32Bytes);
                var balanceVal = BitConverter.ToUInt64(int64Bytes);
                ret.Add(new DefiBalance(balanceVal / 100000000, tokenVal, balanceVal, int64Bytes));
            }
            
            return ret;
        }
        
    }
}

using System;

namespace Defi.Utils.Parser
{
    internal static class ParserUtils
    {
        internal static ulong ReadUint64(this Span<byte> buffer, ref int pos)
        {
            var int64Buf = buffer.Slice(pos, 8);
            pos += 8;
            return BitConverter.ToUInt64(int64Buf);
        }
        
        internal static ulong ReadVarIntNum(this Span<byte> buffer, ref int pos)
        {
            var first = buffer[pos];
            

            switch (first)
            {
                case 0xFD:
                    var shortBuf = buffer.Slice(pos, 2);
                    pos += 2;
                    return BitConverter.ToUInt16(shortBuf);
                case 0xFE:

                    var int32Buf = buffer.Slice(pos, 4);
                    pos += 4;
                    return BitConverter.ToUInt32(int32Buf);
                    
                case 0xFF:
                    return buffer.ReadUint64(ref pos);
                default:
                    pos++;
                    return first;
            }
        }
    }
}

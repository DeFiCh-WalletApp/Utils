using System;
using Defi.Utils.Parser;
using Defi.Utils.Parser.Txs;
using Xunit;

namespace DefiUtils.Tests
{
    public class AccountToUtxoTests
    {
        [Fact]
        public void TestParse()
        {
            var input =
                @"446654786217a9145c41c70349fd7ab79e2359bd0f0627d2d9bff8c287010000000000e1f5050000000002"
                    .ToByteArray();
            DefiScriptParser.Parse(input);
        }
    }
}

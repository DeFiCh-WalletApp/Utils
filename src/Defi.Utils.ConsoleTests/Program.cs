using System;
using Defi.Utils.Parser;
using NBitcoin;

namespace Defi.Utils.ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var tx = new byte[]
            {
                0x44, 0x66, 0x54, 0x78, 0x61, 0x01, 0x17, 0xa9, 0x14, 0x5c, 0x41, 0xc7, 0x03, 0x49, 0xfd, 0x7a, 0xb7,
                0x9e, 0x23, 0x59, 0xbd, 0x0f, 0x06, 0x27, 0xd2, 0xd9, 0xbf, 0xf8, 0xc2, 0x87, 0x01, 0x01, 0x00, 0x00,
                0x00, 0x00, 0xe1, 0xf5, 0x05, 0x00, 0x00, 0x00, 0x00, 0x01, 0x17, 0xa9, 0x14, 0x10, 0x84, 0xef, 0x98,
                0xba, 0xcf, 0xec, 0xbc, 0x9f, 0x14, 0x04, 0x96, 0xb2, 0x65, 0x16, 0xae, 0x55, 0xd7, 0x9b, 0xfa, 0x87,
                0x01, 0x01, 0x00, 0x00, 0x00, 0x00, 0xe1, 0xf5, 0x05, 0x00, 0x00, 0x00, 0x00
            };
            string tx2 =
                "44665478610117a914aec26795264ebc0bee6e700e3fd7b79db6e1728f87010100000000ca9a3b000000000117a9141084ef98bacfecbc9f140496b26516ae55d79bfa87010100000000ca9a3b00000000";
            string tx3 =
                "446654784217a9145c41c70349fd7ab79e2359bd0f0627d2d9bff8c2870117a9141084ef98bacfecbc9f140496b26516ae55d79bfa87010100000000e1f50500000000";
            string myTx =
                "44665478610117a9145c41c70349fd7ab79e2359bd0f0627d2d9bff8c287010100000000e1f505000000000117a9141084ef98bacfecbc9f140496b26516ae55d79bfa87010100000000e1f50500000000";
            var input = tx2.ToByteArray();
            var myTxInput = tx3.ToByteArray();
            DefiScriptParser.Parse(myTxInput);

            var completeTx =
                "0400000001f337dff72a9a65aa4f9cde49e48bd65c0e65a2beefb53db8206675ca2d2503ba000000006b483045022100d4ccc4f6b11002d2f946668504370895b7f5f812b0144a8c5b8af5ef4b395f25022050752e144293d3c19046c8511cce4c9b05bd4bc19355e4b90a7cc759dd3e5c620121032b2b28c7348d8d955b2c228e44b644a1a28b243f61eea826eee218ad97da8439ffffffff020000000000000000546a4c5144665478610117a9145c41c70349fd7ab79e2359bd0f0627d2d9bff8c287010100000000e1f505000000000117a9141084ef98bacfecbc9f140496b26516ae55d79bfa87010100000000e1f5050000000096dbf5050000000017a9145c41c70349fd7ab79e2359bd0f0627d2d9bff8c28700000000";
            var tx11 = Transaction.Load(completeTx.ToByteArray(), DefiChain.Instance.Testnet);
            var script =
                "44665478610117a9145c41c70349fd7ab79e2359bd0f0627d2d9bff8c287010100000000e1f505000000000117a9141084ef98bacfecbc9f140496b26516ae55d79bfa87010100000000e1f50500000000";

            var parsedScript = DefiScriptParser.Parse(script.ToByteArray());
            
            Console.ReadLine();
        }
    }
}

namespace Defi.Utils.Parser
{
    public class DefiTransactions
    {
        public enum CustomTxType
        {
            None = 0,

            // masternodes:
            CreateMasternode = 'C',
            ResignMasternode = 'R',

            // custom tokens:
            CreateToken = 'T',
            MintToken = 'M',
            UpdateToken = 'N', // previous type, only DAT flag triggers
            UpdateTokenAny = 'n', // new type of token's update with any flags/fields possible

            // dex orders - just not to overlap in future
//    CreateOrder         = 'O',
//    DestroyOrder        = 'E',
//    MatchOrders         = 'A',
            //poolpair
            CreatePoolPair = 'p',
            UpdatePoolPair = 'u',
            PoolSwap = 's',
            AddPoolLiquidity = 'l',
            RemovePoolLiquidity = 'r',

            // accounts
            UtxosToAccount = 'U',
            AccountToUtxos = 'b',
            AccountToAccount = 'B',
            AnyAccountsToAccounts = 'a',

            //set governance variable
            SetGovVariable = 'G',

            // Auto auth TX
            AutoAuthPrep = 'A'
        }
    }
}

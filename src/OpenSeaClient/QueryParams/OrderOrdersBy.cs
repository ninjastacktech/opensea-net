using System.ComponentModel;

namespace OpenSeaClient
{
    public enum OrderOrdersBy
    {
        /// <summary>
        /// When the order was made.
        /// </summary>
        [Description("created_date")]
        CreatedDate,

        /// <summary>
        /// See the lowest-priced orders first (converted to their ETH values).
        /// eth_price is only supported when asset_contract_address and token_id are also defined.
        /// </summary>
        [Description("eth_price")]
        EthPrice,
    }
}

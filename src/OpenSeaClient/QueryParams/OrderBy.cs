using System.ComponentModel;

namespace OpenSeaClient
{
    public enum OrderBy
    {
        /// <summary>
        /// The last sale's transaction's timestamp
        /// </summary>
        [Description("sale_date")]
        SaleDate,

        /// <summary>
        /// Number of sales
        /// </summary>
        [Description("sale_count")]
        SaleCount,

        /// <summary>
        /// The last sale's total_price
        /// </summary>
        [Description("sale_price")]
        SalePrice,

    }
}

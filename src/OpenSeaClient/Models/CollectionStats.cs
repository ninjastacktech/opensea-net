using Newtonsoft.Json;

namespace OpenSeaClient
{
    public class CollectionStats
    {
        [JsonProperty("one_day_volume")]
        public double OneDayVolume { get; set; }

        [JsonProperty("one_day_change")]
        public double OneDayChange { get; set; }

        [JsonProperty("one_day_sales")]
        public double OneDaySales { get; set; }

        [JsonProperty("one_day_average_price")]
        public double OneDayAveragePrice { get; set; }

        [JsonProperty("seven_day_volume")]
        public double SevenDayVolume { get; set; }

        [JsonProperty("seven_day_change")]
        public double SevenDayChange { get; set; }

        [JsonProperty("seven_day_sales")]
        public double SevenDaySales { get; set; }

        [JsonProperty("seven_day_average_price")]
        public double SevenDayAveragePrice { get; set; }

        [JsonProperty("thirty_day_volume")]
        public double ThirtyDayVolume { get; set; }

        [JsonProperty("thirty_day_change")]
        public double ThirtyDayChange { get; set; }

        [JsonProperty("thirty_day_sales")]
        public double ThirtyDaySales { get; set; }

        [JsonProperty("thirty_day_average_price")]
        public double ThirtyDayAveragePrice { get; set; }

        [JsonProperty("total_volume")]
        public double TotalVolume { get; set; }

        [JsonProperty("total_sales")]
        public double TotalSales { get; set; }

        [JsonProperty("total_supply")]
        public double TotalSupply { get; set; }

        [JsonProperty("count")]
        public double Count { get; set; }

        [JsonProperty("num_owners")]
        public long Owners { get; set; }

        [JsonProperty("average_price")]
        public double AveragePrice { get; set; }

        [JsonProperty("num_reports")]
        public long Reports { get; set; }

        [JsonProperty("market_cap")]
        public double MarketCap { get; set; }

        [JsonProperty("floor_price")]
        public double FloorPrice { get; set; }
    }
}

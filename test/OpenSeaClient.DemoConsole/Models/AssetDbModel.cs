namespace OpenSeaClient.DemoConsole
{
    public class AssetDbModel
    {
        public long Id { get; set; }

        public string? CollectionSlug { get; set; }

        public string? ContractAddress { get; set; }

        public string? TokenId { get; set; }

        public string? TraitType { get; set; }

        public string? Value { get; set; }

        public string? Url { get; set; }

        public string? ImageUrl { get; set; }

        public string? Name { get; set; }

        public double? Price { get; set; }

        public double? Accumulated { get; set; }

        public bool? IsOnSale { get; set; }

        public bool? IsProcessed { get; set; }
    }
}

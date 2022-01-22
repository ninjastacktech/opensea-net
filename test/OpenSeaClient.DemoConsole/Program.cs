using OpenSeaClient.DemoConsole;

//await Snippets.ImportCollectionAssetsAsync(apiKey: "", collectionSlug: "metroverse");

var tokenIds = await Snippets.SearchByTraitsAsync(
    "metroverse",
    x => x.TraitType == "Buildings: Public" && x.Value == "Metroverse Museum",
    x => x.TraitType == "Buildings: Public" && x.Value == "Police Station"
);

Console.ReadLine();

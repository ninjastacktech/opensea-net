using Microsoft.EntityFrameworkCore;

#nullable disable

namespace OpenSeaClient.DemoConsole
{
    public class AssetsDbContext : DbContext
    {
        public DbSet<AssetDbModel> Assets { get; set; }

        public string DbPath { get; }

        public AssetsDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "opensea.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}

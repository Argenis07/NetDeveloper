using Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataAccess
{
    public class ChinookContext : DbContext
    {
        public ChinookContext() : base("ChinookcnxEF")
        {
            Database.SetInitializer<ChinookContext>(null);
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public virtual DbSet<Artist> Artists { get; set; }

        public virtual DbSet<Playlist> Playlists { get; set; }

        public virtual DbSet<Album> Album { get; set; }

        public virtual DbSet<Track> Track { get; set; }
    }
}

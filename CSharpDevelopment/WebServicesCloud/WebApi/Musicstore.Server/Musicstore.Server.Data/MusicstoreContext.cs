using System.Data.Entity;
using Musicstore.Server.Core;
using Musicstore.Server.Data.Mapping;

namespace Musicstore.Server.Data
{
    public class MusicstoreContext : DbContext
    {
        public MusicstoreContext()
            : base("MusicstoreConnectionString")
        {
        }

        public MusicstoreContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlbumMap());
            modelBuilder.Configurations.Add(new ArtistMap());
            modelBuilder.Configurations.Add(new SongMap());

            base.OnModelCreating(modelBuilder);
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }
    }
}

using System.Data.Entity;
using System.Data.Objects;
using Musicstore.Server.Models;

namespace Musicstore.Server.Data
{
    public class MusicstoreContext: DbContext
    {
        public MusicstoreContext()
            : base("MusicstoreConnectionString")
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = true;
        }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>().HasKey(x => x.Id);
            modelBuilder.Entity<Album>().Property(x => x.Title).IsRequired();
            modelBuilder.Entity<Album>().Property(x => x.Title).HasMaxLength(256);
            modelBuilder.Entity<Album>().Property(x => x.Producer).HasMaxLength(256);
            modelBuilder.Entity<Album>().Property(x => x.Producer).IsOptional();
            modelBuilder.Entity<Album>().Property(x => x.Year).IsOptional();

            modelBuilder.Entity<Artist>().HasKey(x => x.Id);
            modelBuilder.Entity<Artist>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Artist>().Property(x => x.Name).IsUnicode(true);
            modelBuilder.Entity<Artist>().Property(x => x.Name).HasMaxLength(256);
            modelBuilder.Entity<Artist>().Property(x => x.Country).HasMaxLength(256);
            modelBuilder.Entity<Artist>().Property(x => x.DateOfBirth).IsOptional();

            modelBuilder.Entity<Song>().HasKey(x => x.Id);
            modelBuilder.Entity<Song>().Property(x => x.Title).HasMaxLength(256); 
            modelBuilder.Entity<Song>().Property(x => x.Genre).IsOptional();
            modelBuilder.Entity<Song>().Property(x => x.Genre).HasMaxLength(256);
            modelBuilder.Entity<Song>().Property(x => x.Year).IsOptional();

            base.OnModelCreating(modelBuilder);
        }

        //public override int SaveChanges()
        //{
        //    UpdateDates();
        //    return base.SaveChanges();
        //}

        //private void UpdateDates()
        //{
        //    foreach (var change in ChangeTracker.Entries())
        //    {
        //        var values = change.CurrentValues;
        //        foreach (var name in values.PropertyNames)
        //        {
        //            var value = values[name];
        //            if (value is DateTime)
        //            {
        //                var date = (DateTime)value;
        //                if (date < SqlDateTime.MinValue.Value)
        //                {
        //                    values[name] = SqlDateTime.MinValue.Value;
        //                }
        //                else if (date > SqlDateTime.MaxValue.Value)
        //                {
        //                    values[name] = SqlDateTime.MaxValue.Value;
        //                }
        //            }
        //        }
        //    }
        //}
       
    }
}

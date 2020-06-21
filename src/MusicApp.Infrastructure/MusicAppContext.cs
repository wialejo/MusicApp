using Microsoft.EntityFrameworkCore;
using MusicApp.Domain;
using MusicApp.Infrastructure.EntityTypeConfiguration;

namespace MusicApp.Infrastructure
{
    public class MusicAppContext : DbContext, IContext
    {
        public MusicAppContext(DbContextOptions options)
            : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite("Data Source=musicApp.db");

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArtistEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AlbumEntityTypeConfiguration());
        }
    }
}

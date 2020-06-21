using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Domain;

namespace MusicApp.Infrastructure.EntityTypeConfiguration
{
    public class ArtistEntityTypeConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasKey(e => e.ArtistId);

            builder.Property(e => e.ArtistId);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.Review);
        }
    }
}
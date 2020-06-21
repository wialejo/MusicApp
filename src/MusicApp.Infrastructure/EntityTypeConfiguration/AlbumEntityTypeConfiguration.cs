using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Domain;

namespace MusicApp.Infrastructure.EntityTypeConfiguration
{
    public class AlbumEntityTypeConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasKey(e => e.AlbumId);

            builder.Property(e => e.AlbumId);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.Price)
                .HasColumnType("money")
                .HasDefaultValueSql("((0))");

            builder.Property(e => e.Rating);

            builder.Property(e => e.NumberOfRates);

            builder.Property(e => e.ReleaseDateTime)
                .HasColumnType("datetime");

            builder.Property(e => e.Rights)
                .HasMaxLength(255);

            builder.Property(e => e.ImageUrl)
                .HasMaxLength(255);

            builder.Property(e => e.Genre)
                .HasMaxLength(255);

            builder.HasOne(e => e.Artist)
                .WithMany(e => e.Albums);
        }
    }
}
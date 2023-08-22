using CinemaBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBooking.Infrastructure.Data.Configurations;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasKey(m => m.Id);

        builder.HasIndex(m => m.Title)
            .IsUnique();

        builder.Property(m => m.Title)
            .IsRequired()
            .HasMaxLength(100); 

        builder.Property(m => m.Description)
            .IsRequired()
            .HasMaxLength(500); 

        builder.Property(m => m.Durations)
            .IsRequired();

        builder.Property(m => m.Genre)
            .IsRequired();

    }
}

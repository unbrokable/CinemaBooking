using CinemaBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBooking.Infrastructure.Data.Configurations;

public class TheaterConfiguration : IEntityTypeConfiguration<Theater>
{
    public void Configure(EntityTypeBuilder<Theater> builder)
    {
        builder.HasKey(t => t.Id);

        builder.HasIndex(m => m.Name)
            .IsUnique();

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(100); 

        builder.HasMany(t => t.Showtimes)
            .WithOne(st => st.Theater)
            .HasForeignKey(st => st.TheaterId);

        builder.HasMany(t => t.Seats)
            .WithOne(s => s.Theater)
            .HasForeignKey(s => s.TheaterId);
    }
}

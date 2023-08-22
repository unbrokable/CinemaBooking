using CinemaBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBooking.Infrastructure.Data.Configurations;

public class ShowtimeConfiguration : IEntityTypeConfiguration<Showtime>
{
    public void Configure(EntityTypeBuilder<Showtime> builder)
    {
        builder.HasKey(st => st.Id);

        builder.Property(st => st.DateTime)
            .IsRequired();

        builder.HasOne(st => st.Movie)
            .WithMany(m => m.Showtimes)
            .HasForeignKey(st => st.MovieId)
            .OnDelete(DeleteBehavior.Cascade); 

        builder.HasOne(st => st.Theater)
            .WithMany(t => t.Showtimes)
            .HasForeignKey(st => st.TheaterId)
            .OnDelete(DeleteBehavior.Cascade); 

        builder.HasMany(st => st.Bookings)
            .WithOne(b => b.Showtime)
            .HasForeignKey(b => b.ShowtimeId);

        builder.HasMany(st => st.ShowSeats)
            .WithOne(ss => ss.Showtime)
            .HasForeignKey(ss => ss.ShowtimeId);
    }
}

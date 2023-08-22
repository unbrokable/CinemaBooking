using CinemaBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBooking.Infrastructure.Data.Configurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Status)
            .IsRequired()
            .HasMaxLength(50); 

        builder.HasOne(b => b.Showtime)
            .WithMany(st => st.Bookings)
            .HasForeignKey(b => b.ShowtimeId)
            .OnDelete(DeleteBehavior.Cascade); 

        builder.HasMany(b => b.Seats)
            .WithOne(ss => ss.Booking)
            .HasForeignKey(ss => ss.BookingId);

    }
}

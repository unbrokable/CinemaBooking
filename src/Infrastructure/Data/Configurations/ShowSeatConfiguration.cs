using CinemaBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBooking.Infrastructure.Data.Configurations;

public class ShowSeatConfiguration : IEntityTypeConfiguration<ShowSeat>
{
    public void Configure(EntityTypeBuilder<ShowSeat> builder)
    {
        builder.HasKey(ss => ss.Id);

        builder.Property(ss => ss.IsReserved)
            .IsRequired();

        builder.Property(ss => ss.Price)
            .IsRequired();

        builder.HasOne(ss => ss.Seat)
            .WithMany(ts => ts.ShowSeats)
            .HasForeignKey(ss => ss.TheaterSeatId)
            .OnDelete(DeleteBehavior.Cascade); 

        builder.HasOne(ss => ss.Showtime)
            .WithMany(st => st.ShowSeats)
            .HasForeignKey(ss => ss.ShowtimeId)
            .OnDelete(DeleteBehavior.Cascade); 

        builder.HasOne(ss => ss.Booking)
            .WithMany(b => b.Seats)
            .HasForeignKey(ss => ss.BookingId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}

using CinemaBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBooking.Infrastructure.Data.Configurations;

public class TheaterSeatConfiguration : IEntityTypeConfiguration<TheaterSeat>
{
    public void Configure(EntityTypeBuilder<TheaterSeat> builder)
    {
        builder.HasKey(ts => ts.Id);

        builder.Property(ts => ts.SeatRow)
            .IsRequired();

        builder.Property(ts => ts.SeatColumn)
            .IsRequired();

        builder.HasOne(ts => ts.Theater)
            .WithMany(t => t.Seats)
            .HasForeignKey(ts => ts.TheaterId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

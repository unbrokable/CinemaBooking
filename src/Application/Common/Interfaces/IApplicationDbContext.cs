namespace CinemaBooking.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Account> Accounts { get; }

    DbSet<User> Users { get; }

    DbSet<Movie> Movies { get; }

    DbSet<Theater> Theaters { get; }

    DbSet<Showtime> Showtimes { get; }

    DbSet<Booking> Bookings { get; }

    DbSet<TheaterSeat> TheaterSeats { get; }

    DbSet<ShowSeat> ShowSeats { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}

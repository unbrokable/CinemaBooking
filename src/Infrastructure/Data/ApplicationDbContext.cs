using System.Reflection;
using CinemaBooking.Application.Common.Interfaces;
using CinemaBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Account> Accounts => Set<Account>();
        
    public DbSet<User> Users => Set<User>();

    public DbSet<Movie> Movies => Set<Movie>();

    public DbSet<Theater> Theaters => Set<Theater>();

    public DbSet<Showtime> Showtimes => Set<Showtime>();

    public DbSet<Booking> Bookings => Set<Booking>();

    public DbSet<TheaterSeat> TheaterSeats => Set<TheaterSeat>();

    public DbSet<ShowSeat> ShowSeats => Set<ShowSeat>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}

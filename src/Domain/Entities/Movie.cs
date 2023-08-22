namespace CinemaBooking.Domain.Entities;

public class Movie : BaseAuditableEntity
{
    public required string Title { get; set; }

    public required string Description { get; set; }

    public TimeSpan Durations { get; set; }

    public MovieGenre Genre { get; set; }

    public ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
}

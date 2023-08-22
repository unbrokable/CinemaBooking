using CinemaBooking.Domain.Enums;

namespace CinemaBooking.Application.Movies.Queries.GetMovies;

public class MovieDto
{
    public int Id { get; set; }

    public required string Title { get; set; }

    public required string Description { get; set; }

    public TimeSpan Durations { get; set; }

    public MovieGenre Genre { get; set; }
}

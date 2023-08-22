using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaBooking.Application.Theaters.Queries.GetTheaters;

public class TheaterDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public IEnumerable<SeatDto> Seats { get; set; } = Enumerable.Empty<SeatDto>();

    [NotMapped]
    public int SeatsCount => Seats.Count();
}

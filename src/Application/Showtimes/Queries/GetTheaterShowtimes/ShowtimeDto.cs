using CinemaBooking.Application.Showtimes.Commands.CreateShowtime;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaBooking.Application.Showtimes.Queries.GetTheaterShowtimes;

public class ShowtimeDto
{
    public int Id { get; set; }

    public DateTimeOffset DateTime { get; set; }

    public int MovieId { get; set; }

    public int TheaterId { get; set; }

    public IEnumerable<ShowSeatGetDto> Seats { get; set; } = Enumerable.Empty<ShowSeatGetDto>();

    [NotMapped]
    public int AvailableSeatsCount => Seats.Where(s => !s.IsReserved).Count();
}

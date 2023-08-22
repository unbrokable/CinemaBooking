using CinemaBooking.Application.Common.Model;

namespace CinemaBooking.Application.Showtimes.Commands.CreateShowtime;

public record CreateShowtimeCommand : IRequest<CreatedResponse>
{
    public DateTimeOffset DateTime { get; set; }

    public int MovieId { get; set; }

    public int TheaterId { get; set; }

    /// <summary>
    /// Gets or sets available seats id in theater.
    /// </summary>
    public IEnumerable<ShowSeatCreateDto> AvailableSeats { get; set; } = Enumerable.Empty<ShowSeatCreateDto>();
}

public class CreateShowtimeCommandHandler : IRequestHandler<CreateShowtimeCommand, CreatedResponse>
{
    private readonly IApplicationDbContext _context;

    public CreateShowtimeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CreatedResponse> Handle(CreateShowtimeCommand request, CancellationToken cancellationToken)
    {

        if (!await _context.Movies.AnyAsync(m => m.Id == request.MovieId))
        {
            throw new ArgumentException($"Can't find MovieId with this value {request.MovieId}");
        }

        if (!await _context.Theaters.AnyAsync(m => m.Id == request.TheaterId))
        {
            throw new ArgumentException($"Can't find TheaterId with this value {request.TheaterId}");
        }

        IEnumerable<int> seats = await _context.TheaterSeats
            .Where(s => s.TheaterId == request.TheaterId)
            .Select(s => s.Id)
            .ToListAsync();

        IEnumerable<int> invalidSeats = request.AvailableSeats.Select(s => s.TheaterSeatId).Intersect(seats);

        if(invalidSeats.Count() != request.AvailableSeats.Count()) 
        {
            throw new ArgumentException($"Ivalid seats id for theater. Valid values: {string.Join(",", seats)}");
        }

        var entity = new Showtime
        {
            DateTime = request.DateTime,
            MovieId = request.MovieId,
            TheaterId = request.TheaterId,
            ShowSeats = request.AvailableSeats.Select(x => new ShowSeat { 
                TheaterSeatId = x.TheaterSeatId,
                Price = x.Price,
            }).ToList(),
        };

        _context.Showtimes.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return new CreatedResponse { Id = entity.Id };
    }
}

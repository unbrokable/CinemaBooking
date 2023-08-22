using AutoMapper;

namespace CinemaBooking.Application.Showtimes.Queries.GetTheaterShowtimes;

public record GetTheaterShowtimesCommand : IRequest<IEnumerable<ShowtimeDto>>
{
    public int TheaterId { get; set; }
}

public class GetTheaterShowtimesQueryHandler : IRequestHandler<GetTheaterShowtimesCommand, IEnumerable<ShowtimeDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTheaterShowtimesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ShowtimeDto>> Handle(GetTheaterShowtimesCommand request, CancellationToken cancellationToken)
    {
        IEnumerable<Showtime> showtimes = await _context
            .Showtimes
            .Include(s => s.ShowSeats)
            .ToListAsync();

        return _mapper.Map<IEnumerable<ShowtimeDto>>(showtimes);
    }
}

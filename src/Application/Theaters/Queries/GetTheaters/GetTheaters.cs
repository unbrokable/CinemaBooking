using AutoMapper;

namespace CinemaBooking.Application.Theaters.Queries.GetTheaters;

public record GetTheatersQuery : IRequest<IEnumerable<TheaterDto>>;

public class GetTheatersQueryHandler : IRequestHandler<GetTheatersQuery, IEnumerable<TheaterDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTheatersQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TheaterDto>> Handle(GetTheatersQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Theater> theaters = await _context
            .Theaters
            .Include(t => t.Seats)
            .ToListAsync();

        return _mapper.Map<IEnumerable<TheaterDto>>(theaters);     
    }
}

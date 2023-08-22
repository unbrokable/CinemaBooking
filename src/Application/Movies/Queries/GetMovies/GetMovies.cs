using AutoMapper;

namespace CinemaBooking.Application.Movies.Queries.GetMovies;

public record GetMoviesQuery : IRequest<IEnumerable<MovieDto>>;

public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, IEnumerable<MovieDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMoviesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MovieDto>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
    {
        return _mapper
            .Map<IEnumerable<MovieDto>>(await _context.Movies.ToListAsync());     
    }
}

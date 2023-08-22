using CinemaBooking.Application.Common.Model;
using CinemaBooking.Domain.Enums;

namespace CinemaBooking.Application.Movies.Commands.CreateMovie;

public record CreateMovieCommand : IRequest<CreatedResponse>
{
    public required string Title { get; set; }

    public required string Description { get; set; }

    public TimeSpan Durations { get; set; }

    public MovieGenre Genre { get; set; }
}

public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, CreatedResponse>
{
    private readonly IApplicationDbContext _context;

    public CreateMovieCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CreatedResponse> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var entity = new Movie
        {
            Title = request.Title,
            Description = request.Description,
            Durations = request.Durations,
            Genre = request.Genre,
        };

        _context.Movies.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return new CreatedResponse 
        { 
            Id = entity.Id
        };
    }
}

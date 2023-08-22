using Ardalis.GuardClauses;
using CinemaBooking.Domain.Enums;

namespace CinemaBooking.Application.Movies.Commands.UpdateMovie;

public record UpdateMovieCommand : IRequest
{
    public int Id { get; set; }

    public required string Title { get; set; }

    public required string Description { get; set; }

    public TimeSpan Durations { get; set; }

    public MovieGenre Genre { get; set; }
}

public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateMovieCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Movies
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Title = request.Title;
        entity.Description = request.Description;
        entity.Durations = request.Durations;
        entity.Genre = request.Genre;

        await _context.SaveChangesAsync(cancellationToken);
    }
}

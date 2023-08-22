using Ardalis.GuardClauses;

namespace CinemaBooking.Application.Movies.Commands.DeleteMovie;

public record DeleteMovie(int Id) : IRequest;

public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovie>
{
    private readonly IApplicationDbContext _context;

    public DeleteMovieCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteMovie request, CancellationToken cancellationToken)
    {
        var entity = await _context.Movies
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Movies.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }

}

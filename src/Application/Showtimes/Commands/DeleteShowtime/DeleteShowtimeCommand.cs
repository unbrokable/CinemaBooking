using Ardalis.GuardClauses;

namespace CinemaBooking.Application.Showtimes.Commands.DeleteShowtime;

public record DeleteShowtimeCommand(int Id) : IRequest;

public class DeleteShowtimeCommandHandler : IRequestHandler<DeleteShowtimeCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteShowtimeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteShowtimeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Showtimes
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Showtimes.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }

}

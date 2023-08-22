using Ardalis.GuardClauses;

namespace CinemaBooking.Application.Theaters.Commands.DeleteTheater;

public record DeleteTheaterCommand(int Id) : IRequest;

public class DeleteTheaterCommandHandler : IRequestHandler<DeleteTheaterCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteTheaterCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteTheaterCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Theaters
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Theaters.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }

}

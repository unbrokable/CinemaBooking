using Microsoft.Extensions.Configuration;

namespace CinemaBooking.Application.Bookings.Commands.CancelBooking;

public record CancelBookingCommand(int Id) : IRequest;

public class CancelBookingCommandHandler : IRequestHandler<CancelBookingCommand>
{
    private readonly IApplicationDbContext _context;

    public CancelBookingCommandHandler(IConfiguration configuration, IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(CancelBookingCommand request, CancellationToken cancellationToken)
    {
        var entities = await _context.Bookings
            .Include(b => b.Seats)
            .FirstAsync(b => b.Id == request.Id);

        entities.Status = "Cancelled";
        entities.Seats = entities.Seats.Select(s =>
            {
                s.IsReserved = false;
                return s;
            }).ToList();


        await _context.SaveChangesAsync(cancellationToken);
    }

}

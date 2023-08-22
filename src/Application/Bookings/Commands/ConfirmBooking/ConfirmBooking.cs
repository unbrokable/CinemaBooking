using Ardalis.GuardClauses;

namespace CinemaBooking.Application.Bookings.Commands.ConfirmBooking;

public record ConfirmBookingCommand : IRequest<bool>
{
    public int BookingId { get; set; }
}

public class ConfirmBookingCommandHandler : IRequestHandler<ConfirmBookingCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public ConfirmBookingCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(ConfirmBookingCommand request, CancellationToken cancellationToken)
    {
        Booking? entity = _context.Bookings.FirstOrDefault(b => b.Id == request.BookingId);

        Guard.Against.Null(entity, nameof(request.BookingId));

        entity.Status = "Confirmed";

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
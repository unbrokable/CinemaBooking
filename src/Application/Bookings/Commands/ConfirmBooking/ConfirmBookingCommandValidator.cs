using FluentValidation;

namespace CinemaBooking.Application.Bookings.Commands.ConfirmBooking;

public class ConfirmBookingCommandValidator : AbstractValidator<ConfirmBookingCommand>
{
    public ConfirmBookingCommandValidator()
    {
        RuleFor(v => v.BookingId)
             .GreaterThan(0);
    }
}

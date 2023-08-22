using FluentValidation;

namespace CinemaBooking.Application.Bookings.Commands.CreateBooking;

public class CreateBookingCommandValidator : AbstractValidator<CreateBookingCommand>
{
    public CreateBookingCommandValidator()
    {
        RuleFor(v => v.ShowtimeId)
             .GreaterThan(0);
    }
}

using FluentValidation;

namespace CinemaBooking.Application.Showtimes.Commands.CreateShowtime;

public class CreateShowtimeCommandValidator : AbstractValidator<CreateShowtimeCommand>
{
    public CreateShowtimeCommandValidator()
    {
        RuleFor(v => v.TheaterId)
            .GreaterThan(0)
            .WithMessage("Number of theater must be greater than 0.");

        RuleFor(v => v.MovieId)
           .GreaterThan(0)
           .WithMessage("Number of movie id must be greater than 0.");
    }
}

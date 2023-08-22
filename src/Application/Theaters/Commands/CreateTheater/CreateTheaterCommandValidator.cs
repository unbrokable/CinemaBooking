using FluentValidation;

namespace CinemaBooking.Application.Theaters.Commands.CreateTheater;

public class CreateTheaterCommandValidator : AbstractValidator<CreateTheaterCommand>
{
    public CreateTheaterCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(200)
            .NotEmpty();

        RuleFor(v => v.SeatRows)
            .GreaterThan(0)
            .WithMessage("Number of seat rows must be greater than 0.");

        RuleFor(v => v.SeatColumns)
           .GreaterThan(0)
           .WithMessage("Number of seat columns must be greater than 0.");
    }
}

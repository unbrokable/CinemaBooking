using FluentValidation;

namespace CinemaBooking.Application.Movies.Commands.CreateMovie;

public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
{
    public CreateMovieCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();

        RuleFor(v => v.Description)
         .MaximumLength(200)
         .NotEmpty();
    }
}

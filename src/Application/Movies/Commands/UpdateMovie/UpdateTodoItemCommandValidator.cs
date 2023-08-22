using FluentValidation;

namespace CinemaBooking.Application.Movies.Commands.UpdateMovie;

public class UpdateTodoItemCommandValidator : AbstractValidator<UpdateMovieCommand>
{
    public UpdateTodoItemCommandValidator()
    {
        RuleFor(v => v.Title)
          .MaximumLength(200)
          .NotEmpty();

        RuleFor(v => v.Description)
         .MaximumLength(200)
         .NotEmpty();
    }
}

using CinemaBooking.Application.Common.Models;

namespace CinemaBooking.Application.Accounts.Commands
{
    public record RegisterAccountCommand : IRequest<AuthorizationResponse>
    {
        public required string Email { get; init; }
        public required string Password { get; init; }
    }

    public class RegisterAccountCommandHandler : IRequestHandler<RegisterAccountCommand, AuthorizationResponse>
    {
        private readonly IApplicationDbContext context;

        private readonly IIdentityService identityService;

        public RegisterAccountCommandHandler(IApplicationDbContext context, IIdentityService identityService)
        {
            this.context = context;
            this.identityService = identityService;
        }

        public async Task<AuthorizationResponse> Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
        {
            Account entity = new ()
            {
                Password = request.Password,
                User = new ()
                {
                    Email = request.Email,
                }
            };

            context.Accounts.Add(entity);

            await context.SaveChangesAsync(cancellationToken);

            return await identityService.AuthorizeAsync(entity);
        }
    }

}

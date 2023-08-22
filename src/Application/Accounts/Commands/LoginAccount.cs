using CinemaBooking.Application.Common.Models;

namespace CinemaBooking.Application.Accounts.Commands
{
    public record LoginAccountCommand : IRequest<AuthorizationResponse>
    {
        public required string Email { get; init; }
        public required string Password { get; init; }
    }

    public class LoginAccountCommandHandler : IRequestHandler<LoginAccountCommand, AuthorizationResponse>
    {
        private readonly IApplicationDbContext context;

        private readonly IIdentityService identityService;

        public LoginAccountCommandHandler(IApplicationDbContext context, IIdentityService identityService)
        {
            this.context = context;
            this.identityService = identityService;
        }

        public async Task<AuthorizationResponse> Handle(LoginAccountCommand request, CancellationToken cancellationToken)
        {
            Account? entity = context
                .Accounts
                .Include(a => a.User)
                .FirstOrDefault(a => a.Password == request.Password && a.User.Email == request.Email);

            if(entity is null) 
            {
                throw new ArgumentException("Can't find specific user. Email or password is invalid");
            }

            return await identityService.AuthorizeAsync(entity);
        }
    }

}

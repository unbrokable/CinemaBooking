using CinemaBooking.Application.Common.Models;
using CinemaBooking.Domain.Entities;

namespace CinemaBooking.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<AuthorizationResponse> AuthorizeAsync(Account account);
    }
}

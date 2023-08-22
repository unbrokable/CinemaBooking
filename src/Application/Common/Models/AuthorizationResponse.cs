namespace CinemaBooking.Application.Common.Models
{
    public class AuthorizationResponse
    {
        public required string Jwt { get; set; }

        public DateTimeOffset ExpirationDate { get; set; }
    }
}

namespace CinemaBooking.Domain.Entities
{
    public class Account : BaseAuditableEntity
    {
        public User? User { get; set; }

        public required string Password { get; set; }
    }
}

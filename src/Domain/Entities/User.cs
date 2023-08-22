namespace CinemaBooking.Domain.Entities
{
    public class User : BaseAuditableEntity
    {
        public required string Email { get; set; }

        public int AccountId  { get; set; }
        public Account? Account { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}

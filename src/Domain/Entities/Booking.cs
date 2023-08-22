namespace CinemaBooking.Domain.Entities
{
    public class Booking : BaseAuditableEntity
    {
        public required string Status { get; set; }

        // Todo: add whem Authentication will be implemented
        //public int UserId { get; set; }
        //public required User User { get; set; }

        public int ShowtimeId { get; set; }
        public Showtime? Showtime { get; set; }

        public ICollection<ShowSeat> Seats { get; set; } = new List<ShowSeat>();
    }
}

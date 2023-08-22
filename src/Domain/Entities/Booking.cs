namespace CinemaBooking.Domain.Entities
{
    public class Booking : BaseAuditableEntity
    {
        public required string Status { get; set; }

        //public int UserId { get; set; }
        //public required User User { get; set; }

        public int ShowtimeId { get; set; }
        public Showtime? Showtime { get; set; }

        public ICollection<ShowSeat> Seats { get; set; } = new List<ShowSeat>();
    }
}

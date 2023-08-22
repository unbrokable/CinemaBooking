namespace CinemaBooking.Domain.Entities
{
    public class Showtime : BaseAuditableEntity
    {
        public DateTimeOffset DateTime { get; set; }

        public int MovieId { get; set; }
        public Movie? Movie { get; set; }

        public int TheaterId { get; set; }
        public Theater? Theater { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        public ICollection<ShowSeat> ShowSeats { get; set; } = new List<ShowSeat>();
    }
}

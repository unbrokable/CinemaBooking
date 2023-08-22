namespace CinemaBooking.Domain.Entities
{
    public class Theater : BaseAuditableEntity
    {
        public required string Name { get; set; }

        public ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();

        public ICollection<TheaterSeat> Seats { get; set; } = new List<TheaterSeat>();
    }
}

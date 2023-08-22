namespace CinemaBooking.Domain.Entities
{
    public class ShowSeat : BaseAuditableEntity
    {
        public bool IsReserved { get; set; }

        public decimal Price { get; set; }

        public int TheaterSeatId { get; set; }
        public TheaterSeat? Seat { get; set; }

        public int ShowtimeId { get; set; }
        public Showtime? Showtime { get; set; }

        public int? BookingId { get; set; }
        public Booking? Booking { get; set; }
    }
}

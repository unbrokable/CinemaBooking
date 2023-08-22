namespace CinemaBooking.Domain.Entities
{
    public class TheaterSeat : BaseAuditableEntity
    {
        public int SeatRow { get; set; }

        public int SeatColumn { get; set; }

        public Theater? Theater { get; set; }

        public int TheaterId { get; set; }

        public ICollection<ShowSeat> ShowSeats { get; set; } = new List<ShowSeat>();

        // Todo: add type.
    }
}

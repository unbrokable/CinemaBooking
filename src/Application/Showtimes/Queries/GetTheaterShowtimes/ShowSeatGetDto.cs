namespace CinemaBooking.Application.Showtimes.Queries.GetTheaterShowtimes
{
    public class ShowSeatGetDto
    {
        public bool IsReserved { get; set; }
        public decimal Price { get; set; }
        public int TheaterSeatId { get; set; }
    }
}

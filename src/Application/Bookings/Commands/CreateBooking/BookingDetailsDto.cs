namespace CinemaBooking.Application.Bookings.Commands.CreateBooking
{
    public class BookingDetailsDto
    {
        public int Id { get; set; }
        public DateTimeOffset DateTime { get; set; }
        public decimal TotalPrice{ get; set; }
        public required MovieDetailsDto Movie { get; set; }
        public IEnumerable<int> ReservedSeatsId { get; set; }  = Enumerable.Empty<int>();
    }
}

using CinemaBooking.Application.Bookings.Commands.CancelBooking;

namespace CinemaBooking.Application.BackgroundJobs
{
    public class BookingWatcherJob 
    {
        private readonly ISender sender;

        public BookingWatcherJob(ISender sender) 
        {
            this.sender = sender;
        }

        public async Task StartAsync(int id, CancellationToken cancellationToken)
        {
            await sender.Send(new CancelBookingCommand(id));
        }
    }
}

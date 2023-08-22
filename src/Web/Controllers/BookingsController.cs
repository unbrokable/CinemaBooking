using CinemaBooking.Application.Bookings.Commands.ConfirmBooking;
using CinemaBooking.Application.Bookings.Commands.CreateBooking;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBooking.Web.Controllers
{
    /// <summary>
    /// Controller for managing bookings.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly ISender _sender;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingsController"/> class.
        /// </summary>
        /// <param name="sender">The sender service for sending booking commands.</param>
        public BookingsController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Creates a new booking.
        /// </summary>
        /// <param name="command">The booking command.</param>
        /// <returns>The result of the booking creation.</returns>
        [HttpPost(Name = "Create Booking")]
        public async Task<IActionResult> Create([FromBody] CreateBookingCommand command)
        {
            return Created(string.Empty, await _sender.Send(command));
        }

        /// <summary>
        /// Confirms a booking.
        /// </summary>
        /// <param name="command">The confirmation command.</param>
        /// <returns>The result of the confirmation.</returns>
        [HttpPut("confirm", Name = "Confirm Booking")]
        public async Task<IActionResult> Confirm(ConfirmBookingCommand command)
        {
            await _sender.Send(command);

            return Ok();
        }
    }
}
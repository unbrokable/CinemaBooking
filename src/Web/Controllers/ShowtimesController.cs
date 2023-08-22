using CinemaBooking.Application.Showtimes.Commands.CreateShowtime;
using CinemaBooking.Application.Showtimes.Commands.DeleteShowtime;
using CinemaBooking.Application.Showtimes.Queries.GetTheaterShowtimes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBooking.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowtimesController : ControllerBase
    {
        private readonly ISender _sender;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShowtimesController"/> class.
        /// </summary>
        /// <param name="sender">The sender service for sending showtime-related commands.</param>
        public ShowtimesController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Retrieves a list of showtimes for a specific theater.
        /// </summary>
        /// <param name="theaterId">The ID of the theater.</param>
        /// <returns>The list of showtimes for the specified theater.</returns>
        [HttpGet("~/Theaters/{theaterId}/showtimes", Name = "Get Theater Showtimes")]
        public async Task<IActionResult> Get(int theaterId)
        {
            return Ok(await _sender.Send(new GetTheaterShowtimesCommand()
            {
                TheaterId = theaterId
            }));
        }

        /// <summary>
        /// Creates a new showtime.
        /// </summary>
        /// <param name="command">The showtime creation command.</param>
        /// <returns>The result of the showtime creation.</returns>
        [HttpPost(Name = "Create Showtime")]
        public async Task<IActionResult> Create([FromBody] CreateShowtimeCommand command)
        {
            return Created(string.Empty, await _sender.Send(command));
        }

        /// <summary>
        /// Deletes a showtime.
        /// </summary>
        /// <param name="command">The showtime deletion command.</param>
        /// <returns>No content response.</returns>
        [HttpDelete(Name = "Delete Showtime")]
        public async Task<IActionResult> Delete(DeleteShowtimeCommand command)
        {
            await _sender.Send(command);

            return NoContent();
        }
    }
}
using CinemaBooking.Application.Theaters.Commands.CreateTheater;
using CinemaBooking.Application.Theaters.Commands.DeleteTheater;
using CinemaBooking.Application.Theaters.Queries.GetTheaters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBooking.Web.Controllers
{
    /// <summary>
    /// Controller for managing theaters (Theater Management).
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class TheatersController : ControllerBase
    {
        private readonly ISender _sender;

        /// <summary>
        /// Initializes a new instance of the <see cref="TheatersController"/> class.
        /// </summary>
        /// <param name="sender">The sender service for sending theater-related commands.</param>
        public TheatersController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Retrieves a list of theaters.
        /// </summary>
        /// <returns>The list of theaters.</returns>
        [HttpGet(Name = "Get Theaters")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _sender.Send(new GetTheatersQuery()));
        }

        /// <summary>
        /// Creates a new theater.
        /// </summary>
        /// <param name="command">The theater creation command.</param>
        /// <returns>The result of the theater creation.</returns>
        [HttpPost(Name = "Create Theater")]
        public async Task<IActionResult> Create([FromBody] CreateTheaterCommand command)
        {
            return Created(string.Empty, await _sender.Send(command));
        }

        /// <summary>
        /// Deletes a theater.
        /// </summary>
        /// <param name="command">The theater deletion command.</param>
        /// <returns>No content response.</returns>
        [HttpDelete(Name = "Delete Theater")]
        public async Task<IActionResult> Delete(DeleteTheaterCommand command)
        {
            await _sender.Send(command);

            return NoContent();
        }
    }
}
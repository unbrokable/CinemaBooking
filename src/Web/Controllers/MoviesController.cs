using CinemaBooking.Application.Movies.Commands.CreateMovie;
using CinemaBooking.Application.Movies.Commands.DeleteMovie;
using CinemaBooking.Application.Movies.Commands.UpdateMovie;
using CinemaBooking.Application.Movies.Queries.GetMovies;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBooking.Web.Controllers
{
    /// <summary>
    /// Controller for managing movies (Movie Management).
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly ISender _sender;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoviesController"/> class.
        /// </summary>
        /// <param name="sender">The sender service for sending movie-related commands.</param>
        public MoviesController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Retrieves a list of movies.
        /// </summary>
        /// <returns>The list of movies.</returns>
        [HttpGet(Name = "Get Movies")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _sender.Send(new GetMoviesQuery()));
        }

        /// <summary>
        /// Creates a new movie.
        /// </summary>
        /// <param name="command">The movie creation command.</param>
        /// <returns>The result of the movie creation.</returns>
        [HttpPost(Name = "Create Movie")]
        public async Task<IActionResult> Create([FromBody] CreateMovieCommand command)
        {
            return Created(string.Empty, await _sender.Send(command));
        }

        /// <summary>
        /// Deletes a movie.
        /// </summary>
        /// <param name="command">The movie deletion command.</param>
        /// <returns>No content response.</returns>
        [HttpDelete(Name = "Delete Movie")]
        public async Task<IActionResult> Delete(DeleteMovie command)
        {
            await _sender.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Updates a movie.
        /// </summary>
        /// <param name="command">The movie update command.</param>
        /// <returns>No content response.</returns>
        [HttpPut(Name = "Update Movie")]
        public async Task<IActionResult> Update(UpdateMovieCommand command)
        {
            await _sender.Send(command);

            return NoContent();
        }
    }
}
using AzureBlobStorageWebAPI.API.Controllers.SeedWork;
using AzureBlobStorageWebAPI.Application.MovieAppLayer.UseCases.MovieUseCases.CreateMovie;
using AzureBlobStorageWebAPI.Application.MovieAppLayer.UseCases.MovieUseCases.DeleteMovie;
using AzureBlobStorageWebAPI.Application.MovieAppLayer.UseCases.MovieUseCases.GetMovieById;
using AzureBlobStorageWebAPI.Application.MovieAppLayer.UseCases.MovieUseCases.GetMovies;
using AzureBlobStorageWebAPI.Application.MovieAppLayer.UseCases.MovieUseCases.UpdateMovie;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AzureBlobStorageWebAPI.API.Controllers
{
    public class MoviesController : AzureBlobStorageWebAPIBaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetMoviesQuery query)
        {
            var movies = await Mediator.Send(query);
            return Ok(movies);
        }

        [HttpGet("{id}")] //movies/id
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var movie = await Mediator.Send(new GetMovieByIdQuery { Id = id });
            if (movie == null)
            {
                return APIErrors.RecordNotFound;
            }

            return Ok(movie);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateMovieCommand command)
        {
            var movie = await Mediator.Send(command);
            return CreatedAtAction("Get", new { id = movie.Id }, movie);
        }

        [HttpPut("{id}")]//movies/id
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdateMovieCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            var movie = await Mediator.Send(command);
            return Ok(movie);
        }

        [HttpDelete("{id}")]//movies/id
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var movie = await Mediator.Send(new DeleteMovieCommand { Id = id });

            if (movie == null)
            {
                return APIErrors.RecordNotFound;
            }

            return Ok(movie);
        }
    }
}

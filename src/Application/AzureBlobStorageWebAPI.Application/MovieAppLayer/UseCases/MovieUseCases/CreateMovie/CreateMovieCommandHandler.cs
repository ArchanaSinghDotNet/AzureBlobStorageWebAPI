using MediatR;
using AzureBlobStorageWebAPI.Application.MovieAppLayer.DTOs;
using AzureBlobStorageWebAPI.Application.MovieAppLayer.Interfaces;
using AzureBlobStorageWebAPI.Domain.MovieDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AzureBlobStorageWebAPI.Application.MovieAppLayer.UseCases.MovieUseCases.CreateMovie
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, MovieDto>
    {
        private readonly IMovieRepository _movieRepository;

        public CreateMovieCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<MovieDto> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = new Movie
            {
                Id = Guid.NewGuid(),
                Text = request.Text,
                Images = request.Images
            };

            var newMovie = await _movieRepository.AddAsync(movie);

            var movieDto = new MovieDto
            {
                Id = newMovie.Id,
                Text = newMovie.Text,
                Images = newMovie.Images
            };

            return movieDto;
        }
    }
}

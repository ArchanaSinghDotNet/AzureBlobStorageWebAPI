using AzureBlobStorageWebAPI.Application.MovieAppLayer.DTOs;
using AzureBlobStorageWebAPI.Application.MovieAppLayer.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AzureBlobStorageWebAPI.Application.MovieAppLayer.UseCases.MovieUseCases.GetMovies
{
    public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, IEnumerable<MovieDto>>
    {
        private readonly IMovieRepository _movieRepository;

        public GetMoviesQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<MovieDto>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            var movies = await _movieRepository.GetAsync();

            var moviesDto = movies.Select(x => new MovieDto { Id = x.Id, Text = x.Text, Images = x.Images });

            return moviesDto;
        }
    }
}

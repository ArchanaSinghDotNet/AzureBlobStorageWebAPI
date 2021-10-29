using MediatR;
using AzureBlobStorageWebAPI.Application.MovieAppLayer.DTOs;
using AzureBlobStorageWebAPI.Application.MovieAppLayer.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace AzureBlobStorageWebAPI.Application.MovieAppLayer.UseCases.MovieUseCases.GetMovieById
{
    public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, MovieDto>
    {
        private readonly IMovieRepository _movieRepository;

        public GetMovieByIdQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<MovieDto> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetByIdAsync(request.Id);
            if (movie == null)
            {
                return null;
            }

            var movieDto = new MovieDto { Id = movie.Id, Text = movie.Text, Images = movie.Images };

            return movieDto;
        }
    }
}

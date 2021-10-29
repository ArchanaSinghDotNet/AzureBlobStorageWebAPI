using MediatR;
using AzureBlobStorageWebAPI.Application.MovieAppLayer.DTOs;
using AzureBlobStorageWebAPI.Application.MovieAppLayer.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace AzureBlobStorageWebAPI.Application.MovieAppLayer.UseCases.MovieUseCases.UpdateMovie
{
    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, MovieDto>
    {
        private readonly IMovieRepository _movieRepository;

        public UpdateMovieCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<MovieDto> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetByIdAsync(request.Id);

            movie.Text = request.Text;

            var updatedmovie = await _movieRepository.UpdateAsync(movie);

            return new MovieDto { Id = updatedmovie.Id, Text = updatedmovie.Text, Images = updatedmovie.Images };
        }
    }
}

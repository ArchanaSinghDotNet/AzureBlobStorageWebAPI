using MediatR;
using AzureBlobStorageWebAPI.Application.MovieAppLayer.DTOs;
using AzureBlobStorageWebAPI.Application.MovieAppLayer.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace AzureBlobStorageWebAPI.Application.MovieAppLayer.UseCases.MovieUseCases.DeleteMovie
{
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, MovieDto>
    {
        private readonly IMovieRepository _movieRepository;

        public DeleteMovieCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<MovieDto> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var deletedmovie = await _movieRepository.RemoveAsync(request.Id);
            if (deletedmovie == null)
            {
                return null;
            }

            var movieDto = new MovieDto { Id = deletedmovie.Id, Text = deletedmovie.Text, Images = deletedmovie.Images };

            return movieDto;
        }
    }
}

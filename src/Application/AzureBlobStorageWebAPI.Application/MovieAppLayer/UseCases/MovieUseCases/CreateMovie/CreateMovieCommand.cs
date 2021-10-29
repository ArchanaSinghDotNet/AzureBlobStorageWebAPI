using MediatR;
using AzureBlobStorageWebAPI.Application.MovieAppLayer.DTOs;

namespace AzureBlobStorageWebAPI.Application.MovieAppLayer.UseCases.MovieUseCases.CreateMovie
{
    public class CreateMovieCommand : IRequest<MovieDto>
    {
        public string Text { get; set; }
        public string[] Images { get; set; }
    }
}

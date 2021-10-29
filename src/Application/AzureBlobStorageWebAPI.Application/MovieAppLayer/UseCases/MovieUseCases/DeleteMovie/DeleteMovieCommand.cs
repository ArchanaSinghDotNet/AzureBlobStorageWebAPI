using MediatR;
using AzureBlobStorageWebAPI.Application.MovieAppLayer.DTOs;
using System;

namespace AzureBlobStorageWebAPI.Application.MovieAppLayer.UseCases.MovieUseCases.DeleteMovie
{
    public class DeleteMovieCommand : IRequest<MovieDto>
    {
        public Guid Id { get; set; }
    }
}

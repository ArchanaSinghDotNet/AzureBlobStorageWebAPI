using MediatR;
using AzureBlobStorageWebAPI.Application.MovieAppLayer.DTOs;
using System;

namespace AzureBlobStorageWebAPI.Application.MovieAppLayer.UseCases.MovieUseCases.GetMovieById
{
    public class GetMovieByIdQuery : IRequest<MovieDto>
    {
        public Guid Id { get; set; }
    }
}

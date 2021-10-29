using MediatR;
using AzureBlobStorageWebAPI.Application.MovieAppLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBlobStorageWebAPI.Application.MovieAppLayer.UseCases.MovieUseCases.GetMovies
{
    public class GetMoviesQuery : IRequest<IEnumerable<MovieDto>>
    {
    }
}

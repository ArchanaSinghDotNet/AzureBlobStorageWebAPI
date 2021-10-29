using AzureBlobStorageWebAPI.Domain.MovieDomain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureBlobStorageWebAPI.Application.MovieAppLayer.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAsync();
        Task<Movie> GetByIdAsync(Guid id);
        Task<Movie> AddAsync(Movie movie);
        Task<Movie> UpdateAsync(Movie movie);
        Task<Movie> RemoveAsync(Guid id);
    }
}

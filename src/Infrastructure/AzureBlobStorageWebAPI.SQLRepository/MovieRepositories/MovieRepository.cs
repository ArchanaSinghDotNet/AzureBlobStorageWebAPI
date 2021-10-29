using Microsoft.EntityFrameworkCore;
using AzureBlobStorageWebAPI.Application.MovieAppLayer.Interfaces;
using AzureBlobStorageWebAPI.Domain.MovieDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBlobStorageWebAPI.SQLRepository.MovieRepositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _movieDbContext;

        public MovieRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public async Task<IEnumerable<Movie>> GetAsync()
        {
            return await _movieDbContext.Movies.ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(Guid id)
        {
            return await _movieDbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Movie> AddAsync(Movie movie)
        {
            await _movieDbContext.AddAsync(movie);
            await _movieDbContext.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie> UpdateAsync(Movie movie)
        {
            _movieDbContext.Update(movie);
            await _movieDbContext.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie> RemoveAsync(Guid id)
        {
            var movieToRemove = await GetByIdAsync(id);
            _movieDbContext.Movies.Remove(movieToRemove);
            await _movieDbContext.SaveChangesAsync();
            return movieToRemove;
        }
    }
}

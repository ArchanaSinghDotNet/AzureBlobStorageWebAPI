using Microsoft.Azure.Cosmos;
using AzureBlobStorageWebAPI.Application.MovieAppLayer.Interfaces;
using AzureBlobStorageWebAPI.Domain.MovieDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AzureBlobStorageWebAPI.CosmosRepository.MovieRepositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IMovieCosmosContext _cosmosContext;

        public MovieRepository(IMovieCosmosContext cosmosContext)
        {
            _cosmosContext = cosmosContext;
        }

        public async Task<Movie> AddAsync(Movie Movie)
        {
            var partitionKey = new PartitionKey(Movie.Id.ToString());
            var result = await _cosmosContext.MovieContainer.CreateItemAsync(Movie, partitionKey);
            return result.Resource;
        }

        public async Task<IEnumerable<Movie>> GetAsync()
        {
            var queryDefination = new QueryDefinition("SELECT * FROM Movie");
            var query = _cosmosContext.MovieContainer.GetItemQueryIterator<Movie>(queryDefination);
            
            var result = new List<Movie>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                result.AddRange(response.ToList());
            }

            return result;
        }

        public async Task<Movie> GetByIdAsync(Guid id)
        {
            try
            {
                var partitionKey = new PartitionKey(id.ToString());
                var result = await _cosmosContext.MovieContainer.ReadItemAsync<Movie>(id.ToString(), partitionKey);
                return result.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<Movie> RemoveAsync(Guid id)
        {
            var recordToDelete = await GetByIdAsync(id);  //This is not requred if you dont want to return recod from Remove method

            if (recordToDelete == null)
            {
                return null;
            }

            var partitionKey = new PartitionKey(id.ToString());
            var result = await _cosmosContext.MovieContainer.DeleteItemAsync<Movie>(id.ToString(), partitionKey);
            return recordToDelete;
        }

        public async Task<Movie> UpdateAsync(Movie Movie)
        {
            var partitionKey = new PartitionKey(Movie.Id.ToString());
            var result = await _cosmosContext.MovieContainer.UpsertItemAsync(Movie, partitionKey);
            return result.Resource;
        }
    }
}

using Microsoft.Azure.Cosmos;
using AzureBlobStorageWebAPI.CosmosRepository.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBlobStorageWebAPI.CosmosRepository.MovieRepositories
{
    public class MovieCosmosContext : IMovieCosmosContext
    {
        public MovieCosmosContext(CosmosSettings cosmosSettings)
        {
            CosmosClient _client = new (cosmosSettings.Endpoint, cosmosSettings.Key);

            MovieContainer = _client.GetContainer(cosmosSettings.DatabaseName, cosmosSettings.MovieContainer);
        }
        public Container MovieContainer { get; }
    }
}

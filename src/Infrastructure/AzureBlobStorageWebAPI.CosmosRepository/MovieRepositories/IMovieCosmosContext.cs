using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBlobStorageWebAPI.CosmosRepository.MovieRepositories
{
    public interface IMovieCosmosContext
    {
        Container MovieContainer { get; }
    }
}

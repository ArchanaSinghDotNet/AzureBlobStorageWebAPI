using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AzureBlobStorageWebAPI.Application.MovieAppLayer.Interfaces;
using AzureBlobStorageWebAPI.CosmosRepository.Settings;
using AzureBlobStorageWebAPI.CosmosRepository.MovieRepositories;

namespace AzureBlobStorageWebAPI.CosmosRepository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCosmosRepository(this IServiceCollection services, IConfiguration configuration)
        {
            var cosmosSettings = new CosmosSettings();
            configuration.GetSection(CosmosSettings.SettingName).Bind(cosmosSettings);
            services.AddSingleton(cosmosSettings);

            services.AddSingleton<IMovieCosmosContext, MovieCosmosContext>();

            services.AddScoped<IMovieRepository, MovieRepository>();

            return services;
        }
    }
}

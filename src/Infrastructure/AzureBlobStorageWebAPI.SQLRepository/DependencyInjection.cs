using AzureBlobStorageWebAPI.Application.MovieAppLayer.Interfaces;
using AzureBlobStorageWebAPI.SQLRepository.MovieRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace AzureBlobStorageWebAPI.SQLRepository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSQLRepository(this IServiceCollection services)
        {
            services.AddScoped<MovieDbContext>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            return services;
        }
    }
}

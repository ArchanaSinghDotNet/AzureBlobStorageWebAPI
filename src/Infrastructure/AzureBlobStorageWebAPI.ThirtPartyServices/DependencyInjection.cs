using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AzureBlobStorageWebAPI.Application.CommonAppLayer.Interfaces;
using AzureBlobStorageWebAPI.ThirdPartyServices.AzureServices;
using AzureBlobStorageWebAPI.ThirdPartyServices.Settings;

namespace AzureBlobStorageWebAPI.ThirdPartyServices
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddThirdPartyServices(this IServiceCollection services, IConfiguration configuration)
        {
            var blobStorageSettings = new BlobStorageSettings();
            configuration.GetSection(BlobStorageSettings.SettingName).Bind(blobStorageSettings);

            services.AddSingleton(x => new BlobServiceClient(blobStorageSettings.ConnectionString));

            services.AddScoped<IFileStorageService, BlobStorageService>();

            return services;
        }
    }
}

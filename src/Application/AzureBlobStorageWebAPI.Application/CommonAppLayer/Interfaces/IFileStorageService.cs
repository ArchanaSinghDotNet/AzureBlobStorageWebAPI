using AzureBlobStorageWebAPI.Application.CommonAppLayer.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureBlobStorageWebAPI.Application.CommonAppLayer.Interfaces
{
    public interface IFileStorageService
    {
        Task<UrlsDto> UploadAsync(ICollection<FileDto> files);
    }
}

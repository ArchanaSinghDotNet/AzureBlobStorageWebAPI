using AzureBlobStorageWebAPI.Application.CommonAppLayer.DTOs;
using MediatR;
using System.Collections.Generic;

namespace AzureBlobStorageWebAPI.Application.CommonAppLayer.UseCases.FileStorageUseCases.UploadImages
{
    public class UploadImagesCommand : IRequest<UrlsDto>
    {
        public ICollection<FileDto> Files { get; set; } = new List<FileDto>();
    }
}

using AzureBlobStorageWebAPI.Application.CommonAppLayer.DTOs;
using AzureBlobStorageWebAPI.Application.CommonAppLayer.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AzureBlobStorageWebAPI.Application.CommonAppLayer.UseCases.FileStorageUseCases.UploadImages
{
    public class UploadImagesCommandHandler : IRequestHandler<UploadImagesCommand, UrlsDto>
    {
        private readonly IFileStorageService _fileStorageService;

        public UploadImagesCommandHandler(IFileStorageService fileStorageService)
        {
            _fileStorageService = fileStorageService;
        }

        public async Task<UrlsDto> Handle(UploadImagesCommand request, CancellationToken cancellationToken)
        {
            var urls = await _fileStorageService.UploadAsync(request.Files);
            return urls;
        }
    }
}

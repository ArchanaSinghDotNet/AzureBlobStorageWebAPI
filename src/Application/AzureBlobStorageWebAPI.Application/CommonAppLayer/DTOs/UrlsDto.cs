using System.Collections.Generic;

namespace AzureBlobStorageWebAPI.Application.CommonAppLayer.DTOs
{
    public class UrlsDto
    {
        public ICollection<string> Urls { get; }

        public UrlsDto(ICollection<string> urls)
        {
            Urls = urls;
        }
    }
}

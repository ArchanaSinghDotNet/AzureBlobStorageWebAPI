using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBlobStorageWebAPI.Application.MovieAppLayer.DTOs
{
    public class MovieDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string[] Images { get; set; }
    }
}

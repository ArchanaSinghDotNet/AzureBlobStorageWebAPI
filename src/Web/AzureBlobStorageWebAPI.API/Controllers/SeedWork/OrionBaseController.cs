using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace AzureBlobStorageWebAPI.API.Controllers.SeedWork
{
    [ApiController]
    [Route("api/[controller]")]
    public class AzureBlobStorageWebAPIBaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}

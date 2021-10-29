using MediatR;
using Microsoft.AspNetCore.Mvc;
using AzureBlobStorageWebAPI.API.Controllers.SeedWork;
using AzureBlobStorageWebAPI.Application.AccountAppLayer.UseCases.UserUseCases.GetUserById;
using System.Threading.Tasks;

namespace AzureBlobStorageWebAPI.API.Controllers
{
    
    public class UsersController : AzureBlobStorageWebAPIBaseController
    {
        [HttpGet("{id}")]  //users/id
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var request = new GetUserByIdRequest { Id = id };
            var user = await Mediator.Send(request);
            return Ok(user);
        }
    }
}

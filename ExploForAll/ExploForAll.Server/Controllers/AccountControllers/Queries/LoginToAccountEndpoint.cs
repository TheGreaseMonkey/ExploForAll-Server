using ExploForAll.Server.Interactors.AccountUseCase.Commands.Admin;
using ExploForAll.Server.Interactors.AccountUseCase.Queries.LoginToAccount;
using ExploForAll.Server.Models;
using ExploForAll.Server.Services;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace ExploForAll.Server.Controllers.AccountControllers.Queries
{
    [ApiController]
    [EnableCors]
    public class LoginToAccountEndpoint : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginToAccountEndpoint(IMediator mediator, IConfiguration config)
        {
            _mediator = mediator;

            // Create default Account
            new CreateDefaultAdminService(mediator).CreateDefaultAdmin(new CreateNewAdminAccountRequest()
            {
                Username = config["DefaultAdmin:Username"],
                Alias = config["DefaultAdmin:Alias"],
                Password = config["DefaultAdmin:Password"]
            });
        }

        [HttpPost]
        [Route("/Account/Login")]
        [Produces("application/json")]
        public async Task<IActionResult> LoginToAccount([FromBody] LoginToAccountRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Response response = await _mediator.Send(request);

            return StatusCode((int)response.Status, response);

        }

    }
}

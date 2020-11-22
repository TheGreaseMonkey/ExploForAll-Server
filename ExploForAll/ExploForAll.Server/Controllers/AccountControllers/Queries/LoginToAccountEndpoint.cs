using ExploForAll.Server.Interactors.AccountUseCase.Queries.LoginToAccount;
using ExploForAll.Server.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExploForAll.Server.Controllers.AccountControllers.Queries
{
    [ApiController]
    public class LoginToAccountEndpoint : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginToAccountEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("/Account/Login")]
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

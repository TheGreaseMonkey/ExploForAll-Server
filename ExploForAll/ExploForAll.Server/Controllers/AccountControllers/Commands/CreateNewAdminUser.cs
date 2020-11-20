using ExploForAll.Server.Interactors.AccountUseCase;
using ExploForAll.Server.Interactors.AccountUseCase.Commands.Admin;
using ExploForAll.Server.Models.Account;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExploForAll.Server.Controllers.AccountControllers.Commands
{
    [ApiController]
    public class CreateNewAdminUserEndpoint : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreateNewAdminUserEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = AccountTypes.Admin)]
        [Route("/account/admin")]
        public async Task<IActionResult> CreateNewAdminUsert([FromBody] CreateNewAdminAccountRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Send to the use case
            CreateNewAccountResponse response = await _mediator.Send(request);

            return StatusCode((int)response.Status, response);
        }
    }
}

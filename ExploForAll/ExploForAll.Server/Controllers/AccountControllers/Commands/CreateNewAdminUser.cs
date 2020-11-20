using ExploForAll.Server.Interactors.AccountUseCase;
using ExploForAll.Server.Models.Account;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExploForAll.Server.Controllers.AccountControllers.Commands
{
    [ApiController]
    public class CreateNewAdminUser : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreateNewAdminUser(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = AccountTypes.Admin)]
        [Route("/account/admin")]
        public async Task<IActionResult> CreateNewAdminUserEndpoint([FromBody] CreateNewAdminAccountRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Send to the use case
            CreateNewAccountResponse response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}

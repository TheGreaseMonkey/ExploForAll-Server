﻿using ExploForAll.Server.Interactors.AccountUseCase;
using ExploForAll.Server.Interactors.AccountUseCase.Commands.CreateNewAccount.User;
using ExploForAll.Server.Models.Account;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExploForAll.Server.Controllers.AccountControllers.Commands
{
    [ApiController]
    public class CreateNewUserEndpoint : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreateNewUserEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("/account")]
        [Authorize(Roles = AccountTypes.Admin)]
        public async Task<IActionResult> CreateNewUser([FromBody] CreateNewUserAccountRequest request)
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

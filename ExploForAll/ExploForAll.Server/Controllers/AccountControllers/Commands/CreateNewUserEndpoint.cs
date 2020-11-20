using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    }
}

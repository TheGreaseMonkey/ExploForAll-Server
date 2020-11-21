using ExploForAll.Server.Interactors.AccountUseCase.Commands.Admin;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace ExploForAll.Server.Services
{
    public class CreateDefaultAdminService
    {
        private readonly IMediator _mediator;

        public CreateDefaultAdminService()
        {
        }

        public CreateDefaultAdminService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task CreateDefaultAdmin(CreateNewAdminAccountRequest request)
        {
            if(_mediator == null)
            {
                throw new NullReferenceException("Mediator was null while trying to create default admin account");
            }

            var response = await _mediator.Send(request);
            if(response.Status == Models.ResponseTypes.Created)
            {
                Console.WriteLine($"Created default admin: {request.Username}");
            }
            else
            {
                Console.WriteLine($"Default admin already exists: {request.Username}. Did not create or modify it.");
            }
        }
    }
}

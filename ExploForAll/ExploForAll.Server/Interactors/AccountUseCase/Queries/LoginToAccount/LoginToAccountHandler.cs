using ExploForAll.Server.Models;
using ExploForAll.Server.Models.Account;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace ExploForAll.Server.Interactors.AccountUseCase.Queries.LoginToAccount
{
    public class LoginToAccountHandler : IRequestHandler<LoginToAccountRequest, Response>
    {
        private readonly UserManager<Account> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public LoginToAccountHandler(UserManager<Account> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public Task<Response> Handle(LoginToAccountRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}

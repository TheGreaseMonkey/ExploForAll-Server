using ExploForAll.Server.Helpers.Account;
using ExploForAll.Server.Models.Account;
using ExploForAll.Server.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ExploForAll.Server.Interactors.AccountUseCase.CreateNewAccount
{
    public class CreateNewAdminAccountHandler : IRequestHandler<CreateNewAdminAccountRequest, CreateNewAccountResponse>
    {
        private readonly UserManager<Account> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CreateNewAdminAccountHandler(UserManager<Account> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<CreateNewAccountResponse> Handle(CreateNewAdminAccountRequest request, CancellationToken cancellationToken)
        {
            // Try to fetch an user with this name
            var userExists = _userManager.FindByNameAsync(request.Username);

            if(userExists != null)
            {
                // There already is a user with this name
                return new CreateNewAccountResponse(ResponseTypes.Failed, $"user with name: {request.Username} already exists");
            }

            // User does not yet exist, create one
            Account newAccount = new Account()
            {
                UserName = request.Username,
                NormalizedUserName = request.Alias,
                SecurityStamp = new Guid().ToString()
            };

            var result = await _userManager.CreateAsync(newAccount, request.Password);

            if (!result.Succeeded)
            {
                return new CreateNewAccountResponse(ResponseTypes.Failed, "Error while trying to create new admin account");
            }

            // Add roles to user
            var roleHelper = new AccountRoleHelper(_roleManager);
            await roleHelper.CreateRoleAsync(AccountTypes.Admin);
            await roleHelper.CreateRoleAsync(AccountTypes.User);

            if(await _roleManager.RoleExistsAsync(AccountTypes.User) && await _roleManager.RoleExistsAsync(AccountTypes.Admin))
            {
                List<string> roles = new List<string>
                {
                    AccountTypes.Admin,
                    AccountTypes.User
                };

                await _userManager.AddToRolesAsync(newAccount, roles);
            }

            // Send response
            return new CreateNewAccountResponse(ResponseTypes.Success, $"Account for {request.Username} has been created");
        }
    }
}

using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ExploForAll.Server.Helpers.Account
{
    public class AccountRoleHelper
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountRoleHelper(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task CreateRoleAsync(string role)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}

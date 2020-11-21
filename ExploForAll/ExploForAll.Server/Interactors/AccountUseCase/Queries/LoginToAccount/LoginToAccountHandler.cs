using ExploForAll.Server.Models;
using ExploForAll.Server.Models.Account;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExploForAll.Server.Interactors.AccountUseCase.Queries.LoginToAccount
{
    public class LoginToAccountHandler : IRequestHandler<LoginToAccountRequest, Response>
    {
        private readonly UserManager<Account> _userManager;
        private readonly IConfiguration _configuration;

        public LoginToAccountHandler(UserManager<Account> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<Response> Handle(LoginToAccountRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // Check if the user exists
                var user = await _userManager.FindByNameAsync(request.Username);
                if (user == null)
                {
                    return new Response(ResponseTypes.Unauthorized, "User does not exist");
                }

                // User exists, check if the password matches
                if (!await _userManager.CheckPasswordAsync(user, request.Password))
                {
                    return new Response(ResponseTypes.Unauthorized, "Awww, Looks like something was not right...");
                }

                // Password matches user, create claims
                var userRoles = await _userManager.GetRolesAsync(user);

                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

                // add claims for the roles
                foreach (var role in userRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                // Claims created, create a signing key
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                // Create a token
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:Issuer"],
                    audience: _configuration["JWT:Audience"],
                    expires: DateTime.Now.AddDays(30),
                    claims: claims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha512)
                    );

                // Token has been created
                return new Response(ResponseTypes.Success, new JwtSecurityTokenHandler().WriteToken(token));
            }
            catch(Exception e)
            {
                // Should anything happen... return 401
                return new Response(ResponseTypes.Unauthorized, "Could not sign in");
            }
        }
    }
}

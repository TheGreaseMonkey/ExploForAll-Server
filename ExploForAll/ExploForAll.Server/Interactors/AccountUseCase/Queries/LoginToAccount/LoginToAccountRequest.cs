using ExploForAll.Server.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ExploForAll.Server.Interactors.AccountUseCase.Queries.LoginToAccount
{
    public class LoginToAccountRequest : IRequest<Response>
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }
    }
}

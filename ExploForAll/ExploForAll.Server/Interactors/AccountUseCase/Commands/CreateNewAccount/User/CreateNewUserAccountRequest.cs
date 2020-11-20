using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExploForAll.Server.Interactors.AccountUseCase.Commands.CreateNewAccount.User
{
    public class CreateNewUserAccountRequest :IRequest<CreateNewAccountResponse>
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Alias is required")]
        public string Alias { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
    }
}

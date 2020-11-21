using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ExploForAll.Server.Interactors.AccountUseCase.Commands.CreateNewAccount.User
{
    public class CreateNewUserAccountRequest :IRequest<CreateNewAccountResponse>
    {
        [Required(ErrorMessage = "Username is required")]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Alias is required")]
        public string Alias { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
    }
}

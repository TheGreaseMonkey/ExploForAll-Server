using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ExploForAll.Server.Interactors.AccountUseCase.Commands.CreateNewAccount.User
{
    public class CreateNewUserAccountRequest :IRequest<CreateNewAccountResponse>
    {
        [Required(ErrorMessage = "Username is required")]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        [MaxLength(80, ErrorMessage = "Username cannot be more than 80 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Alias is required")]
        [MaxLength(80, ErrorMessage = "Alias cannot be more than 80 characters")]
        public string Alias { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
    }
}

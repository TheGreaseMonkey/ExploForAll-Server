using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ExploForAll.Server.Interactors.AccountUseCase
{
    public class CreateNewAdminAccountRequest :IRequest<CreateNewAccountResponse>
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Alias is required")]
        public string Alias { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
    }
}

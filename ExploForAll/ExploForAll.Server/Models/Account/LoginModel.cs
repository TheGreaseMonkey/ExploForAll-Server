using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExploForAll.Server.Models.Account
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username is verplicht")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Wachtwoord is verplicht")]
        public string Password { get; set; }
    }
}

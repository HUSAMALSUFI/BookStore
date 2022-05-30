using System.ComponentModel.DataAnnotations;

namespace Book_Store.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage = "Please fill Username")]
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Rememberme { get; set; }
    }
}

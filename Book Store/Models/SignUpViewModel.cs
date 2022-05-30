using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Book_Store.Models
{
    public class SignUpViewModel
    {
        public SignUpModel signUpModel { get; set; }
        public List<IdentityRole> liRoles { get; set; }
    }
}

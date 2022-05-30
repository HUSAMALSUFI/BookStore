using Book_Store.Data;
using Book_Store.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Book_Store.Services
{
    public interface IAccountServices
    {
        Task<IdentityResult> CreateUser(SignUpModel signUpModel);
        Task<SignInResult> Checkpassword(SignInModel signInModel);
        Task<IdentityResult> NewRole(RoleModel roleModel);
        List<IdentityRole> GetRoles();
        Task Logout();
    }
}

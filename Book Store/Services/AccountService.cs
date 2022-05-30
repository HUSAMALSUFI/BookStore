using Book_Store.Data;
using Book_Store.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Book_Store.Services
{
    public class AccountServices : IAccountServices
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        RoleManager<IdentityRole> roleManager;

        public AccountServices(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager, RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
        }
        public async Task<IdentityResult> CreateUser(SignUpModel signUpModel)
        {
            ApplicationUser user = new ApplicationUser();

            user.Name = signUpModel.Name;
            user.Email = signUpModel.Email;
            //user.UserName = signUpModel.Name;
            user.UserName = signUpModel.Email;

            //user.PasswordHash = signUpModel.Password;
            var result = await userManager.CreateAsync(user, signUpModel.Password);
            if (result.Succeeded)
            {
                var role = await roleManager.FindByIdAsync(signUpModel.RoleId);
                result = await userManager.AddToRoleAsync(user, role.Name);
            }
            return result;
        }
        public async Task<SignInResult> Checkpassword(SignInModel signInModel)
        {
            var result = await signInManager.PasswordSignInAsync(signInModel.Username, signInModel.Password, signInModel.Rememberme, false);
            return result;
        }
        public async Task<IdentityResult> NewRole(RoleModel roleModel)
        {
            IdentityRole role = new IdentityRole();
            role.Name = roleModel.Name;

            var result = await roleManager.CreateAsync(role);
            return result;
        }
        public List<IdentityRole> GetRoles()
        {
            List<IdentityRole> liRole = roleManager.Roles.ToList();
            return liRole;
        }
        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }

    }
}


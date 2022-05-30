using Microsoft.AspNetCore.Identity;
namespace Book_Store.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}

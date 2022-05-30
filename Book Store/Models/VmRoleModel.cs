using Book_Store.Data;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Book_Store.Models
{
    public class VmRoleModel
    {
        public RoleModel roleModel { get; set; }
        public List<IdentityRole> liRoles { get; set; }
    }
}

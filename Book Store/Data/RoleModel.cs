using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book_Store.Data
{
    public class RoleModel
    {
        [Required]
        public string Name { get; set; }

    }
}

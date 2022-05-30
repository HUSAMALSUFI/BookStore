using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book_Store.Data
{
    [Table("countries")]
    public class Country
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please fill Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please fill Nationality")]
        public string Nationality { get; set; }
    }
}

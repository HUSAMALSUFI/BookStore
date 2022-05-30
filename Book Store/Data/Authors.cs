using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book_Store.Data
{
    [Table("Authors")]
    public class Authors
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please fill JobTitle")]
        public string JobTitle { get; set; }
        [Required(ErrorMessage = "Please fill FirstName")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please fill LastName")]
        public string LastName { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        public string Imagepath { get; set; }
        [ForeignKey("country")]
        public int Country_Id { get; set; }
        public Country country { get; set; }
        public List<Book> LiAuthorsBook { get; set; }
    }
}

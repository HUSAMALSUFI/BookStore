using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book_Store.Data
{
    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please fill Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please fill CategoryCode")]
        public string CatCode { get; set; }
        
        [Required(ErrorMessage = "Please fill Description")]
        public string Description { get; set; }
        
        public List<Book> LiCategoryBook { get; set; }
    }
}

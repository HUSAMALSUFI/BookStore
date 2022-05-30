using Book_Store.Data;
using System.Collections.Generic;

namespace Book_Store.Models
{
    public class VmBook
    {
        public Book book { get; set; }
        public List<Book> liabook { get; set; }
        public List<Authors> liauthors { get; set; }
        public List<Category> licategory { get; set; }
    }
}

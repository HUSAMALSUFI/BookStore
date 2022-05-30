using Book_Store.Data;
using System.Collections.Generic;

namespace Book_Store.Models
{
    public class VmCategory
    {
        public Category category { get; set; }
        public List<Category> licategory { get; set; }
    }
}

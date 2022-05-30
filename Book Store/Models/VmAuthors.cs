using Book_Store.Data;
using System.Collections.Generic;

namespace Book_Store.Models
{
    public class VmAuthors
    {
        public Authors authors { get; set; }
        public List<Authors> liauthors { get; set; }
        public List<Country> licountry { get; set; }
    }
}

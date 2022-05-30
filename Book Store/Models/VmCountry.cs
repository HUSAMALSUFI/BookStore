using Book_Store.Data;
using System.Collections.Generic;

namespace Book_Store.Models
{
    public class VmCountry
    {
        public Country country { get; set; }
        public List<Country> licountry { get; set; }
    }
}

using Book_Store.Data;
using System.Collections.Generic;

namespace Book_Store.Services
{
    public interface ICountryService
    {
        void Insert(Country country);
        List<Country> LoadCountry();
        void Delete(int Id);
        Country Edit(int Id);
        void Update(Country country);
    }
}

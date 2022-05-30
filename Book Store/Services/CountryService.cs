using Book_Store.Data;
using Book_Store.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
namespace Book_Store.Services
{
    public class CountryService : ICountryService
    {
        BookContext context;
        public CountryService(BookContext _context)
        {
            context = _context;
        }
        public void Insert(Country country)
        {
            context.countries.Add(country);
            context.SaveChanges();
        }
        public List<Country> LoadCountry()
        {
            List<Country> country = context.countries.ToList();
            return country;
        }
        public void Delete(int Id)
        {
            Country country = new Country();
            country = context.countries.Find(Id);
            context.countries.Remove(country);
            context.SaveChanges();
        }
        public Country Edit(int Id)
        {
            /*Country country = new Country();
            country = context.countries.Find(Id);
            return country;*/

            return context.countries.Where(e => e.Id == Id).FirstOrDefault();
        }
        public void Update(Country country)
        {
            context.countries.Attach(country);
            context.Entry(country).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}

using Book_Store.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Book_Store.Services
{
    public class AuthorsService: IAuthorsService
    {
        BookContext context;
        public AuthorsService(BookContext _context)
        {
            context = _context;
        }
        public void Insert(Authors author)
        {
            context.authors.Add(author);
            context.SaveChanges();
        }
        public List<Authors> LoadAuthors()
        {
            List<Authors> author = context.authors.Include("country").ToList();
            return author;
        }
        public void Delete(int Id)
        {
            Authors author = new Authors();
            author = context.authors.Find(Id);
            context.authors.Remove(author);
            context.SaveChanges();
        }
        public Authors Edit(int Id)
        {
            /*Authors authors = new Authors();
            authors = context.authors.Find(Id);
            return authors;*/

            return context.authors.Where(e => e.Id == Id).FirstOrDefault();
        }
        public void Update(Authors auth)
        {
            context.authors.Attach(auth);
            context.Entry(auth).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}

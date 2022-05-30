using Book_Store.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Book_Store.Services
{
    public class BookService: IBookService
    {
        BookContext context;
        public BookService(BookContext _context)
        {
            context = _context;
        }
        public void Insert(Book book)
        {
            context.books.Add(book);
            context.SaveChanges();
        }
        public List<Book> LoadBook()
        {
            List<Book> book = context.books.Include("Category").Include("Authors").ToList();
            return book;
        }
        public void Delete(int Id)
        {
            Book books = new Book();
            books = context.books.Find(Id);
            context.books.Remove(books);
            context.SaveChanges();
        }
        public Book Edit(int Id)
        {
            /*Book books = new Book();
            books = context.authors.Find(Id);
            return books;*/

            return context.books.Where(e => e.Id == Id).FirstOrDefault();
        }
        public void Update(Book book)
        {
            context.books.Attach(book);
            context.Entry(book).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}

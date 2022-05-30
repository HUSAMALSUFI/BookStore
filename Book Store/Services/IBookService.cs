using Book_Store.Data;
using System.Collections.Generic;

namespace Book_Store.Services
{
    public interface IBookService
    {
        void Insert(Book book);
        List<Book> LoadBook();
        void Delete(int Id);
        Book Edit(int Id);
        void Update(Book book);
    }
}

using Book_Store.Data;
using System.Collections.Generic;

namespace Book_Store.Services
{
    public interface IAuthorsService
    {
        void Insert(Authors authors);
        List<Authors> LoadAuthors();
        void Delete(int Id);
        Authors Edit(int Id);
        void Update(Authors authors);
    }
}

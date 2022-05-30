using Book_Store.Data;
using System.Collections.Generic;

namespace Book_Store.Services
{
    public interface ICategoryService
    {
        void Insert(Category category);
        List<Category> LoadCategory();
        void Delete(int Id);
        Category Edit(int Id);
        void Update(Category category);
    }
}

using Book_Store.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Book_Store.Services
{
    public class CategoryService: ICategoryService
    {
        BookContext context;
        public CategoryService(BookContext _context)
        {
            context = _context;
        }
        public void Insert(Category category)
        {
            context.categories.Add(category);
            context.SaveChanges();
        }
        public List<Category> LoadCategory()
        {
            List<Category> category = context.categories.ToList();
            return category;
        }
        public void Delete(int Id)
        {
            Category emp = new Category();
            emp = context.categories.Find(Id);
            context.categories.Remove(emp);
            context.SaveChanges();
        }
        public Category Edit(int Id)
        {
            /*Category emp = new Category();
            emp = context.categories.Find(Id);
            return emp;*/

            return context.categories.Where(e => e.Id == Id).FirstOrDefault();
        }
        public void Update(Category cat)
        {
            context.categories.Attach(cat);
            context.Entry(cat).State = EntityState.Modified;
            context.SaveChanges();
        }

    }
}

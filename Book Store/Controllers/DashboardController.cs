using Book_Store.Models;
using Book_Store.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Controllers
{
    public class DashboardController : Controller
    {
        IAuthorsService authorsService;
        ICategoryService categoryService;
        IBookService bookService;
        public DashboardController(IAuthorsService _authorsService, ICategoryService _categoryService, IBookService _bookService)
        {
            authorsService = _authorsService;
            categoryService = _categoryService;
            bookService = _bookService;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            VmBook vm = new VmBook();
            vm.liauthors = authorsService.LoadAuthors();
            vm.licategory = categoryService.LoadCategory();
            vm.liabook = bookService.LoadBook();
            return View("Dashboard",vm);
        }
    }
}

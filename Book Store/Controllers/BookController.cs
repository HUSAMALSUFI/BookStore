using Book_Store.Data;
using Book_Store.Models;
using Book_Store.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace Book_Store.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BookController : Controller
    {
        IAuthorsService authorsService;
        ICategoryService categoryService;
        IBookService bookService;
        public BookController(IAuthorsService _authorsService, ICategoryService _categoryService, IBookService _bookService)
        {
            authorsService = _authorsService;
            categoryService = _categoryService;
            bookService = _bookService;
        }
        public IActionResult Index()
        {
            ViewData["isEdting"] = false;
            VmBook vm = new VmBook();
            vm.liauthors = authorsService.LoadAuthors();
            vm.licategory = categoryService.LoadCategory();
            vm.liabook = bookService.LoadBook();
            return View("BookSection", vm);
        }
        public IActionResult Save(VmBook vm)
        {
            ViewData["isEdting"] = false;
            if (vm.book.Image == null)
            {

            }
            else
            {
                string name = Guid.NewGuid().ToString() + "." + vm.book.Image.FileName.Split('.')[1];
                string path = Path.Combine(Directory.GetCurrentDirectory(), "Images", name);
                vm.book.Image.CopyTo(new FileStream(path, FileMode.Create));
                vm.book.Imagepath = "http://localhost/BookStore/StaticPath/" + name;
            }
            if (ModelState.IsValid == true)
            {
                bookService.Insert(vm.book);
            }
            vm.liauthors = authorsService.LoadAuthors();
            vm.licategory = categoryService.LoadCategory();
            vm.liabook = bookService.LoadBook();
            return View("BookSection", vm);
        }
        public IActionResult Delete(int Id)
        {
            ViewData["isEdting"] = false;
            VmBook vm = new VmBook();
            bookService.Delete(Id);
            vm.liauthors = authorsService.LoadAuthors();
            vm.licategory = categoryService.LoadCategory();
            vm.liabook = bookService.LoadBook();
            return View("BookSection", vm);
        }
        /*public IActionResult Edit(int Id)
        {
            ViewData["isEdting"] = true;

            VmBook vm = new VmBook();

            vm.book = bookService.Edit(Id);
            vm.liauthors = authorsService.LoadAuthors();
            vm.licategory = categoryService.LoadCategory();
            vm.liabook = bookService.LoadBook();
            return View("BookSection", vm);
        }*/
        public IActionResult EditAjax(int Id)
        {
            Book book = new Book();
            book = bookService.Edit(Id);
            return Json(book);
        }
        public IActionResult Update(VmBook vm)
        {
            ViewData["isEdting"] = true;

            if (vm.book.Image == null)
            {

            }
            else
            {
                string name = Guid.NewGuid().ToString() + "." + vm.book.Image.FileName.Split('.')[1];
                string path = Path.Combine(Directory.GetCurrentDirectory(), "Images", name);
                vm.book.Image.CopyTo(new FileStream(path, FileMode.Create));
                vm.book.Imagepath = "http://localhost/BookStore/StaticPath/" + name;
            }

            bookService.Update(vm.book);
            vm.liauthors = authorsService.LoadAuthors();
            vm.licategory = categoryService.LoadCategory();
            vm.liabook = bookService.LoadBook();
            return View("BookSection", vm);
        }
    }
}

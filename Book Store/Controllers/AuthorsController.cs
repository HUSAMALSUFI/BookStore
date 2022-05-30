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
    public class AuthorsController : Controller
    {
        ICountryService countryService;
        IAuthorsService authorsService;
        public AuthorsController(ICountryService _cService, IAuthorsService _authorsService)
        {
            countryService = _cService;
            authorsService=_authorsService;
        }
        public IActionResult Index()
        {
            ViewData["isEdting"] = false;
            VmAuthors vm = new VmAuthors();
            vm.licountry = countryService.LoadCountry();
            vm.liauthors = authorsService.LoadAuthors();
            return View("AuthorsSection",vm);
        }
        public IActionResult Save(VmAuthors vm)
        {
            ViewData["isEdting"] = false;
            if (vm.authors.Image == null)
            {

            }
            else
            {
                string name = Guid.NewGuid().ToString() + "." + vm.authors.Image.FileName.Split('.')[1];
                string path = Path.Combine(Directory.GetCurrentDirectory(), "Images", name);
                vm.authors.Image.CopyTo(new FileStream(path, FileMode.Create));
                vm.authors.Imagepath = "http://localhost/BookStore/StaticPath/" + name;
            }
            if (ModelState.IsValid == true)
            {
                authorsService.Insert(vm.authors);
            }
            vm.licountry = countryService.LoadCountry();
            vm.liauthors = authorsService.LoadAuthors();
            return View("AuthorsSection", vm);
        }
        public IActionResult Delete(int Id)
        {
            ViewData["isEdting"] = false;
            VmAuthors vm = new VmAuthors();
            authorsService.Delete(Id);
            vm.licountry = countryService.LoadCountry();
            vm.liauthors = authorsService.LoadAuthors();
            return View("AuthorsSection", vm);
        }
        /* public IActionResult Edit(int Id)
         {
             ViewData["isEdting"] = true;

             VmAuthors vm = new VmAuthors();

             vm.authors = authorsService.Edit(Id);
             vm.licountry = countryService.LoadCountry();
             vm.liauthors = authorsService.LoadAuthors();
             return View("AuthorsSection", vm);
         }*/
        public IActionResult EditAjax(int Id)
        {
            Authors authors = new Authors();
            authors = authorsService.Edit(Id);
            return Json(authors);
        }
        public IActionResult Update(VmAuthors vm)
        {
            ViewData["isEdting"] = true;
            if (vm.authors.Image == null)
            {

            }
            else
            {
                string name = Guid.NewGuid().ToString() + "." + vm.authors.Image.FileName.Split('.')[1];
                string path = Path.Combine(Directory.GetCurrentDirectory(), "Images", name);
                vm.authors.Image.CopyTo(new FileStream(path, FileMode.Create));
                vm.authors.Imagepath = "http://localhost/BookStore/StaticPath/" + name;
            }

            authorsService.Update(vm.authors);
            vm.licountry = countryService.LoadCountry();
            vm.liauthors = authorsService.LoadAuthors();
            return View("AuthorsSection", vm);
        }
    }
}

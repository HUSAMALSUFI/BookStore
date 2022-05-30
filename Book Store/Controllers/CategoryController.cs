using Book_Store.Data;
using Book_Store.Models;
using Book_Store.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Book_Store.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        ICategoryService categoryService;
        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }
        public IActionResult Index()
        {
            ViewData["isEdting"] = false;
            VmCategory vm = new VmCategory();
            vm.licategory = categoryService.LoadCategory();
            return View("CategorySection", vm);
        }
        public IActionResult Save(VmCategory vm)
        {
            ViewData["isEdting"] = false;
            if (ModelState.IsValid == true)
            {
                categoryService.Insert(vm.category);
            }
            vm.licategory = categoryService.LoadCategory();

            return View("CategorySection", vm);
        }
        public IActionResult Delete(int Id)
        {
            ViewData["isEdting"] = false;
            VmCategory vm = new VmCategory();
            categoryService.Delete(Id);
            vm.licategory = categoryService.LoadCategory();
            return View("CategorySection", vm);
        }
        /* public IActionResult Edit(int Id)
         {
             ViewData["isEdting"] = true;

             VmCategory vm = new VmCategory();
             vm.category = categoryService.Edit(Id);
             vm.licategory = categoryService.LoadCategory();
             return View("CategorySection", vm);
         }*/
        public IActionResult EditAjax(int Id)
        {
            Category category = new Category();
            category = categoryService.Edit(Id);
            return Json(category);
        }
        public IActionResult Update(VmCategory vm)
        {
            ViewData["isEdting"] = true;

            categoryService.Update(vm.category);
            vm.licategory = categoryService.LoadCategory();
            return View("CategorySection", vm);
        }

    }
}

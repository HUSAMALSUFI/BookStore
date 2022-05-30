using Book_Store.Data;
using Book_Store.Models;
using Book_Store.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CountryController : Controller
    {
        ICountryService countryServices;
        public CountryController(ICountryService _cService)
        {
            countryServices = _cService;
        }
        public IActionResult Index()
        {
            ViewData["isEdting"] = false;

            VmCountry vc = new VmCountry();
            vc.licountry = countryServices.LoadCountry();
            return View("NewCountry", vc);
        }
        public IActionResult Save(VmCountry vc)
        {
            ViewData["isEdting"] = false;

            countryServices.Insert(vc.country);
            vc.licountry = countryServices.LoadCountry();
            return View("NewCountry", vc);
        }
        public IActionResult Delete(int Id)
        {
            ViewData["isEdting"] = false;

            VmCountry vm = new VmCountry();
            countryServices.Delete(Id);
            vm.licountry = countryServices.LoadCountry();
            return View("NewCountry", vm);
        }
        /* public IActionResult Edit(int Id)
         {
             ViewData["isEdting"] = true;

             VmCountry vm = new VmCountry();
             vm.country = countryServices.Edit(Id);
             vm.licountry = countryServices.LoadCountry();
             return View("NewCountry", vm);
         }*/
        public IActionResult EditAjax(int Id)
        {
            Country country = new Country();
            country = countryServices.Edit(Id);
            return Json(country);
        }
        public IActionResult Update(VmCountry vm)
        {
            ViewData["isEdting"] = true;

            countryServices.Update(vm.country);
            vm.licountry = countryServices.LoadCountry();
            return View("NewCountry", vm);
        }
    }
}

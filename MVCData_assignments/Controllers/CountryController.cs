using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCData_assignments.Models.Services;
using MVCData_assignments.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData_assignments.Controllers
{
    public class CountryController : Controller
    {

        private ICountryService _countryService;
        CountryListViewModel countryListVM = new CountryListViewModel();


        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        // GET: CountryController
        public ActionResult Index()
        {
            countryListVM.CountryList = _countryService.GetAll();

            return View(countryListVM);
        }


        // GET: CountryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CountryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}

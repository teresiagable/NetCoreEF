using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCData_assignments.Models;
using MVCData_assignments.Models.Services;

namespace MVCData_assignments.Controllers
{
    public class PersonController : Controller
    {

        private IPersonService _personService;
        PersonListViewModel personListVM = new PersonListViewModel();

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        public IActionResult Index()
        {
            personListVM.PersonList = _personService.GetAll();
            return View(personListVM);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PersonCreateModel personVM)
        {
            if (ModelState.IsValid)
            {
                _personService.Add(personVM);
                return RedirectToAction("Index", personListVM);

            }

            return View("Index", personListVM);
        }
        [HttpPost]
        public IActionResult Update(Person person)
        {
            if (ModelState.IsValid)
            {
                _personService.Edit(person);
                return PartialView("_personPartial", person);

            }

            return View();
        }


        public IActionResult Edit(int id)
        {
            return PartialView("_EditPersonPartial", _personService.GetById(id));
        }


        public IActionResult Delete(int id)
        {
            if (_personService.RemovePerson(id))
            {
                personListVM.PersonList = _personService.GetAll();
                ViewBag.DeleteMsg = "Successfully deleted";
            }
            else ViewBag.DeleteMsg = "Delete failed";
            return View("Index", personListVM);
        }

        [HttpPost]
        public IActionResult Filter(string filter)
        {
            personListVM.Filter = filter;
            personListVM.PersonList = _personService.FilterPerson(filter);
            return View("Index", personListVM);
        }
    }
}
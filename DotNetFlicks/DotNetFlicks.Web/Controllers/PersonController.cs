﻿using DotNetFlicks.Managers.Interfaces;
using DotNetFlicks.ViewModels.Person;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetFlicks.Web.Controllers
{
    [Authorize]
    public class PersonController : Controller
    {
        private IPersonManager _personManager;

        public PersonController(IPersonManager personManager)
        {
            _personManager = personManager;
        }

        public ActionResult Index()
        {
            var vm = _personManager.GetAll();

            return View(vm);
        }

        public ActionResult View(int id)
        {
            var vm = _personManager.Get(id);

            return View(vm);
        }

        public ActionResult Edit(int? id)
        {
            var vm = _personManager.Get(id);

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PersonViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _personManager.Save(vm);
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        public ActionResult Delete(int id)
        {
            var vm = _personManager.Get(id);

            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _personManager.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
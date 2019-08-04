using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdministrationConsole.Models;
using AdministrationConsole.Services;

namespace AdministrationConsole.Controllers
{
    [Route("child")]
    public class ChildController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(ApiService.GetChildren());
        }

        [HttpGet("{id}")]
        public IActionResult Detail(string id)
        {
            return View(ApiService.GetChildById(id));
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string surname, string firstname)
        {
            ApiService.CreateChild(new Child()
            {
                FirstName = firstname,
                LastName = surname
            });

            return RedirectToAction("Index", "child");
        }
    }
}

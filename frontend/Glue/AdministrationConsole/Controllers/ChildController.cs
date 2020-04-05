using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdministrationConsole.Models;
using AdministrationConsole.Services;
using VolontApp.Models;

namespace AdministrationConsole.Controllers
{
    [Route("child")]
    public class ChildController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await ApiService.GetChildrenAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Detail(string id)
        {
            return View(await ApiService.GetChildByIdAsync(id));
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(string firstName, string surName)
        {
            await ApiService.CreateChildAsync(new Child()
            {
                Firstname = firstName,
                Surname = surName
            });

            return RedirectToAction("Index", "child");

        }
    }
}

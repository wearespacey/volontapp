using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdministrationConsole.Models;
using AdministrationConsole.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdministrationConsole.Controllers
{
    [Route("case")]
    public class CaseController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(ApiService.GetCases());
        }

        [HttpGet("create/{childId}")]
        public IActionResult Create(string childId)
        {
            ViewData["childId"] = childId;
            return View(ApiService.GetCoordinators());
        }

        [HttpPost]
        public IActionResult Create(string childId, string volunteerId, DateTime missingDate)
        {
            ApiService.CreateCase(new Case()
            {
                ChildId = childId,
                VolunteerId = volunteerId,
                MissingDate = missingDate
            });

            return RedirectToAction("Index", "case");

        }
    }
}

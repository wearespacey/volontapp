using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdministrationConsole.Models;
using AdministrationConsole.Services;
using Microsoft.AspNetCore.Mvc;
using VolontApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdministrationConsole.Controllers
{
    [Route("case")]
    public class CaseController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ccc = await ApiService.GetCasesAsync();
            return View(ccc);
        }

        [HttpGet("create/{childId}")]
        public async Task<IActionResult> Create(string childId)
        {
            ViewData["childId"] = childId;
            var ccc = await ApiService.GetCoordinatorsAsync();
            return View(ccc);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(string childId, string coordinatorId, DateTime missingDate)
        {
            await ApiService.CreateCaseAsync(new Case()
            {
                ChildId = childId,
                CoordinatorId = coordinatorId,
                MissingDate = missingDate
            });

            return RedirectToAction("Index", "case");

        }
    }
}

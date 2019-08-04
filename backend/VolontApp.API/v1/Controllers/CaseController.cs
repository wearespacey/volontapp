using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VolontApp.DAL.Repositories;
using VolontApp.Models;

namespace VolontApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseController : ControllerBase
    {
        public CaseRepository CaseRepository { get; set; }
        public VolunteerRepository VolunteerRepository { get; set; }

        public CaseController(CaseRepository caseRepository, VolunteerRepository volunteerRepository)
        {
            CaseRepository = caseRepository;
            VolunteerRepository= volunteerRepository;
        }

        // GET: api/Case
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await CaseRepository.ReadAllAsync());
        }

        // GET: api/Case/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Case>> GetById(string id)
        {
            return Ok(await CaseRepository.ReadAsync(id));
        }

        // GET: api/Case/ByChildAndCoordinator/5
        [HttpGet("ByChildAndCoordinator/{childId}")]
        public async Task<ActionResult<Case>> GetByChildAndCoordinator(string childId, [FromBody] string installId)
        {
            return Ok((await CaseRepository.ReadAllAsync())
                .FirstOrDefault(c => c.MissingStatus != MissingStatus.Found && c.Child.Id == childId && c.Coordinator.InstallId == installId));
        }

        // POST: api/Case
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] Case value)
        {
            return Ok(await CaseRepository.CreateAsync(value, Guid.NewGuid().ToString()));
        }

        // PUT: api/Case/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] Case value)
        {
            await CaseRepository.UpdateAsync(value, id);
            return Ok();
        }

        // PUT: api/Case/5/AddVolunteer
        [HttpPut("{id}/AddVolunteer")]
        public async Task<ActionResult<Case>> AddVolunteer(string id, [FromBody] string installId)
        {
            Case caseToUpDate = await CaseRepository.ReadAsync(id);
            Volunteer volunteerToAdd = await VolunteerRepository.ReadByInstallIdAsync(installId);

            if (caseToUpDate.VolunteerIds == null) caseToUpDate.VolunteerIds = new List<string>();
            caseToUpDate.VolunteerIds.Add(volunteerToAdd.Id);

            await CaseRepository.UpdateAsync(caseToUpDate, id);

            return Ok(await CaseRepository.ReadAsync(id));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await CaseRepository.DeleteAsync(id);
            return Ok();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VolontApp.DAL.Repositories;
using VolontApp.DTO;
using VolontApp.Models;

namespace VolontApp.API.v1.Controllers
{
    [
        ApiController,
        ApiVersion("1.0"),
        Route("api/v{version:apiVersion}/[controller]")
    ]
    public class CaseController : ControllerBase
    {
        public CaseRepository CaseRepository { get; set; }
        public VolunteerRepository VolunteerRepository { get; set; }

        public CoordinatorRepository CoordinatorRepository { get; set; }

        public CaseController(CaseRepository caseRepository, VolunteerRepository volunteerRepository, CoordinatorRepository coordinatorRepository)
        {
            CaseRepository = caseRepository;
            VolunteerRepository= volunteerRepository;
            CoordinatorRepository = coordinatorRepository;
        }

        // GET: api/v1/Case
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await CaseRepository.ReadAllAsync());
        }

        // GET: api/v1/Case/5
        [HttpGet("{id}")]
        public ActionResult<Case> GetById(string id)
        {
            return Ok(CaseRepository.Read(id));
        }

        // GET: api/v1/Case/ByCoordinator/5
        [HttpGet("ByCoordinator/{coordinatorId}")]
        public async Task<ActionResult<Case>> GetByCoordinator(string coordinatorId)
        {
            return Ok((await CaseRepository.ReadAllAsync()).Where(c => c.MissingStatus != MissingStatus.Found
                                                                    && c.CoordinatorId == coordinatorId));
        }

        // GET: api/v1/Case/ByChild/5
        [HttpGet("ByChild/{childId}")]
        public async Task<ActionResult<Case>> GetByChild(string childId)
        {
            return Ok((await CaseRepository.ReadAllAsync()).Where(c => c.MissingStatus != MissingStatus.Found 
                                                                    && c.ChildId == childId));
        }

        // GET: api/v1/Case/ByChildAndCoordinator
        [HttpGet("ByChildAndCoordinator")]
        public async Task<ActionResult<Case>> GetByChildAndCoordinator([FromBody] ChildAndCoordinator childAndCoordinator)
        {
            return Ok((await CaseRepository.ReadAllAsync())
                .FirstOrDefault(c => c.MissingStatus != MissingStatus.Found 
                                     && c.ChildId == childAndCoordinator.ChildId
                                     && c.CoordinatorId == childAndCoordinator.CoordinatorId));
        }

        // POST: api/v1/Case
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] Case value)
        {
            return Ok(await CaseRepository.CreateAsync(value, Guid.NewGuid().ToString()));
        }

        // PUT: api/v1/Case/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] Case value)
        {
            await CaseRepository.UpdateAsync(value, id);
            return Ok();
        }

        // PUT: api/v1/Case/5/AddVolunteer
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

        // DELETE: api/v1/Case/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await CaseRepository.DeleteAsync(id);
            return Ok();
        }
    }
}

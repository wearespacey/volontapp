using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<IEnumerable<Case>>> GetAll()
        {
            return Ok(await CaseRepository.ReadAllAsync());
        }

        // GET: api/Case/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Case>> GetById(string id)
        {
            return Ok(await CaseRepository.ReadAsync(id));
        }

        // GET: api/Case/5
        [HttpGet("ByMissingChild/{id}")]
        public async Task<ActionResult<Case>> GetByMissingChild(string id, [FromBody] string installId)
        {
            return Ok((await CaseRepository.ReadAllAsync()).ToList()
                .Where(c => c.MissingStatus != MissingStatus.Found)
                .FirstOrDefault(c => c.MissingChild.Id == id && c.Coordinator.InstallId == installId));
        }

        // POST: api/Case
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] Case value)
        {
            string caseCreatedId = Guid.NewGuid().ToString();
            await CaseRepository.CreateAsync(value, caseCreatedId);
            return Ok(caseCreatedId);
        }
        //cas id gamin
        // PUT: api/Case
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Case value)
        {
            await CaseRepository.UpdateAsync(value);
            return Ok();
        }

        // PUT: api/Case/AddVolunteer/5
        [HttpPut("AddVolunteer/{id}")]
        public async Task<ActionResult<Case>> AddVolunteer(string id,[FromBody] string installId)
        {
            Case caseToUpDate = await CaseRepository.ReadAsync(id);
            Volunteer volunteerToAdd = (await VolunteerRepository.ReadAllAsync()).ToList().FirstOrDefault(v => v.InstallId == installId);

            caseToUpDate.Volunteers.Add(volunteerToAdd);
            await CaseRepository.UpdateAsync(caseToUpDate);
            return Ok();
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

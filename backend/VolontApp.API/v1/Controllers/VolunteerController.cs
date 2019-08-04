using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VolontApp.DAL.Repositories;
using VolontApp.Models;

namespace VolontApp.API.v1.Controllers
{
    [
        ApiController,
        ApiVersion("1.0"),
        Route("api/v{version:apiVersion}/[controller]")
    ]
    public class VolunteerController : ControllerBase
    {
        public VolunteerRepository VolunteerRepository { get; set; }

        public VolunteerController(VolunteerRepository volunteerRepository)
        {
            this.VolunteerRepository = volunteerRepository;
        }

        // GET: api/v1/Volunteer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Volunteer>>> GetAll()
        {
            return Ok(await VolunteerRepository.ReadAllAsync());
        }

        // GET: api/v1/Volunteer/5
        [HttpGet("{id}")]
        public ActionResult<Volunteer> GetById(string id)
        {
            var volunteer = VolunteerRepository.Read(id);
            return Ok(volunteer);
        }

        // GET: api/v1/Volunteer/ByCoordinator/5
        [HttpGet("ByCoordinator/{id}")]
        public async Task<ActionResult<IEnumerable<Volunteer>>> GetByCoordinatorId(string id)
        {
            return Ok(await VolunteerRepository.ReadAllByCoordinatorAsync(id));
        }


        // POST: api/v1/Volunteer
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Volunteer value)
        {
            await VolunteerRepository.CreateAsync(value, Guid.NewGuid().ToString());
            return Ok();
        }

        // PUT: api/v1/Volunteer/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] Volunteer value)
        {
            await VolunteerRepository.UpdateAsync(value, id);
            return Ok();
        }

        // PUT: api/v1/Volunteer/5/UpdateInstallId
        [HttpPut("{volunteerId}/UpdateInstallId")]
        public async Task<ActionResult> ÛpdateInstallId(string volunteerId, [FromBody] string installId)
        {
            var volunteer = VolunteerRepository.Read(volunteerId);
            volunteer.InstallId = installId;
            await VolunteerRepository.UpdateAsync(volunteer, volunteerId);
            return Ok();
        }

        // DELETE: api/v1/Volunteer/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await VolunteerRepository.DeleteAsync(id);
            return Ok();
        }
    }
}

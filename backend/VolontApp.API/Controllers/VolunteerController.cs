using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VolontApp.DAL.Repositories;
using VolontApp.Models;

namespace VolontApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteerController : ControllerBase
    {
        public VolunteerRepository VolunteerRepository { get; set; }

        public VolunteerController(VolunteerRepository volunteerRepository)
        {
            this.VolunteerRepository = volunteerRepository;
        }

        // GET: api/Volunteer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Volunteer>>> GetAll()
        {
            return Ok(await VolunteerRepository.ReadAllAsync());
        }

        // GET: api/Volunteer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Volunteer>> GetById(string id)
        {
            return Ok(await VolunteerRepository.ReadAsync(id));
        }

        // GET: api/Volunteer/ByCoordinator/5
        [HttpGet("ByCoordinator/{id}")]
        public async Task<ActionResult<IEnumerable<Volunteer>>> GetByCoordinatorId(string id)
        {
            return Ok(await VolunteerRepository.ReadAllByCoordinatorAsync(id));
        }


        // POST: api/Volunteer
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Volunteer value)
        {
            await VolunteerRepository.CreateAsync(value, Guid.NewGuid().ToString());
            return Ok();
        }

        // PUT: api/Volunteer/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] Volunteer value)
        {
            await VolunteerRepository.UpdateAsync(id, value);
            return Ok();
        }

        // DELETE: api/Volunteer/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await VolunteerRepository.DeleteAsync(id);
            return Ok();
        }
    }
}

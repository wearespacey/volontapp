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
    public class VolunteerController : ControllerBase
    {
        public VolunteerRepository VolunteerRepository { get; set; }
        // GET: api/Volunteer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Volunteer>>> Get()
        {
            return Ok(await VolunteerRepository.ReadAllAsync());
        }

        // GET: api/Volunteer/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Volunteer>> Get(string id)
        {
            return Ok(await VolunteerRepository.ReadAsync(id));
        }

        // POST: api/Volunteer
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Volunteer value)
        {
            await VolunteerRepository.CreateAsync(value, Guid.NewGuid().ToString());
            return Ok();
        }

        // PUT: api/Volunteer/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Volunteer value)
        {
            await VolunteerRepository.UpdateAsync(value);
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

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
    public class VonlunteerController : ControllerBase
    {
        private readonly VolunteerRepository _VolunteerRepository;
        // GET: api/Vonlunteer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Volunteer>>> Get()
        {
            return Ok(await _VolunteerRepository.ReadAllAsync());
        }

        // GET: api/Vonlunteer/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Volunteer>> Get(string id)
        {
            return Ok(await _VolunteerRepository.ReadAsync(id));
        }

        // POST: api/Vonlunteer
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Volunteer value)
        {
            await _VolunteerRepository.CreateAsync(value, Guid.NewGuid().ToString());
            return Ok();
        }

        // PUT: api/Vonlunteer/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Volunteer value)
        {
            await _VolunteerRepository.UpdateAsync(value);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _VolunteerRepository.DeleteAsync(id);
            return Ok();
        }
    }
}

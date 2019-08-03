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
    public class CoordinatorController : ControllerBase
    {

        public CoordinatorRepository CoordinatorRepository { get; set; }

        public CoordinatorController(CoordinatorRepository coordinatorRepository)
        {
            this.CoordinatorRepository = coordinatorRepository;
        }

        // GET: api/Coordinator
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coordinator>>> GetAll()
        {
            return Ok(await CoordinatorRepository.ReadAllAsync());
        }

        // GET: api/Coordinator/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coordinator>> GetById(string id)
        {
            return Ok(await CoordinatorRepository.ReadAsync(id));
        }

        // POST: api/Coordinator
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Coordinator value)
        {
            await CoordinatorRepository.CreateAsync(value, Guid.NewGuid().ToString());
            return Ok();
        }

        // PUT: api/Coordinator/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] Coordinator value)
        {
            await CoordinatorRepository.UpdateAsync(id, value);
            return Ok();
        }

        // DELETE: api/Coordinator/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await CoordinatorRepository.DeleteAsync(id);
            return Ok();
        }
    }
}

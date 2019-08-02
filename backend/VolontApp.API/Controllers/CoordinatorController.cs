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
    public class CoordinatorController : ControllerBase
    {

        private readonly CoordinatorRepository _CoordinatorRepository;
        // GET: api/Coordinator
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coordinator>>> Get()
        {
            return Ok(await _CoordinatorRepository.ReadAllAsync());
        }

        // GET: api/Coordinator/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Coordinator>> Get(string id)
        {
            return Ok(_CoordinatorRepository.ReadAsync(id));
        }

        // POST: api/Coordinator
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Coordinator value)
        {
            await _CoordinatorRepository.CreateAsync(value, Guid.NewGuid().ToString());
            return Ok();
        }

        // PUT: api/Coordinator/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] Coordinator value)
        {
            await _CoordinatorRepository.UpdateAsync(value);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _CoordinatorRepository.DeleteAsync(id);
            return Ok();
        }
    }
}

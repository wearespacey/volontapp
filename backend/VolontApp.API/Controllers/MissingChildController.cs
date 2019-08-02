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
    public class MissingChildController : ControllerBase
    {
        private readonly MissingChildRepository _MissingChildRepository;
        // GET: api/MissingChild
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MissingChild>>> Get()
        {
            return Ok(await _MissingChildRepository.ReadAllAsync());
        }

        // GET: api/MissingChild/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<MissingChild>> Get(string id)
        {
            return Ok(await _MissingChildRepository.ReadAsync(id));
        }

        // POST: api/MissingChild
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] MissingChild value)
        {
            await _MissingChildRepository.CreateAsync(value, Guid.NewGuid().ToString());
            return Ok();
        }

        // PUT: api/MissingChild/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] MissingChild value)
        {
            await _MissingChildRepository.UpdateAsync(value);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _MissingChildRepository.DeleteAsync(id);
            return Ok();
        }
    }
}

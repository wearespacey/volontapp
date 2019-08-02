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
    public class DisplayController : ControllerBase
    {
        private readonly DisplayRepository _DisplayRepository;
        // GET: api/Display
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Display>>> Get()
        {
            return Ok(await _DisplayRepository.ReadAllAsync());
        }

        // GET: api/Display/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Display>> Get(string id)
        {
            return Ok(await _DisplayRepository.ReadAsync(id));
        }

        // POST: api/Display
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Display value)
        {
            await _DisplayRepository.CreateAsync(value, Guid.NewGuid().ToString());
            return Ok();
        }

        // PUT: api/Display/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Display value)
        {
            await _DisplayRepository.UpdateAsync(value);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _DisplayRepository.DeleteAsync(id);
            return Ok();
        }
    }
}

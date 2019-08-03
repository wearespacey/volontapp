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
        public DisplayRepository DisplayRepository { get; set; }
        // GET: api/Display
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Display>>> Get()
        {
            return Ok(await DisplayRepository.ReadAllAsync());
        }

        // GET: api/Display/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Display>> Get(string id)
        {
            return Ok(await DisplayRepository.ReadAsync(id));
        }

        // POST: api/Display
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Display value)
        {
            await DisplayRepository.CreateAsync(value, Guid.NewGuid().ToString());
            return Ok();
        }

        // PUT: api/Display/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Display value)
        {
            await DisplayRepository.UpdateAsync(value);
            return Ok();
        }

        // DELETE: api/Display/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await DisplayRepository.DeleteAsync(id);
            return Ok();
        }
    }
}

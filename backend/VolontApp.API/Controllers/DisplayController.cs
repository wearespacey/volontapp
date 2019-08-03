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
    public class DisplayController : ControllerBase
    {
        public DisplayRepository DisplayRepository { get; set; }

        public DisplayController(DisplayRepository displayRepository)
        {
            this.DisplayRepository = displayRepository;
        }

        // GET: api/Display
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Display>>> GetAll()
        {
            return Ok(await DisplayRepository.ReadAllAsync());
        }

        // GET: api/Display/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Display>> GetById(string id)
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
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] Display value)
        {
            await DisplayRepository.UpdateAsync(value, id);
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

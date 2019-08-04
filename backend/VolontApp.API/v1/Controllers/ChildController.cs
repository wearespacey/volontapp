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
    public class ChildController : ControllerBase
    {
        public ChildRepository ChildRepository { get; set; }

        public ChildController (ChildRepository childRepository)
        {
            this.ChildRepository = childRepository;
        }

        // GET: api/Child
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Child>>> GetAll()
        {
            return Ok(await ChildRepository.ReadAllAsync());
        }

        // GET: api/Child/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Child>> GetById(string id)
        {
            return Ok(await ChildRepository.ReadAsync(id));
        }

        // POST: api/Child
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Child value)
        {
            await ChildRepository.CreateAsync(value, Guid.NewGuid().ToString());
            return Ok();
        }

        // PUT: api/Child/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] Child value)
        {
            await ChildRepository.UpdateAsync(value, id);
            return Ok();
        }

        // DELETE: api/Child/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await ChildRepository.DeleteAsync(id);
            return Ok();
        }
    }
}

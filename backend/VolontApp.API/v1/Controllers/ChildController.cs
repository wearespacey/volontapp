using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VolontApp.DAL.Repositories;
using VolontApp.Models;

namespace VolontApp.API.v1.Controllers
{
    [
        ApiController,
        ApiVersion("1.0"),
        Route("api/v{version:apiVersion}/[controller]")
    ]
    public class ChildController : ControllerBase
    {
        public ChildRepository ChildRepository { get; set; }

        public ChildController (ChildRepository childRepository)
        {
            this.ChildRepository = childRepository;
        }

        // GET: api/v1/Child
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Child>>> GetAll()
        {
            var children = await ChildRepository.ReadAllAsync();
            return Ok(children);
        }

        // GET: api/v1/Child/5
        [HttpGet("{id}")]
        public ActionResult<Child> GetById(string id)
        {
            return Ok(ChildRepository.Read(id));
        }

        // POST: api/v1/Child
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Child value)
        {
            await ChildRepository.CreateAsync(value, Guid.NewGuid().ToString());
            return Ok();
        }

        // PUT: api/v1/Child/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] Child value)
        {
            await ChildRepository.UpdateAsync(value, id);
            return Ok();
        }

        // DELETE: api/v1/Child/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await ChildRepository.DeleteAsync(id);
            return Ok();
        }
    }
}

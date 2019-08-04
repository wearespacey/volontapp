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
    public class CoordinatorController : ControllerBase
    {

        public CoordinatorRepository CoordinatorRepository { get; set; }

        public CoordinatorController(CoordinatorRepository coordinatorRepository)
        {
            this.CoordinatorRepository = coordinatorRepository;
        }

        // GET: api/v1/Coordinator
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coordinator>>> GetAll()
        {
            return Ok(await CoordinatorRepository.ReadAllAsync());
        }

        // GET: api/v1/Coordinator/5
        [HttpGet("{id}")]
        public ActionResult<Coordinator> GetById(string id)
        {
            return Ok(CoordinatorRepository.Read(id));
        }

        // POST: api/v1/Coordinator
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Coordinator value)
        {
            await CoordinatorRepository.CreateAsync(value, Guid.NewGuid().ToString());
            return Ok();
        }

        // PUT: api/v1/Coordinator/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] Coordinator value)
        {
            await CoordinatorRepository.UpdateAsync(value, id);
            return Ok();
        }

        // DELETE: api/v1/Coordinator/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await CoordinatorRepository.DeleteAsync(id);
            return Ok();
        }
    }
}

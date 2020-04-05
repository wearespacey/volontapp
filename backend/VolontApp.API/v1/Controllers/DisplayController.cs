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
    public class DisplayController : ControllerBase
    {
        public DisplayRepository DisplayRepository { get; set; }

        public DisplayController(DisplayRepository displayRepository)
        {
            this.DisplayRepository = displayRepository;
        }

        // GET: api/v1/Display
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Display>>> GetAll()
        {
            return Ok(await DisplayRepository.ReadAllAsync());
        }

        // GET: api/v1/Display/5
        [HttpGet("{id}")]
        public ActionResult<Display> GetById(string id)
        {
            return Ok(DisplayRepository.Read(id));
        }

        // POST: api/v1/Display
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Display value)
        {
            await DisplayRepository.CreateAsync(value, Guid.NewGuid().ToString());
            return Ok();
        }

        // PUT: api/v1/Display/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] Display value)
        {
            await DisplayRepository.UpdateAsync(value, id);
            return Ok();
        }

        // DELETE: api/v1/Display/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await DisplayRepository.DeleteAsync(id);
            return Ok();
        }
    }
}

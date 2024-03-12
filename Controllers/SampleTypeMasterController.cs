using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Metaphor_Backend.Models;
using Metaphor_Backend.Repositories;

namespace Metaphor_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SampleTypeMasterController : ControllerBase
    {
        private readonly SampleTypeMasterRepository repository;

        public SampleTypeMasterController(SampleTypeMasterRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public ActionResult<SampleTypeMaster> CreateSampleTypeMaster(SampleTypeMaster sampleTypeMaster)
        {
            repository.Insert(sampleTypeMaster);
            return CreatedAtAction(nameof(GetSampleTypeMasterById), new { id = sampleTypeMaster.Id }, sampleTypeMaster);
        }

        [HttpGet("{id}")]
        public ActionResult<SampleTypeMaster> GetSampleTypeMasterById(int id)
        {
            var sampleTypeMaster = repository.GetById(id);
            if (sampleTypeMaster == null)
            {
                return NotFound();
            }
            return sampleTypeMaster;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SampleTypeMaster>> GetAllSampleTypeMasters()
        {
            return Ok(repository.GetAll());
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSampleTypeMaster(int id, SampleTypeMaster sampleTypeMaster)
        {
            if (id != sampleTypeMaster.Id)
            {
                return BadRequest();
            }

            repository.Update(sampleTypeMaster);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSampleTypeMaster(int id)
        {
            repository.Delete(id);
            return NoContent();
        }
    }
}
    
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Metaphor_Backend.Models;
using Metaphor_Backend.Repositories;

namespace Metaphor_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceMasterController : ControllerBase
    {
        private readonly ServiceMasterRepository repository;

        public ServiceMasterController(ServiceMasterRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public ActionResult<ServiceMaster> Create(ServiceMaster serviceMaster)
        {
            repository.Insert(serviceMaster);
            return CreatedAtAction(nameof(GetById), new { id = serviceMaster.id }, serviceMaster);
        }

        [HttpGet("{id}")]
        public ActionResult<ServiceMaster> GetById(int id)
        {
            var serviceMaster = repository.GetById(id);
            if (serviceMaster == null)
            {
                return NotFound();
            }
            return serviceMaster;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ServiceMaster>> GetAll()
        {
            return Ok(repository.GetAll());
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ServiceMaster serviceMaster)
        {
            if (id != serviceMaster.id)
            {
                return BadRequest();
            }

            repository.Update(serviceMaster);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            repository.Delete(id);
            return NoContent();
        }
    }
}

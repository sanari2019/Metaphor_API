using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Metaphor_Backend.Models;
using Metaphor_Backend.Repositories;

namespace Metaphor_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusMasterController : ControllerBase
    {
        private readonly StatusMasterRepository repository;

        public StatusMasterController(StatusMasterRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public ActionResult<StatusMaster> CreateStatusMaster(StatusMaster statusMaster)
        {
            repository.Insert(statusMaster);
            return CreatedAtAction(nameof(GetStatusMasterById), new { id = statusMaster.id }, statusMaster);
        }

        [HttpGet("{id}")]
        public ActionResult<StatusMaster> GetStatusMasterById(int id)
        {
            var statusMaster = repository.GetById(id);
            if (statusMaster == null)
            {
                return NotFound();
            }
            return statusMaster;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StatusMaster>> GetAllStatusMasters()
        {
            return Ok(repository.GetAll());
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStatusMaster(int id, StatusMaster statusMaster)
        {
            if (id != statusMaster.id)
            {
                return BadRequest();
            }

            repository.Update(statusMaster);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStatusMaster(int id)
        {
            repository.Delete(id);
            return NoContent();
        }

        // [HttpGet("ByStatusType/{statusType}")]
        // public ActionResult<StatusMaster> GetStatusMasterByStatusType(string statusType)
        // {
        //     var statusMaster = repository.GetStatusMasterByStatusType(statusType);
        //     if (statusMaster == null)
        //     {
        //         return NotFound();
        //     }
        //     return statusMaster;
        // }
         [HttpGet("statusType/{statusType}")]
        public ActionResult<IEnumerable<StatusMaster>> GetStatusMasterByStatusType(string statusType)
        {
            var statusMasters = repository.GetStatusMasterByStatusType(statusType);
            if (statusMasters == null)
            {
                return NotFound();
            }
            return Ok(statusMasters);
        }
    }
}

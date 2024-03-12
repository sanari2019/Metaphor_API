using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Metaphor_Backend.Models;
using Metaphor_Backend.Repositories;

namespace Metaphor_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReferralTypeController : ControllerBase
    {
        private readonly ReferralTypeRepository repository;

        public ReferralTypeController(ReferralTypeRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public ActionResult<ReferralType> CreateReferralType(ReferralType referralType)
        {
            repository.Insert(referralType);
            return CreatedAtAction(nameof(GetReferralTypeById), new { id = referralType.Id }, referralType);
        }

        [HttpGet("{id}")]
        public ActionResult<ReferralType> GetReferralTypeById(int id)
        {
            var referralType = repository.GetById(id);
            if (referralType == null)
            {
                return NotFound();
            }
            return referralType;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReferralType>> GetAllReferralTypes()
        {
            return Ok(repository.GetAll());
        }

        [HttpPut("{id}")]
        public IActionResult UpdateReferralType(int id, ReferralType referralType)
        {
            if (id != referralType.Id)
            {
                return BadRequest();
            }

            repository.Update(referralType);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReferralType(int id)
        {
            repository.Delete(id);
            return NoContent();
        }
    }
}

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Metaphor_Backend.Models;
using Metaphor_Backend.Repositories;

namespace Metaphor_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollectionSiteController : ControllerBase
    {
        private readonly CollectionSiteRepository repository;

        public CollectionSiteController(CollectionSiteRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public ActionResult<CollectionSite> CreateCollectionSite(CollectionSite collectionSite)
        {
            repository.Insert(collectionSite);
            return CreatedAtAction(nameof(GetCollectionSiteById), new { id = collectionSite.Id }, collectionSite);
        }

        [HttpGet("{id}")]
        public ActionResult<CollectionSite> GetCollectionSiteById(int id)
        {
            var collectionSite = repository.GetById(id);
            if (collectionSite == null)
            {
                return NotFound();
            }
            return collectionSite;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CollectionSite>> GetAllCollectionSites()
        {
            return Ok(repository.GetAll());
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCollectionSite(int id, CollectionSite collectionSite)
        {
            if (id != collectionSite.Id)
            {
                return BadRequest();
            }

            repository.Update(collectionSite);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCollectionSite(int id)
        {
            repository.Delete(id);
            return NoContent();
        }
    }
}

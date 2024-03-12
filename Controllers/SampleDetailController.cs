using Microsoft.AspNetCore.Mvc;
using Metaphor_Backend;
using Metaphor_Backend.Repositories;
using Metaphor_Backend.Models;
using Metaphor_Backend.Helpers;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;
using System.Text;
// using Microsoft.IdentityModel.Tokens;
// using System.IdentityModel.Tokens.Jwt;
using Microsoft.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;

namespace Metaphor_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleDetailController : ControllerBase
    {
        private readonly SampleDetailRepository _repository;

        public SampleDetailController(SampleDetailRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public ActionResult<SampleDetail> CreateSampleDetail(SampleDetail sampleDetail)
        {
            _repository.InsertSampleDetail(sampleDetail);
            return CreatedAtAction(nameof(GetSampleDetailById), new { id = sampleDetail.id }, sampleDetail);
        }

        [HttpGet("{id}")]
        public ActionResult<SampleDetail> GetSampleDetailById(int id)
        {
            var sampleDetail = _repository.GetSampleDetailById(id);
            if (sampleDetail == null)
            {
                return NotFound();
            }
            return sampleDetail;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SampleDetail>> GetSampleDetails()
        {
            return Ok(_repository.GetSampleDetails());
        }

        [HttpGet("sampleNo/{sampleNo}")]
        public ActionResult<IEnumerable<SampleDetail>> GetSampleDetailsBySampleNo(int sampleNo)
        {
            return Ok(_repository.GetSampleDetailsBySampleNo(sampleNo));
        }

        // Add other action methods as per your requirements
    }
}

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
    public class EmployeeTypeController : ControllerBase
    {
        private readonly EmployeeTypeRepository _empTypeRepository;

        public EmployeeTypeController(EmployeeTypeRepository empTypeRepository)
        {
            _empTypeRepository = empTypeRepository;
        }

        [HttpGet]
        public IActionResult GetEmpTypes()
        {
            var empTypes = _empTypeRepository.GetEmpTypes();
            return Ok(empTypes);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmpType(int id)
        {
            var empType = _empTypeRepository.GetEmpTypeById(id);
            if (empType == null)
            {
                return NotFound();
            }
            return Ok(empType);
        }

        [HttpPost]
        public IActionResult CreateEmpType([FromBody] EmployeeType empType)
        {
            if (empType == null)
            {
                return BadRequest();
            }
            _empTypeRepository.InsertEmpType(empType);
            return CreatedAtAction(nameof(GetEmpType), new { id = empType.Id }, empType);
        }

        // Add other actions as needed
    }
}
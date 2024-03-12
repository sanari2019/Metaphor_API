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
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentRepository _departmentRepository;

        public DepartmentController(DepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public IActionResult GetDepartments()
        {
            var departments = _departmentRepository.GetDepartments();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public IActionResult GetDepartment(int id)
        {
            var department = _departmentRepository.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpPost]
        public IActionResult CreateDepartment([FromBody] Department department)
        {
            if (department == null)
            {
                return BadRequest();
            }
            _departmentRepository.InsertDepartment(department);
            return CreatedAtAction(nameof(GetDepartment), new { id = department.Id }, department);
        }

        // Add other actions as needed
    }
}
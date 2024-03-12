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
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly UsersRolesRepository _userRoleRepository;

        public EmployeeController(EmployeeRepository employeeRepository, UsersRolesRepository userRoleRepository)
        {
            _employeeRepository = employeeRepository;
            _userRoleRepository = userRoleRepository;
        }

        // GET: api/users
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _employeeRepository.GetUsers();
            return Ok(users);
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _employeeRepository.GetUser(id);
            _employeeRepository.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

    



  




        // POST: api/users
        [HttpPost]
        public IActionResult CreateUser([FromBody] Employee user)
        {

            if (user == null)
            {
                return BadRequest();
            }
            else
            {
                // user.employeeDisplayName = user.firstName + "." + user.lastName;
                // user.encodedDate = DateTime.Now;
                // user.password = EncDscPassword.EncryptPassword(user.password);
                // _employeeRepository.InsertEmployee(user);

                UsersRoles userRole = new UsersRoles
                {
                    // User_Id = user.id,
                    // Username =user.firstName + "." + user.lastName;

                    // Employee_Type_Id = 1,
                    // Created_At = DateTime.Now


                };
                _userRoleRepository.InsertUserRole(userRole);
                return CreatedAtAction(nameof(GetUser), new { id = user.id }, user);
            }
        }





        // PUT: api/users/5
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, Employee user)
        {
            if (id != user.id)
            {
                return BadRequest();
            }

            _employeeRepository.UpdateUser(user);
            return NoContent();
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _employeeRepository.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            _employeeRepository.DeleteUser(user);
            return NoContent();
        }

        // GET: api/users/{userId}/employee-type
        [HttpGet("{userId}/employee-type")]
        public IActionResult GetEmployeeTypeFromUserId(int userId)
        {
            try
            {
                var employeeType = _userRoleRepository.GetEmployeeTypeFromUserId(userId);

                if (employeeType != null)
                {
                    return Ok(employeeType);
                }

                return NotFound(new { Message = "Employee type not found for the specified user ID" });
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                return StatusCode(500, new { Message = $"Internal server error: {ex.Message}" });
            }
        }

        // GET: api/users/{userId}/user-roles
        [HttpGet("{userId}/user-roles")]
        public IActionResult GetUserRolesByUserIdFromView(int userId)
        {
            try
            {
                var userRoles = _userRoleRepository.GetUserRolesByUserIdFromView(userId);

                if (userRoles != null && userRoles.Count > 0)
                {
                    return Ok(userRoles);
                }

                return NotFound(new { Message = "User roles not found for the specified user ID" });
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                return StatusCode(500, new { Message = $"Internal server error: {ex.Message}" });
            }
        }
        [HttpGet("userrole/{user_id}")]
        public IActionResult GetUserRole(int user_id)
        {
            var userRole = _userRoleRepository.GetUserRoleByUserId(user_id);
            if (userRole == null)
            {
                return NotFound();
            }
            return Ok(userRole);
        }
    }
}

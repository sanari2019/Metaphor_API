using Microsoft.AspNetCore.Mvc;
using Metaphor_Backend.Repositories;
using Metaphor_Backend.Models;
using System;
using System.IO;

namespace Metaphor_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientFilesController : ControllerBase
    {
        private readonly PatientFilesRepository _patientFilesRepository;

        public PatientFilesController(PatientFilesRepository patientFilesRepository)
        {
            _patientFilesRepository = patientFilesRepository;
        }

        [HttpPost("upload")]
        public IActionResult UploadImage([FromForm] Microsoft.AspNetCore.Http.IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                // Generate unique file name
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
                var filePath = Path.Combine("wwwroot/images/", fileName); // Save images in wwwroot/images folder

                // Save image to server
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }

                // Save image file path to database
                var imagePathInDatabase = $"/images/{fileName}"; // Assuming 'images' is the virtual path to your images folder
                var patientFilesModel = new PatientFilesModel { filePath = imagePathInDatabase };
                _patientFilesRepository.AddImageAsync(patientFilesModel);

                return Ok(new { imagePath = imagePathInDatabase });
            }
            else
            {
                return BadRequest("No image uploaded or invalid image");
            }
        }

        [HttpGet("{id}/image")]
        public IActionResult GetImage(int id)
        {
            var patientFile = _patientFilesRepository.GetById(id);
            if (patientFile == null)
            {
                return NotFound();
            }

            // Construct the URL for accessing the image in the frontend
            var imageUrl = $"{Request.Scheme}://{Request.Host}/api/patientfiles/image/{id}";

            return Ok(new { imageUrl });
        }

        [HttpGet("image/{id}")]
        public IActionResult GetImageFile(int id)
        {
            var patientFile = _patientFilesRepository.GetById(id);
            if (patientFile == null)
            {
                return NotFound();
            }

            // Construct the file path based on the stored image path
            var filePath = Path.Combine("wwwroot/images/", patientFile.filePath);

            // Read the image file and return it as a file result
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "image/jpeg"); // Adjust content type based on your image type
        }

    }


}

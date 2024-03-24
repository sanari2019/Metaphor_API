using Microsoft.AspNetCore.Mvc;
using Metaphor_Backend.Repositories;
using Metaphor_Backend.Models;
using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using HtmlToOpenXml;
using System.Net;
using PdfSharp;
using TheArtOfDev.HtmlRenderer.PdfSharp;

// using iText.Kernel.Pdf;
// using iText.Layout;
// // using iText.Html2pdf;
// using iText.Layout.Element;
// using iText.Layout.Properties;



namespace Metaphor_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultFilesController : ControllerBase
    {
        private readonly ResultFilesRepository _resultFilesRepository;

        public ResultFilesController(ResultFilesRepository resultFilesRepository)
        {
            _resultFilesRepository = resultFilesRepository;
        }


        // [HttpPost("convert-to-docx")]
        // public IActionResult ConvertToDocx(string htmlContent)
        // {
        //     // Convert HTML content to DOCX format using HtmlToOpenXml library
        //     var htmlToDocxConverter = new HtmlConverter();
        //     var docxBytes = htmlToDocxConverter.ParseHtml(htmlContent, Encoding.UTF8);

        //     // Save the converted DOCX content to a file
        //     var fileName = $"{Guid.NewGuid()}.docx";
        //     var filePath = Path.Combine("wwwroot/files/", fileName);
        //     System.IO.File.WriteAllBytes(filePath, docxBytes);

        //     // Save file path to the database
        //     var filePathInDatabase = $"/files/{fileName}";
        //     var resultFile = new ResultFiles { filePath = filePathInDatabase };
        //     _resultFilesRepository.AddFileAsync(resultFile);

        //     return Ok(new { filePath = filePathInDatabase });
        // }

        // [HttpPost("convert-to-pdf")]
        // public IActionResult ConvertToPdf(string htmlContent)
        // {
        //     // Create a new PDF document
        //     var pdfFileName = $"{Guid.NewGuid()}.pdf";
        //     var pdfFilePath = Path.Combine("wwwroot/files/", pdfFileName);

        //     using (var pdfWriter = new PdfWriter(pdfFilePath))
        //     {
        //         using (var pdfDocument = new Document(pdfWriter))
        //         {
        //             // Convert HTML content to PDF and add it to the document
        //             HtmlConverter.ConvertToPdf(htmlContent, pdfDocument, pdfWriter);
        //         }
        //     }

        //     // Save file path to the database
        //     var filePathInDatabase = $"/files/{pdfFileName}";
        //     var resultFile = new ResultFiles { filePath = filePathInDatabase };
        //     _resultFilesRepository.AddFileAsync(resultFile);

        //     return Ok(new { filePath = filePathInDatabase });
        // }

// [HttpPost("convert-to-pdf")]
//         public IActionResult ConvertToPdf(string htmlContent)
//         {
//             try
//             {
//                 // Generate unique file name for PDF
//                 var pdfFileName = $"{Guid.NewGuid()}.pdf";
//                 var pdfFilePath = Path.Combine("wwwroot/files/", pdfFileName);

//                 // Convert HTML content to PDF and save to file
//                 // Convert HTML content to PDF and save to file
//                 using (FileStream pdfFile = new FileStream(pdfFilePath, FileMode.Create))
//                 {
//                     HtmlConverter.ConvertToPdf(htmlContent, pdfFile);
//                 }

//                 // Save file path to the database
//                 var filePathInDatabase = $"/files/{pdfFileName}";
//                 var resultFile = new ResultFiles { filePath = filePathInDatabase };
//                 _resultFilesRepository.AddFileAsync(resultFile);

//                 return Ok(new { filePath = filePathInDatabase });
//             }
//             catch (Exception ex)
//             {
//                 return StatusCode(500, $"Error converting HTML to PDF: {ex.Message}");
//             }
//         }


        [HttpPost("convert-to-pdf")]
        public IActionResult ConvertToPdf(string htmlContent)
        {
            // Create a new PDF document
            var pdfFileName = $"{Guid.NewGuid()}.pdf";
            var pdfFilePath = Path.Combine("wwwroot/files/", pdfFileName);

            // Convert HTML content to PDF and save to file
            // PdfDocument pdfDocument = PdfGenerator.GeneratePdf(htmlContent, PdfSharp.PageSize.A4);
            // pdfDocument.Save(pdfFilePath);

            // Save file path to the database
            var filePathInDatabase = $"/files/{pdfFileName}";
            var resultFile = new ResultFiles { filePath = filePathInDatabase };
            _resultFilesRepository.AddFileAsync(resultFile);

            return Ok(new { filePath = filePathInDatabase });
        }



        [HttpPost("upload")]
        public IActionResult UploadFile([FromForm] Microsoft.AspNetCore.Http.IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                // Generate unique file name
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                var filePath = Path.Combine("wwwroot/files/", fileName); // Save files in wwwroot/files folder

                // Save file to server
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                // Save file file path to database
                var filePathInDatabase = $"/files/{fileName}"; // Assuming 'files' is the virtual path to your files folder
                var resultFiles = new ResultFiles { filePath = filePathInDatabase };
                _resultFilesRepository.AddFileAsync(resultFiles);

                return Ok(new { filePath = filePathInDatabase });
            }
            else
            {
                return BadRequest("No file uploaded or invalid file");
            }
        }

        [HttpGet("{id}/file")]
        public IActionResult GetFile(int id)
        {
            var resultFile = _resultFilesRepository.GetById(id);
            if (resultFile == null)
            {
                return NotFound();
            }

            // Construct the URL for accessing the file in the frontend
            var fileUrl = $"{Request.Scheme}://{Request.Host}/api/resultfiles/file/{id}";

            return Ok(new { fileUrl });
        }

        // [HttpGet("file/{id}")]
        // public IActionResult GetResuleFile(int id)
        // {
        //     var resultFile = _resultFilesRepository.GetById(id);
        //     if (resultFile == null)
        //     {
        //         return NotFound();
        //     }

        //     // Construct the file path based on the stored file path
        //     var filePath = Path.Combine("wwwroot/files/", resultFile.filePath);

        //     // Read the file file and return it as a file result
        //     var fileBytes = System.IO.File.ReadAllBytes(filePath);
        //     return File(fileBytes, "file/docx"); // Adjust content type based on your file type
        // }

         [HttpGet("file/{id}")]
        public IActionResult GetResultFile(int id)
        {
            var resultFile = _resultFilesRepository.GetById(id);
            if (resultFile == null)
            {
                return NotFound();
            }

            // Construct the file path based on the stored file path
            var filePath = Path.Combine("wwwroot/files/", resultFile.filePath);

            // Check if the file is a DOCX file
            if (Path.GetExtension(filePath).Equals(".docx", StringComparison.OrdinalIgnoreCase))
            {
                // Read the existing DOCX file
                using (var existingDoc = WordprocessingDocument.Open(filePath, false))
                {
                    var newFilePath = Path.Combine("wwwroot/files/", $"{Guid.NewGuid()}.docx");
                    using (var newDoc = WordprocessingDocument.Create(newFilePath, WordprocessingDocumentType.Document))
                    {
                        // Copy the content of the existing DOCX file to the new file
                        foreach (var part in existingDoc.Parts)
                        {
                            newDoc.AddPart(part.OpenXmlPart, part.RelationshipId);
                        }
                    }

                    // Save the new file path to the database
                    var newFilePathInDatabase = $"/files/{Path.GetFileName(newFilePath)}";
                    var newResultFile = new ResultFiles { filePath = newFilePathInDatabase };
                    _resultFilesRepository.AddFileAsync(newResultFile);

                    // Return the new file for download
                    var fileBytes = System.IO.File.ReadAllBytes(newFilePath);
                    return File(fileBytes, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "new_file.docx");
                }
            }
            else
            {
                // Handle if the file is not a DOCX file
                return BadRequest("File is not a DOCX file.");
            }
        }

    }


}

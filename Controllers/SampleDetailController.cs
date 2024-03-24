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
        private readonly SamplePerServiceRepository _samplePerServiceRepository;

        public SampleDetailController(SampleDetailRepository repository, SamplePerServiceRepository samplePerServiceRepository)
        {
            _repository = repository;
            _samplePerServiceRepository = samplePerServiceRepository;
        }
        public enum SampleStatus
        {
            Collected = 2,
            Dispatched = 3,
            Acknowledged = 4,
            InProcessing = 26,
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
        public ActionResult<SampleDetail> GetSampleDetailsBySampleNo(int sampleNo)
        {
            return Ok(_repository.GetSampleDetailsBySampleNo(sampleNo));
        }

        // Add other action methods as per your requirements
        // [HttpPost("update")]
        // public IActionResult UpdateSampleDetail([FromBody] Messageee messageee)
        // {
        //     try
        //     {
        //         var sample = _repository.GetSampleDetailsBySampleNo(messageee.Id);
        //         if (messageee.message == "Collect") {
        //             sample.sampleCollected = true;
        //             sample.collectedBy = messageee.userId;
        //             sample.collectedDate = DateTime.Now;
        //             _repository.UpdateSampleDetail(sample);
        //             var sampe =  _samplePerServiceRepository.GetSamplePerServicesBySampleNo(messageee.Id);
        //             // Update related sample services
        //             var sampleServices = _samplePerServiceRepository.GetSamplePerServicesBySampleNo(messageee.Id);
        //             foreach (var sampleService in sampleServices)
        //             {
        //                 sampleService.statusId = 2;
        //                 _samplePerServiceRepository.UpdateSamplePerService(sampleService);
        //             }
        //         }else if (messageee.message == "Dispatch") {
        //             sample.sampleDispatched = true;
        //             sample.dispatchedBy = messageee.userId;
        //             sample.dispatchDate = DateTime.Now;
        //             _repository.UpdateSampleDetail(sample);
        //             var sampe =  _samplePerServiceRepository.GetSamplePerServicesBySampleNo(messageee.Id);
        //             // Update related sample services
        //             var sampleServices = _samplePerServiceRepository.GetSamplePerServicesBySampleNo(messageee.Id);
        //             foreach (var sampleService in sampleServices)
        //             {
        //                 sampleService.statusId = 3;
        //                 _samplePerServiceRepository.UpdateSamplePerService(sampleService);
        //             }
        //         }else if (messageee.message == "Dept. Acknowledged") {
        //             sample.sampleAcknowledged = true;
        //             sample.acknowledgedBy = messageee.userId;
        //             sample.acknowledgedDate = DateTime.Now;
        //             _repository.UpdateSampleDetail(sample);
        //             var sampe =  _samplePerServiceRepository.GetSamplePerServicesBySampleNo(messageee.Id);
        //             // Update related sample services
        //             var sampleServices = _samplePerServiceRepository.GetSamplePerServicesBySampleNo(messageee.Id);
        //             foreach (var sampleService in sampleServices)
        //             {
        //                 sampleService.statusId = 4;
        //                 _samplePerServiceRepository.UpdateSamplePerService(sampleService);
        //             }
        //         }
            
        //         return Ok(messageee);
        //     }
        //     catch (Exception ex)
        //     {
        //         return StatusCode(500, $"Internal server error: {ex.Message}");
        //     }
        // }

        [HttpPost("update")]
        public IActionResult UpdateSampleDetail([FromBody] Messageee messageee)
        {
            try
            {
                var sample = _repository.GetSampleDetailsBySampleNo(messageee.Id);
                DateTime currentDate = DateTime.Now;

                switch (messageee.message)
                {
                    case "Collect":
                        sample.sampleCollected = true;
                        sample.collectedBy = messageee.userId;
                        sample.collectedDate = currentDate;
                        UpdateSampleServices(messageee.Id, SampleStatus.Collected);
                        break;

                    case "Dispatch":
                        sample.sampleDispatched = true;
                        sample.dispatchedBy = messageee.userId;
                        sample.dispatchDate = currentDate;
                        UpdateSampleServices(messageee.Id, SampleStatus.Dispatched);
                        break;

                    case "Dept. Acknowledged":
                        sample.sampleAcknowledged = true;
                        sample.acknowledgedBy = messageee.userId;
                        sample.acknowledgedDate = currentDate;
                        UpdateSampleServices(messageee.Id, SampleStatus.Acknowledged);
                        break;

                    // case "InProcessing":
                    //     sample.sampleInProcessing = true;
                    //     sample.acknowledgedBy = messageee.userId;
                    //     sample.acknowledgedDate = currentDate;
                    //     UpdateSampleServices(messageee.Id, SampleStatus.Acknowledged);
                    //     break;

                    default:
                        // Handle unknown message
                        break;
                }

                _repository.UpdateSampleDetail(sample);
                return Ok(messageee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private void UpdateSampleServices(int sampleId, SampleStatus status)
        {
            var sampleServices = _samplePerServiceRepository.GetSamplePerServicesBySampleNo(sampleId);
            foreach (var sampleService in sampleServices)
            {
                sampleService.statusId = (int)status;
                _samplePerServiceRepository.UpdateSamplePerService(sampleService);
            }
        }
    
    
    
    
    }
}

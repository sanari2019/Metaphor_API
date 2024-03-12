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
    public class SamplePerServiceController : ControllerBase
    {
        private readonly SamplePerServiceRepository repository;
        private readonly ServiceMasterRepository _serviceMasterRepository;
        private readonly SampleDetailRepository _sampleDetailRepository;

        public SamplePerServiceController(SamplePerServiceRepository repository, ServiceMasterRepository serviceMasterRepository, SampleDetailRepository sampleDetailRepository)
        {
            this.repository = repository;
            _serviceMasterRepository = serviceMasterRepository;
            _sampleDetailRepository = sampleDetailRepository;
        }

        [HttpPost]
        public ActionResult<IEnumerable<SamplePerService>> CreateSamplePerService([FromBody] SamplePerService samplePerService)
        {
            try{
                var latestSampleNo = repository.GetLatestSampleNo();
                    samplePerService.sampleNo = latestSampleNo == null || latestSampleNo == 0
                    ? 10001
                    : latestSampleNo + 1;

                // Iterate through the serviceMaster list
                foreach (var serviceMasterId in samplePerService.serviceMaster)
                {
                    // Retrieve ServiceMaster object by ID
                    var serviceMaster = _serviceMasterRepository.GetById(serviceMasterId);




                    
                    // If the ServiceMaster exists, add it to the SamplePerService
                    if (serviceMaster != null)
                    {
                        // samplePerService.serviceMaster.Add(serviceMaster);
                        samplePerService.serviceId = serviceMaster.id;
                        samplePerService.departmentId = serviceMaster.departmentId;
                        // samplePerService.

                        repository.InsertSamplePerService(samplePerService);
                    }
                    else
                    {
                        // Handle the case where the ServiceMaster with the given ID is not found
                        return BadRequest($"ServiceMaster with ID {serviceMasterId} not found");
                    }
                }
                 // Create a SampleDetail object
                var sampleDetail = new SampleDetail
                {
                    sampleNo = samplePerService.sampleNo,
                    // Set other properties to null or default values
                    sampleCollected = false,
                    collectedBy = false,
                    collectedDate = null,
                    sampleAcknowledged = false,
                    acknowledgedBy = 0,
                    acknowledgedDate = null,
                    sampleDispatched = false,
                    dispatchedBy = 0,
                    dispatchDate = null,
                    cancelled = false,
                    cancelledBy = 0,
                    cancellationReason = null,
                    remarks = null,
                    active = true,
                    encodedBy = 0
                };

                // Insert the SampleDetail into the sampleDetailRepository
                _sampleDetailRepository.InsertSampleDetail(sampleDetail);
                
                var createdSamplePerServices = repository.GetSamplePerServicesBySampleNo(sampleDetail.sampleNo);

                return Ok(createdSamplePerServices);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); // Handle exceptions
            }
        }

        [HttpGet("{id}")]
        public ActionResult<SamplePerService> GetSamplePerServiceById(int id)
        {
            var samplePerService = repository.GetSamplePerServiceById(id);
            if (samplePerService == null)
            {
                return NotFound();
            }
            return samplePerService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SamplePerService>> GetSamplePerServices()
        {
            return Ok(repository.GetSamplePerServices());
        }

        [HttpGet("sampleNo/{sampleNo}")]
        public ActionResult<IEnumerable<SamplePerService>> GetSamplePerServicesBySampleNo(int sampleNo)
        {
            return Ok(repository.GetSamplePerServicesBySampleNo(sampleNo));
        }

        // Add other action methods as per your requirements
    }
}

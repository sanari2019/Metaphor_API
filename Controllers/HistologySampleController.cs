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
    public class HistologySampleController : ControllerBase
    {
        private readonly HistologySampleRepository _histologySampleRepository;
        private readonly SamplePerServiceRepository _samplePerServiceRepository;

        public HistologySampleController(HistologySampleRepository histologySampleRepository, SamplePerServiceRepository samplePerServiceRepository)
        {
            _histologySampleRepository = histologySampleRepository;
            _samplePerServiceRepository = samplePerServiceRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<HistologySample>> GetHistologySamples()
        {
            IEnumerable<HistologySample> histologySamples = _histologySampleRepository.GetHistologySamples();
            if (histologySamples == null)
            {
                return NotFound();
            }
            return Ok(histologySamples);
        }

        [HttpGet("{id}")]
        public IActionResult GetHistologySample(int id)
        {
            var histologySample = _histologySampleRepository.GetHistologySampleById(id);
            if (histologySample == null)
            {
                return NotFound();
            }
            return Ok(histologySample);
        }

        [HttpPost]
        public IActionResult CreateHistologySample([FromBody] HistologySample histologySample)
        {
            if (histologySample == null)
            {
                return BadRequest();
            }
            var latestHistoNo = _histologySampleRepository.GetLatestHistoNo();
                    histologySample.histoNo = latestHistoNo == null || latestHistoNo == 0
                    ? 10001
                    : latestHistoNo + 1;
            var sample = _samplePerServiceRepository.GetSamplePerServiceById(histologySample.sampleNo);
            histologySample.sampleNo =sample.id;
            sample.histoNo = histologySample.histoNo;
            sample.isHistoFilled = true;
            _samplePerServiceRepository.UpdateSamplePerService(sample);
            _histologySampleRepository.InsertHistologySample(histologySample);
            return CreatedAtAction(nameof(GetHistologySample), new { id = histologySample.id }, histologySample);
        }

        [HttpPost("{histoNo}")]
public IActionResult UpdateHistologySample(int histoNo)
{
    if (histoNo == null)
    {
        return BadRequest();
    }

    var histologySample = _histologySampleRepository.GetHistologySampleByHistoNo(histoNo);

    var sampleps = _samplePerServiceRepository.GetSamplePerServiceById(histologySample.sampleNo);
    if (sampleps == null)
    {
        return NotFound();
    }

    UpdateStageAndProperties(histologySample, sampleps);

    _histologySampleRepository.UpdateHistologySample(histologySample);

    return NoContent();
}

private void UpdateStageAndProperties(HistologySample histologySample, SamplePerService sampleps)
{
    if (sampleps.departmentId == 14)
    {
        if (!histologySample.sampleGrossingPerformed)
        {
            UpdateStageAndPropertiesForStage(sampleps, histologySample, 1);
        }
        else if (histologySample.sampleGrossingPerformed && !histologySample.tissueProcessingPerformed)
        {
            UpdateStageAndPropertiesForStage(sampleps, histologySample, 2);
        }
        else if (histologySample.sampleGrossingPerformed && histologySample.tissueProcessingPerformed && !histologySample.embeddingPerformed)
        {
            UpdateStageAndPropertiesForStage(sampleps, histologySample, 3);
        }
        else if (histologySample.sampleGrossingPerformed && histologySample.tissueProcessingPerformed && histologySample.embeddingPerformed && !histologySample.microtomyPerformed)
        {
            UpdateStageAndPropertiesForStage(sampleps, histologySample, 4);
        }
        else if (histologySample.sampleGrossingPerformed && histologySample.tissueProcessingPerformed && histologySample.embeddingPerformed && histologySample.microtomyPerformed && !histologySample.stainingPerformed)
        {
            UpdateStageAndPropertiesForStage(sampleps, histologySample, 5);
        }
    }
}


private void UpdateStageAndPropertiesForStage(SamplePerService sample, HistologySample histologySample, int stageId)
{
    if (sample.stageId != 7)
    {
        if(stageId==5){
            sample.stageId = stageId+2;
        }
        sample.stageId = stageId+1;
        _samplePerServiceRepository.UpdateSamplePerService(sample);

        switch (stageId)
    {
        case 1:
            histologySample.sampleGrossingPerformed = true;
            histologySample.stageId = 1;
            histologySample.sampleGrossingPerformedBy = histologySample.userId;
            histologySample.sampleGrossingPerformedDate = DateTime.Now;
            break;
        case 2:
            histologySample.tissueProcessingPerformed = true;
            histologySample.stageId = 2;
            histologySample.tissueProcessingPerformedBy = histologySample.userId;
            histologySample.tissueProcessingPerformedDate = DateTime.Now;
            break;
        case 3:
            histologySample.embeddingPerformed = true;
            histologySample.stageId = 3;
            histologySample.embeddingPerformedBy = histologySample.userId;
            histologySample.embeddingPerformedDate = DateTime.Now;
            break;
        case 4:
            histologySample.microtomyPerformed = true;
            histologySample.stageId = 4;
            histologySample.microtomyPerformedBy = histologySample.userId;
            histologySample.microtomyPerformedDate = DateTime.Now;
            break;
        case 5:
            histologySample.stainingPerformed = true;
            histologySample.stageId = 5;
            histologySample.stainingPerformedBy = histologySample.userId;
            histologySample.stainingPerformedDate = DateTime.Now;
            break;
    }
    }

    
}


        [HttpGet("histoNo/{histoNo}")]
        public ActionResult<HistologySample> GetHistologySampleByHistoNo(int histoNo)
        {
            return Ok(_histologySampleRepository.GetHistologySampleByHistoNo(histoNo));
        }

        [HttpGet("sampleNo/{sampleNo}")]
        public ActionResult<HistologySample> GetHistologySampleBySampleNo(int sampleNo)
        {
            return Ok(_histologySampleRepository.GetHistologySampleBySampleNo(sampleNo));
        }


        // [HttpDelete("{id}")]
        // public IActionResult DeleteHistologySample(int id)
        // {
        //     var histologySample = _histologySampleRepository.GetHistologySampleById(id);
        //     if (histologySample == null)
        //     {
        //         return NotFound();
        //     }

        //     _histologySampleRepository.DeleteHistologySample(id);
        //     return NoContent();
        // }
    }
}

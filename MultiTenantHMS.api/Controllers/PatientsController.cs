using Microsoft.AspNetCore.Mvc;
using MultiTenantHMS.BLL.Helper;
using MultiTenantHMS.BLL.Services;
using MultiTenantHMS.DAL.Models;
using MultiTenantHMS.BLL.Interfaces;
using MultiTenantHMS.BLL.BL;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MultiTenantHMS.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly ICommonService _service;

        public PatientsController(ICommonService service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddPatient([FromBody] PatientModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest(JsonHelper.Response(false, "Patient data cannot be empty.", null));
                }

                var result = await patient_bl.AddPatient(_service, model);
                if ((bool)result["status"])
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            catch (System.Exception ex)
            {
                await ErrorLogger.LogErrorAsync(ex);
                return StatusCode(500, JsonHelper.Response(false, ex.Message, null));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            try
            {
                var result = await patient_bl.GetPatientById(_service, id);
                if ((bool)result["status"] && result["data"] != null)
                {
                    return Ok(result);
                }

                return NotFound(JsonHelper.Response(false, $"Patient with ID {id} not found.", null));
            }
            catch (System.Exception ex)
            {
                await ErrorLogger.LogErrorAsync(ex);
                return StatusCode(500, JsonHelper.Response(false, ex.Message, null));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            try
            {
                var result = await patient_bl.GetAllPatients(_service);
                if ((bool)result["status"])
                {
                    return Ok(result);
                }

                return NotFound(result);
            }
            catch (System.Exception ex)
            {
                await ErrorLogger.LogErrorAsync(ex);
                return StatusCode(500, JsonHelper.Response(false, ex.Message, null));
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdatePatient([FromBody] PatientModel patient)
        {
            try
            {
                if (patient == null)
                {
                    return BadRequest(JsonHelper.Response(false, "Patient data cannot be empty.", null));
                }

                var result = await patient_bl.UpdatePatient(_service, patient);
                if ((bool)result["status"])
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            catch (System.Exception ex)
            {
                await ErrorLogger.LogErrorAsync(ex);
                return StatusCode(500, JsonHelper.Response(false, ex.Message, null));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            try
            {
                var result = await patient_bl.DeletePatient(_service, id);
                if ((bool)result["status"])
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            catch (System.Exception ex)
            {
                await ErrorLogger.LogErrorAsync(ex);
                return StatusCode(500, JsonHelper.Response(false, ex.Message, null));
            }
        }
    }
}

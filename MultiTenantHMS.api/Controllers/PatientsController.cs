using Microsoft.AspNetCore.Mvc;
using MultiTenantHMS.BLL.Helper;
using MultiTenantHMS.BLL.Interfaces;
using MultiTenantHMS.DAL.Models;
using System.Text.Json;

namespace MultiTenantHMS.api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddPatient(PatientModel model)
        {
            try
            {
                if (model == null)
                {
                    return new JsonResult(JsonHelper.Response(false, "Patient data cannot be empty.", null));
                }

                string result = await _patientService.AddPatientAsync(model);
                if (result != "Success")
                {
                    // Assuming -1 indicates an error or failure from the service layer
                    //return StatusCode(500, "An error occurred while adding the patient.");
                    return new JsonResult(JsonHelper.Response(false, result, null));
                }

                //return Ok(new { Message = "Patient added successfully.", PatientId = result });
                return new JsonResult(JsonHelper.Response(true, "Patient added successfully.", result));
            }
            catch (Exception ex)
            {
                await ErrorLogger.LogErrorAsync(ex);
                // return StatusCode(500, "An unexpected error occurred while processing your request.");
                return new JsonResult(JsonHelper.Response(false, ex.Message.ToString(), null));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            try
            {
                var patient = await _patientService.GetPatientByIdAsync(id);
                if (patient == null)
                {
                    return NotFound($"Patient with ID {id} not found.");
                }
                return Ok(patient);
            }
            catch (Exception ex)
            {
                await ErrorLogger.LogErrorAsync(ex);
                return StatusCode(500, "An error occurred while retrieving the patient.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            try
            {
                var patients = await _patientService.GetAllPatientsAsync();
                return Ok(patients);
            }
            catch (Exception ex)
            {
                await ErrorLogger.LogErrorAsync(ex);
                return StatusCode(500, "An error occurred while retrieving all patients.");
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdatePatient(PatientModel patient)
        {
            try
            {
                if (patient == null)
                {
                    return BadRequest("Patient data cannot be empty.");
                }

                string result = await _patientService.UpdatePatientAsync(patient);
                if (result != "Success")
                {
                    return new JsonResult(JsonHelper.Response(false, result, null));
                }
                return new JsonResult(JsonHelper.Response(true, "Patient updated successfully.", result));
            }
      
            catch (Exception ex)
            {
                await ErrorLogger.LogErrorAsync(ex);
                return new JsonResult(JsonHelper.Response(false, ex.Message.ToString(), null));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            try
            {
                string result = await _patientService.DeletePatientAsync(id);
                if (result != "Success")
                {
                    return new JsonResult(JsonHelper.Response(false, result, null));
                }     
                return new JsonResult(JsonHelper.Response(true, "Patient deleted successfully.", result));
            }
            catch (Exception ex)
            {
                await ErrorLogger.LogErrorAsync(ex);
                return new JsonResult(JsonHelper.Response(false, ex.Message.ToString(), null));
            }
        }
    }
}

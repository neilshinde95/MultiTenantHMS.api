using Microsoft.AspNetCore.Mvc;
using MultiTenantHMS.BLL.BL;
using MultiTenantHMS.BLL.Helper;
using MultiTenantHMS.BLL.Interfaces;
using MultiTenantHMS.DAL.Models;

namespace MultiTenantHMS.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly ICommonService _service;
        public ServiceController(ICommonService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServices()
        {
            try
            {
                var result = await service_bl.GetAllServices(_service);
                if ((bool)result["status"])
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                await ErrorLogger.LogErrorAsync(ex);
                return StatusCode(500, JsonHelper.Response(false, ex.Message, null));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            try
            {
                var result = await service_bl.GetServiceById(_service, id);
                if ((bool)result["status"] && result["data"] != null)
                {
                    return Ok(result);
                }
                return NotFound(JsonHelper.Response(false, $"Service with ID {id} not found.", null));
            }
            catch (Exception ex)
            {
                await ErrorLogger.LogErrorAsync(ex);
                return StatusCode(500, JsonHelper.Response(false, ex.Message, null));
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddService([FromBody] ServiceModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest(JsonHelper.Response(false, "Service data cannot be empty.", null));
                }
                var result = await service_bl.AddService(_service, model);
                if ((bool)result["status"])
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                await ErrorLogger.LogErrorAsync(ex);
                return StatusCode(500, JsonHelper.Response(false, ex.Message, null));
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateService([FromBody] ServiceModel model)
        {
            try
            {
                if (model == null || model.ServiceId <= 0)
                {
                    return BadRequest(JsonHelper.Response(false, "Invalid service data.", null));
                }
                var result = await service_bl.UpdateService(_service, model);
                if ((bool)result["status"])
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                await ErrorLogger.LogErrorAsync(ex);
                return StatusCode(500, JsonHelper.Response(false, ex.Message, null));
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            try
            {
                var result = await service_bl.DeleteService(_service, id);
                if ((bool)result["status"])
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                await ErrorLogger.LogErrorAsync(ex);
                return StatusCode(500, JsonHelper.Response(false, ex.Message, null));
            }
        }
    }
}

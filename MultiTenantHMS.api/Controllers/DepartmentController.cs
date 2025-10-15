using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantHMS.BLL.Interfaces;
using MultiTenantHMS.BLL.Helper;
using MultiTenantHMS.BLL.BL;
using MultiTenantHMS.DAL.Models;


namespace MultiTenantHMS.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ICommonService _service;

        public DepartmentController(ICommonService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            try
            {
                var result = await department_bl.GetAllDepartments(_service);
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

        [HttpPost("add")]
        public async Task<IActionResult> AddDepartment([FromBody] DepartmentModel department)
        {
            try
            {
                if (department == null)
                {
                    return BadRequest(JsonHelper.Response(false, "Department data cannot be empty.", null));
                }

                var result = await department_bl.AddDepartment(_service, department);
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

        [HttpPut("update")]
        public async Task<IActionResult> UpdateDepartment([FromBody] DepartmentModel department)
        {
            try
            {
                if (department == null || department.DepartmentId <= 0)
                {
                    return BadRequest(JsonHelper.Response(false, "Department data cannot be empty.", null));
                }
                var result = await department_bl.UpdateDepartment(_service, department);
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            try
            {
                var result = await department_bl.GetDepartmentById(_service, id);
                if ((bool)result["status"] && result["data"] != null)
                {
                    return Ok(result);
                }
                return NotFound(JsonHelper.Response(false, $"Department with ID {id} not found.", null));
            }
            catch (System.Exception ex)
            {
                await ErrorLogger.LogErrorAsync(ex);
                return StatusCode(500, JsonHelper.Response(false, ex.Message, null));
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            try
            {
                var result = await department_bl.DeleteDepartment(_service, id);
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
    }
}

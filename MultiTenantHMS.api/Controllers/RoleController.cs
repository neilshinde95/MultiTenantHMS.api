using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantHMS.BLL.BL;
using MultiTenantHMS.BLL.Helper;
using MultiTenantHMS.BLL.Interfaces;

namespace MultiTenantHMS.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly ICommonService _service;
        public RoleController(ICommonService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            try
            {
                var result = await role_bl.GetAllRoles(_service);
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

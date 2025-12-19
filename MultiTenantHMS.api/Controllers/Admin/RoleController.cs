using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantHMS.BLL.BL;
using MultiTenantHMS.BLL.Interfaces;
using MultiTenantHMS.DAL.Models;

namespace MultiTenantHMS.api.Controllers.Admin
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

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllRole()
        {
            var response = await role_bl.GetRole(_service);
            return Ok(response);
        }

        [HttpGet("GetById/{roleId}")]
        public async Task<IActionResult> GetRoleById(int roleId)
        {
            if (roleId == 0)
                return NotFound();
            var response = await role_bl.GetRoleById(_service, roleId);
            return Ok(response);
        }

        [HttpPost("addRole")]
        public async Task<IActionResult> AddRole(RoleModel role)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await role_bl.AddRole(_service, role);
            return Ok(response);
        }

        [HttpPut("updateRole")]
        public async Task<IActionResult> UpdateRole(RoleModel role)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await role_bl.UpdateRole(_service, role);
            return Ok(response);
        }

        [HttpDelete("deleteRole/{roleId}")]
        public async Task<IActionResult> DeleteRole(int roleId)
        {
            if (roleId == 0)
                return NotFound();
            var response = await role_bl.DeleteRole(_service, roleId);
            return Ok(response);
        }

    }
}

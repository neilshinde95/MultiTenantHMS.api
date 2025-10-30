using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantHMS.BLL.BL;
using MultiTenantHMS.BLL.Interfaces;
using MultiTenantHMS.DAL.Models;

namespace MultiTenantHMS.api.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICommonService _service;

        public UserController(ICommonService service)
        {
            _service = service;
        }

        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            var user = await user_bl.GetUser(_service);
            return Ok(user);
        }

        [HttpGet("GetUserById/{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            if (userId == 0)
                return NotFound();
            var response = await user_bl.GetUserById(_service, userId);
            return Ok(response);
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(UserModel user)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await user_bl.AddUser(_service, user);
            return Ok(response);
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser (UserModel user)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await user_bl.UpdateUser(_service, user);
            return Ok(response);
        }

        [HttpDelete("DeleteUser/{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            if(userId == 0)
                return NotFound();
            var response = await user_bl.DeleteUser(_service, userId);
            return Ok(response);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantHMS.BLL.Interfaces;

namespace MultiTenantHMS.api.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        //Honey Tested

        private readonly ICommonService _service;
        public RoleController(ICommonService service)
        {
            _service = service;
        }
    }
}

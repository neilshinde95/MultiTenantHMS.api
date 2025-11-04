using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantHMS.BLL.BL;
using MultiTenantHMS.BLL.Interfaces;
using MultiTenantHMS.DAL.Models;

namespace MultiTenantHMS.api.Controllers.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly ICommonService _service;

        public BuildingController(ICommonService commonService)
        {
            _service = commonService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllBuilding()
        {
            var response = await building_bl.GetAllBuildings(_service);
            return Ok(response);
        }

        [HttpGet("GetById/{BuildingId}")]
        public async Task<IActionResult> GetBuildingById(int BuildingId)
        {
            if (BuildingId == 0)
                return NotFound();
            var response = await building_bl.GetBuildingById(_service, BuildingId);
            return Ok(response);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddUser(BuildingModel building)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await building_bl.AddBuilding(_service, building);
            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateBuilding(BuildingModel building)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await building_bl.UpdateBuilding(_service, building);
            return Ok(response);
        }

        [HttpDelete("Delete/{buildingId}")]
        public async Task<IActionResult> DeleteBuilding(int buildingId)
        {
            if (buildingId == 0)
                return NotFound();
            var response = await building_bl.DeleteBuilding(_service, buildingId);
            return Ok(response);
        }
    }
}

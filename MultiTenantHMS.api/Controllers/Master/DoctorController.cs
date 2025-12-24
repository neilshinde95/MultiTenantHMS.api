//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using MultiTenantHMS.BLL.BL;
//using MultiTenantHMS.BLL.Interfaces;
//using MultiTenantHMS.DAL.Models;

//namespace MultiTenantHMS.api.Controllers.Master
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class DoctorController : ControllerBase
//    {
//        private readonly ICommonService _service;

//        public DoctorController(ICommonService commonService)
//        {
//            _service = commonService;
//        }

//        [HttpGet("GetAll")]
//        public async Task<IActionResult> GetAllDoctor()
//        {
//            var response = await doctor_bl.GetAllDoctor(_service);
//            return Ok(response);
//        }

//        [HttpGet("GetById/{doctorId}")]
//        public async Task<IActionResult> GetDoctorById(int doctorId)
//        {
//            if (doctorId == 0)
//                return NotFound();
//            var response = await doctor_bl.GetDoctorById(_service, doctorId);
//            return Ok(response);
//        }

//        [HttpPost("addDoctor")]
//        public async Task<IActionResult> AddDoctor(DocotorModel docotor)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            var response = await doctor_bl.AddDoctor(_service, docotor);
//            return Ok(response);
//        }

//        [HttpPut("updateDoctor")]
//        public async Task<IActionResult> Updatedocotor(DocotorModel docotor)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            var response = await doctor_bl.UpdateDoctor(_service, docotor);
//            return Ok(response);
//        }

//        [HttpDelete("deleteDoctor/{doctorId}")]
//        public async Task<IActionResult> Deletedocotor(int doctorId)
//        {
//            if (doctorId == 0)
//                return NotFound();
//            var response = await doctor_bl.DeleteDoctor(_service, doctorId);
//            return Ok(response);
//        }
//    }
//}

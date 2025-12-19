using MultiTenantHMS.BLL.Helper;
using MultiTenantHMS.BLL.Interfaces;
using MultiTenantHMS.DAL.Models;
using MultiTenantHMS.DAL.Models.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MultiTenantHMS.BLL.BL.Main
{
    public class hospital_bl
    {
        private const string _procedureName = SpCatalog.ManageHospital;

        public static async Task<JsonObject> GetAllHospital(ICommonService service)
        {
            var requestModel = new JsonObject
            {
                ["Id"] = 0,
                ["Opration"] = "s",
                ["ProcedureName"] = _procedureName,
                ["JsonData"] = null
            };
            return await service.ManageAsync(requestModel);
        }
        public static async Task<JsonObject> GetHosspitalById(ICommonService service, int HospitalId)
        {
            var requestModel = new JsonObject
            {
                ["Id"] = HospitalId,
                ["Opration"] = "S", // 'S' for get by id
                ["ProcedureName"] = _procedureName,
                ["JsonData"] = null
            };
            return await service.ManageAsync(requestModel);
        }

        public static async Task<JsonObject> AddHospital(ICommonService service, HospitalModel model)
        {
            var requestModel = new JsonObject
            {
                ["Id"] = 0,
                ["Opration"] = "i", // 'i' for insert
                ["ProcedureName"] = _procedureName,
                ["JsonData"] = JsonHelper.Serialize(model)
            };
            return await service.ManageAsync(requestModel);
        }

        public static async Task<JsonObject> UpdateHospital(ICommonService service, HospitalModel model)
        {
            var requestModel = new JsonObject
            {
                ["Id"] = model.HospitalId,
                ["Opration"] = "u", // 'u' for update
                ["ProcedureName"] = _procedureName,
                ["JsonData"] = JsonHelper.Serialize(model)
            };
            return await service.ManageAsync(requestModel);
        }

        public static async Task<JsonObject> DeleteHospital(ICommonService service, int HospitalId)
        {
            var requestModel = new JsonObject
            {
                ["Id"] = HospitalId,
                ["Opration"] = "d", // 'd' for delete
                ["ProcedureName"] = _procedureName,
                ["JsonData"] = null
            };
            return await service.ManageAsync(requestModel);
        }

    }
}

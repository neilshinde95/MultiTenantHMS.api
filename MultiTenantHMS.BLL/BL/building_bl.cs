using MultiTenantHMS.BLL.Helper;
using MultiTenantHMS.BLL.Interfaces;
using MultiTenantHMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MultiTenantHMS.BLL.BL
{
    public class building_bl
    {
        private const string _procedureName = SpCatalog.ManageBuilding;

        public static async Task<JsonObject> GetAllBuildings(ICommonService service)
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

        public static async Task<JsonObject> AddBuilding(ICommonService service, BuildingModel model)
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

        public static async Task<JsonObject> UpdateBuilding(ICommonService service, BuildingModel model)
        {
            var requestModel = new JsonObject
            {
                ["Id"] = model.BuildingId,
                ["Opration"] = "u", // 'u' for update
                ["ProcedureName"] = _procedureName,
                ["JsonData"] = JsonHelper.Serialize(model)
            };
            return await service.ManageAsync(requestModel);
        }

        public static async Task<JsonObject> DeleteBuilding(ICommonService service, int BuildingId)
        {
            var requestModel = new JsonObject
            {
                ["Id"] = BuildingId,
                ["Opration"] = "d", // 'd' for delete
                ["ProcedureName"] = _procedureName,
                ["JsonData"] = null
            };
            return await service.ManageAsync(requestModel);
        }

        public static async Task<JsonObject> GetBuildingById(ICommonService service, int BuildingId)
        {
            var requestModel = new JsonObject
            {
                ["Id"] = BuildingId,
                ["Opration"] = "S", // 'S' for get by id
                ["ProcedureName"] = _procedureName,
                ["JsonData"] = null
            };
            return await service.ManageAsync(requestModel);
        }
    }
}

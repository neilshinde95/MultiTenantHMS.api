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
    public static class service_bl
    {
        // Implementation for service_bl goes here
        private const string _procedureName = SpCatalog.ManageService;

        public static async Task<JsonObject> AddService(ICommonService service, ServiceModel model)
        {
            var requestModel = new JsonObject
            {
                ["Id"] = 0,
                ["Opration"] = "i",
                ["ProcedureName"] = _procedureName,
                ["JsonData"] = JsonHelper.Serialize(model)
            };
            return await service.ManageAsync(requestModel);
        }

        public static async Task<JsonObject> UpdateService(ICommonService service, ServiceModel model)
        {
            var requestModel = new JsonObject
            {
                ["Id"] = model.ServiceId,
                ["Opration"] = "u",
                ["ProcedureName"] = _procedureName,
                ["JsonData"] = JsonHelper.Serialize(model)
            };
            return await service.ManageAsync(requestModel);
        }

        public static async Task<JsonObject> GetAllServices(ICommonService service)
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

        public static async Task<JsonObject> GetServiceById(ICommonService service, int ServiceId)
        {
            var requestModel = new JsonObject
            {
                ["Id"] = ServiceId,
                ["Opration"] = "s",
                ["ProcedureName"] = _procedureName,
                ["JsonData"] = null
            };
            return await service.ManageAsync(requestModel);
        }

        public static async Task<JsonObject> DeleteService(ICommonService service, int ServiceId)
        {
            var requestModel = new JsonObject
            {
                ["Id"] = ServiceId,
                ["Opration"] = "d",
                ["ProcedureName"] = _procedureName,
                ["JsonData"] = null
            };
            return await service.ManageAsync(requestModel);
        }
    }
}

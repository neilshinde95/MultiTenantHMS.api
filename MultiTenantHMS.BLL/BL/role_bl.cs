using MultiTenantHMS.BLL.Helper;
using MultiTenantHMS.BLL.Interfaces;
using MultiTenantHMS.DAL.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MultiTenantHMS.BLL.BL
{
    public static class role_bl
    {
        // Implementation for role_bl goes here
        private const string _procedureName = SpCatalog.ManageRole;

        public static async Task<JsonObject> AddService(ICommonService service, RoleModel model)
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

        public static async Task<JsonObject> UpdateRole(ICommonService service, RoleModel model)
        {
            var requestModel = new JsonObject
            {
                ["Id"] = model.RoleId,
                ["Opration"] = "u",
                ["ProcedureName"] = _procedureName,
                ["JsonData"] = JsonHelper.Serialize(model)
            };
            return await service.ManageAsync(requestModel);
        }

        public static async Task<JsonObject> GetAllRoles(ICommonService service)
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

        public static async Task<JsonObject> GetRoleById(ICommonService service, int RoleId)
        {
            var requestModel = new JsonObject
            {
                ["Id"] = RoleId,
                ["Opration"] = "s",
                ["ProcedureName"] = _procedureName,
                ["JsonData"] = null
            };
            return await service.ManageAsync(requestModel);
        }

        public static async Task<JsonObject> DeleteRole(ICommonService service, int RoleId)
        {
            var requestModel = new JsonObject
            {
                ["Id"] = RoleId,
                ["Opration"] = "d",
                ["ProcedureName"] = _procedureName,
                ["JsonData"] = null
            };
            return await service.ManageAsync(requestModel);
        }

    }
}

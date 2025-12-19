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
    public class role_bl
    {
        // Implementation for role_bl goes here
        private const string _procedureName = SpCatalog.ManageRole;

        public static async Task<JsonObject> GetRole(ICommonService service)
        {
            try
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
            catch (Exception ex)
            {
                await ErrorLogger.LogErrorAsync(ex); // ensure logging is awaited if it's async
                return JsonHelper.Response(false, "Something went wrong while processing your request.", null);

            }
        }

        public static async Task<JsonObject> GetRoleById(ICommonService service, int roleId)
        {
            try
            {
                var requestModel = new JsonObject
                {
                    ["Id"] = roleId,
                    ["Opration"] = "s",
                    ["ProcedureName"] = _procedureName,
                    ["JsonData"] = null
                };
                return await service.ManageAsync(requestModel);

            }
            catch (Exception ex)
            {
                await ErrorLogger.LogErrorAsync(ex); // ensure logging is awaited if it's async
                return JsonHelper.Response(false, "Something went wrong while processing your request.", null);

            }
        }

        public static async Task<JsonObject> AddRole(ICommonService service, RoleModel role)
        {
            try
            {
                var requestModel = new JsonObject
                {
                    ["Id"] = 0,
                    ["Opration"] = "i",
                    ["ProcedureName"] = _procedureName,
                    ["JsonData"] = JsonHelper.Serialize(role)
                };
                return await service.ManageAsync(requestModel);
            }
            catch (Exception ex)
            {
                await ErrorLogger.LogErrorAsync(ex); // ensure logging is awaited if it's async
                return JsonHelper.Response(false, "Something went wrong while processing your request.", null);
            }
        }

        public static async Task<JsonObject> UpdateRole(ICommonService service, RoleModel role)
        {
            try
            {
                var requestModel = new JsonObject
                {
                    ["Id"] = role.RoleId,
                    ["Opration"] = "u",
                    ["ProcedureName"] = _procedureName,
                    ["JsonData"] = JsonHelper.Serialize(role)
                };
                return await service.ManageAsync(requestModel);
            }
            catch (Exception ex)
            {
                await ErrorLogger.LogErrorAsync(ex); // ensure logging is awaited if it's async
                return JsonHelper.Response(false, "Something went wrong while processing your request.", null);

            }
        }

        public static async Task<JsonObject> DeleteRole(ICommonService service, int roleId)
        {
            try
            {
                var requestModel = new JsonObject
                {
                    ["Id"] = roleId,
                    ["Opration"] = "d",
                    ["ProcedureName"] = _procedureName,
                    ["JsonData"] = null
                };
                return await service.ManageAsync(requestModel);
            }
            catch (Exception ex)
            {
                await ErrorLogger.LogErrorAsync(ex); // ensure logging is awaited if it's async
                return JsonHelper.Response(false, "Something went wrong while processing your request.", null);

            }
        }
    }
}

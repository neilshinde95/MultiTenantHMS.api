using MultiTenantHMS.BLL.Helper;
using MultiTenantHMS.BLL.Interfaces;
using MultiTenantHMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MultiTenantHMS.BLL.BL
{
    public static class user_bl
    {
        private const string _procedureName = SpCatalog.ManageUser;

        public static async Task<JsonObject> GetUser (ICommonService service)
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

        public static async Task<JsonObject> GetUserById(ICommonService service, int userId)
        {
            try
            {
                var requestModel = new JsonObject
                {
                    ["Id"] = userId,
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
    
        public static async Task<JsonObject> AddUser(ICommonService service, UserModel user)
        {
            try
            {
                var requestModel = new JsonObject
                {
                    ["Id"] = 0,
                    ["Opration"] = "i",
                    ["ProcedureName"] = _procedureName,
                    ["JsonData"] = JsonHelper.Serialize(user)
                };
                return await service.ManageAsync(requestModel);
            }
            catch (Exception ex)
            {
                await ErrorLogger.LogErrorAsync(ex); // ensure logging is awaited if it's async
                return JsonHelper.Response(false, "Something went wrong while processing your request.", null);
            }
        }

        public static async Task<JsonObject> UpdateUser(ICommonService service, UserModel user)
        {
            try
            {
                var requestModel = new JsonObject
                {
                    ["Id"] = user.UserId,
                    ["Opration"] = "u",
                    ["ProcedureName"] = _procedureName,
                    ["JsonData"] = JsonHelper.Serialize(user)
                };
                return await service.ManageAsync(requestModel);
            }
            catch (Exception ex)
            {
                await ErrorLogger.LogErrorAsync(ex); // ensure logging is awaited if it's async
                return JsonHelper.Response(false, "Something went wrong while processing your request.", null);

            }
        }

        public static async Task<JsonObject> DeleteUser(ICommonService service, int userId)
        {
            try
            {
                var requestModel = new JsonObject
                {
                    ["Id"] = userId,
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

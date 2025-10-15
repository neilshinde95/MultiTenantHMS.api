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
    public static class department_bl
    {
        private const string _procedureName = SpCatalog.ManageDepartment;

        public static async Task<JsonObject> GetAllDepartments(ICommonService service)
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

        public static async Task<JsonObject> AddDepartment(ICommonService service, DepartmentModel model)
        {
            var requestModel = new JsonObject
            {
                ["Id"] = 0,
                ["Opration"] = "i", // 'i' for insert
                ["ProcedureName"] = _procedureName,
                ["JsonData"] = Newtonsoft.Json.JsonConvert.SerializeObject(model)
            };
            return await service.ManageAsync(requestModel);
        }

        public static async Task<JsonObject> UpdateDepartment(ICommonService service, DepartmentModel model)
        {
            var requestModel = new JsonObject
            {
                ["Id"] = model.DepartmentId,
                ["Opration"] = "u", // 'u' for update
                ["ProcedureName"] = _procedureName,
                ["JsonData"] = Newtonsoft.Json.JsonConvert.SerializeObject(model)
            };
            return await service.ManageAsync(requestModel);
        }

        public static async Task<JsonObject> DeleteDepartment(ICommonService service, int departmentId)
        {
            var requestModel = new JsonObject
            {
                ["Id"] = departmentId,
                ["Opration"] = "d", // 'd' for delete
                ["ProcedureName"] = _procedureName,
                ["JsonData"] = null
            };
            return await service.ManageAsync(requestModel);
        }

        public static async Task<JsonObject> GetDepartmentById(ICommonService service, int departmentId)
        {
            var requestModel = new JsonObject
            {
                ["Id"] = departmentId,
                ["Opration"] = "S", // 'S' for get by id
                ["ProcedureName"] = _procedureName,
                ["JsonData"] = null
            };
            return await service.ManageAsync(requestModel);
        }
    }
}

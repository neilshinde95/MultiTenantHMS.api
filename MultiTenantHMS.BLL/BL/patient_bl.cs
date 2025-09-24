using MultiTenantHMS.BLL.Helper;
using MultiTenantHMS.BLL.Services;
using MultiTenantHMS.DAL.Models;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using MultiTenantHMS.BLL.Interfaces;

namespace MultiTenantHMS.BLL.BL
{
    public static class patient_bl
    {
        private const string _procedureName = "sp_manage_patient";

        public static async Task<JsonObject> AddPatient(ICommonService service, PatientModel model)
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

        public static async Task<JsonObject> UpdatePatient(ICommonService service, PatientModel model)
        {
            var requestModel = new JsonObject
            {
                ["Id"] = model.PatientId,
                ["Opration"] = "u",
                ["ProcedureName"] = _procedureName,
                ["JsonData"] = JsonHelper.Serialize(model)
            };
            return await service.ManageAsync(requestModel);
        }

        public static async Task<JsonObject> GetAllPatients(ICommonService service)
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

        public static async Task<JsonObject> GetPatientById(ICommonService service, int patientId)
        {
            var requestModel = new JsonObject
            {
                ["Id"] = patientId,
                ["Opration"] = "s",
                ["ProcedureName"] = _procedureName,
                ["JsonData"] = null
            };
            return await service.ManageAsync(requestModel);
        }

        public static async Task<JsonObject> DeletePatient(ICommonService service, int patientId)
        {
            var requestModel = new JsonObject
            {
                ["Id"] = patientId,
                ["Opration"] = "d",
                ["ProcedureName"] = _procedureName,
                ["JsonData"] = null
            };
            return await service.ManageAsync(requestModel);
        }
    }
}

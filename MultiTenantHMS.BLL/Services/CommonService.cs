using Microsoft.Extensions.Configuration;
using MultiTenantHMS.BLL.Helper;
using MultiTenantHMS.BLL.Interfaces;
using MultiTenantHMS.DAL.Models;
using System;
using System.Data;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MultiTenantHMS.BLL.Services
{
    // This class handles the common database operations for the application.
    public class CommonService : ICommonService
    {
        private readonly DbHelper _dbHelper;

        public CommonService(IConfiguration configuration)
        {
            _dbHelper = new DbHelper(configuration.GetConnectionString("DefaultConnection"));
        }
        public async Task<JsonObject> ManageAsync(JsonObject model)
        {
            try
            {
                if (model == null)
                {
                    return JsonHelper.Response(false, "Invalid request data.", null);
                }

                // Extract properties from the JsonObject.
                // Using a safe access pattern with ?. to avoid NullReferenceExceptions.
                var id = model["Id"]?.GetValue<int>() ?? 0;
                var operation = model["Opration"]?.GetValue<string>();
                var procedureName = model["ProcedureName"]?.GetValue<string>();
                var jsonData = model["JsonData"]?.ToString();

                // Execute the stored procedure and get the results as a DataSet.
                var dataSet = await _dbHelper.ExecuteDataSetAsync(procedureName,
                    parameters =>
                    {
                        parameters.AddWithValue("@id", id);
                        parameters.AddWithValue("@operation", operation);
                        parameters.AddWithValue("@jsondata", (object)jsonData ?? DBNull.Value);
                    });

                // Since we're expecting all operations to return data,
                // we'll process the first table of the DataSet.
                var resultTable = dataSet.Tables[0];
                return JsonHelper.Response(true, "Success", resultTable);
            }
            catch (Exception ex)
            {
                // Log the error and return a detailed error response.
                await ErrorLogger.LogErrorAsync(ex);
                return JsonHelper.Response(false, ex.Message, null);
            }
        }
    }
}

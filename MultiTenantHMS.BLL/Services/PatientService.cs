using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MultiTenantHMS.BLL.Interfaces;
using MultiTenantHMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MultiTenantHMS.BLL.Helper;
using Newtonsoft.Json;

namespace MultiTenantHMS.BLL.Services
{
    public class PatientService : IPatientService
    {
        private readonly DbHelper _dbHelper;

        public PatientService(IConfiguration configuration)
        {
            _dbHelper = new DbHelper(configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<string> AddPatientAsync(PatientModel patient)
        {
            try
            {
                var patientJson = JsonHelper.Serialize(patient);
                if (patient == null)
                {
                    // Handle invalid JSON input
                    throw new ArgumentException("Invalid patient JSON data.");
                }

                var js = patient.ToString();

                var dataSet = await _dbHelper.ExecuteDataSetAsync("sp_manage_patient",
                     parameters =>
                     {
                         parameters.AddWithValue("@id", DBNull.Value);
                         parameters.AddWithValue("@operation", "i");
                         parameters.AddWithValue("@jsondata", patientJson);
                     });

                return dataSet.Tables[0].Rows[0].ToString() != null ? "Success" : "";
            }
            catch (Exception ex)
            {
                await ErrorLogger.LogErrorAsync(ex);
                return ex.Message.ToString();
            }
        }

        public async Task<ResponseModel> GetPatientByIdAsync(int patientId)
        {
            try
            {
                
                var dataSet = await _dbHelper.ExecuteDataSetAsync("sp_manage_patient",
             parameters =>
             {
                 parameters.AddWithValue("@id", patientId);
                 parameters.AddWithValue("@operation", "s");
                 parameters.AddWithValue("@jsondata", DBNull.Value);
             });

                // If the operation is successful, create a success ResponseModel
                return new ResponseModel
                {
                    status = true,
                    msg = "Patients retrieved successfully.",
                    data = JsonConvert.SerializeObject(dataSet.Tables[0]) // The List<PatientModel> object is assigned to the 'object' data field
                };
            }
            catch (Exception ex)
            {
                await ErrorLogger.LogErrorAsync(ex);
                return null;
            }
        }

        public async Task<ResponseModel> GetAllPatientsAsync()
        {
            try
            {
                var dataSet = await _dbHelper.ExecuteDataSetAsync("sp_manage_patient",
             parameters =>
             {
                 parameters.AddWithValue("@id", DBNull.Value);
                 parameters.AddWithValue("@operation", "s");
                 parameters.AddWithValue("@jsondata", DBNull.Value);
             });

                // If the operation is successful, create a success ResponseModel
                return new ResponseModel
                {
                    status = true,
                    msg = "Patients retrieved successfully.",
                    data = JsonConvert.SerializeObject(dataSet.Tables[0]) // The List<PatientModel> object is assigned to the 'object' data field
                };
            }
            catch (Exception ex)
            {
                await ErrorLogger.LogErrorAsync(ex);
                return new ResponseModel
                {
                    status = false,
                    msg = ex.Message.ToString(),
                    data = null // Set data to null or an empty list on failure
                };
            }
        }

        public async Task<string> UpdatePatientAsync(PatientModel patient)
        {
            try
            {
                var patientJson = JsonHelper.Serialize(patient);
                if (patient == null)
                {
                    throw new ArgumentException("Invalid patient JSON data.");
                }


                var dataSet = await _dbHelper.ExecuteDataSetAsync("sp_manage_patient",
                     parameters =>
                     {
                         parameters.AddWithValue("@id", patient.PatientId);
                         parameters.AddWithValue("@operation", "u");
                         parameters.AddWithValue("@jsondata", patientJson);
                     });

                return dataSet.Tables[0].Rows[0].ToString() != null ? "Success" : "";
            }
            catch (Exception ex)
            {
                await ErrorLogger.LogErrorAsync(ex);
                return ex.Message.ToString();
            }
        }

        public async Task<string> DeletePatientAsync(int patientId)
        {
            try
            {

                var dataSet = await _dbHelper.ExecuteDataSetAsync("sp_manage_patient",
                     parameters =>
                     {
                         parameters.AddWithValue("@id", patientId);
                         parameters.AddWithValue("@operation", "d");
                         parameters.AddWithValue("@jsondata", DBNull.Value);
                     });

                return dataSet.Tables[0].Rows[0].ToString() != null ? "Success" : "";
            }
            catch (Exception ex)
            {
                await ErrorLogger.LogErrorAsync(ex);
                return ex.Message.ToString();
            }
        }
    }
}

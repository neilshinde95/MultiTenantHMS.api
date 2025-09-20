using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenantHMS.DAL.Models;

namespace MultiTenantHMS.BLL.Interfaces
{
    public interface IPatientService
    {
        Task<string> AddPatientAsync(PatientModel model);
        Task<ResponseModel> GetPatientByIdAsync(int patientId);
        Task<ResponseModel> GetAllPatientsAsync();
        Task<string> UpdatePatientAsync(PatientModel patient);
        Task<string> DeletePatientAsync(int patientId);
    }
}

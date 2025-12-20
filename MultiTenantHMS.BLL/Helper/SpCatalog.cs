using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantHMS.BLL.Helper
{
    public static class SpCatalog
    {
        #region Master
        public const string ManagePatient = "sp_manage_patient";
        public const string ManageBuilding = "sp_manage_building";
        public const string ManageDepartment = "sp_manage_department";
        public const string ManageService = "sp_manage_service";
        public const string ManageDoctor = "sp_manage_doctor";
        public const string ManageLab = "sp_manage_lab";
        public const string ManageUser = "sp_manage_user";
        public const string ManageRole = "sp_manage_role";
        public const string ManageHospital = "sp_manage_hospital";

        #endregion
        //public const string ManageService = "sp_manage_service";
        //public const string ManageRole = "sp_manage_role";
    }
}

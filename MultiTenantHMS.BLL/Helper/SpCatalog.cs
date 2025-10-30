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

        public const string ManageDepartment = "sp_manage_department";

        public const string ManageService = "sp_manage_service";
        #endregion

        #region Admin 
        public const string ManageUser = "sp_manage_user";
        public const string ManageRole = "sp_manage_role";
        #endregion
    }
}

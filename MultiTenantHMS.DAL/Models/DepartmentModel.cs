using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MultiTenantHMS.DAL.Models
{
    public class DepartmentModel
    {
        [JsonPropertyName("departmentId")]
        public int DepartmentId { get; set; }

        [JsonPropertyName("departmentname")]
        public string DepartmentName { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("createdon")]
        public DateTime? CreatedOn { get; set; }

        [JsonPropertyName("craetedby")]
        public string CreatedBy { get; set; }

        [JsonPropertyName("modifyon")]
        public DateTime? ModifyOn { get; set; }

        [JsonPropertyName("modifyby")]
        public string ModifyBy { get; set; }

        [JsonPropertyName("isdeleted")]
        public int IsDeleted { get; set; }




//        CREATE TABLE tblDepartment
//(
//    departmentId INT IDENTITY(1, 1) NOT NULL,
//    departmentName varchar(100) NOT NULL,
//    description varchar(200) NULL,
//    Status bit NOT NULL,
//    CreatedOn datetime NULL,
//    CreatedBy nvarchar(100) NULL,
//    ModifyOn datetime NULL,
//    ModifyBy nvarchar(100) NULL,
//    IsDeleted bit NOT NULL
//)
    }
}

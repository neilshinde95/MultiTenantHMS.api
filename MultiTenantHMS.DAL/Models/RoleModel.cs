
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MultiTenantHMS.DAL.Models
{
    public class RoleModel
    {
        [JsonPropertyName("RoleId")]
        public int RoleId { get; set; }

        [JsonPropertyName("RoleName")]
        public string RoleName { get; set; } = string.Empty;

        [JsonPropertyName("RoleDescription")]
        public string RoleDescription { get; set; } = string.Empty;
               
        [JsonPropertyName("Status")]
        public int Status { get; set; }

        [JsonPropertyName("CreatedOn")]
        public DateTime? CreatedOn { get; set; }

        [JsonPropertyName("CreatedBy")]
        public string? CreatedBy { get; set; }

        [JsonPropertyName("ModifyOn")]
        public DateTime? ModifyOn { get; set; }

        [JsonPropertyName("ModifyBy")]
        public string? ModifyBy { get; set; }

        [JsonPropertyName("IsDeleted")]
        public int IsDeleted { get; set; }


    }
}

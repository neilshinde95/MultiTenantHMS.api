using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MultiTenantHMS.DAL.Models
{
    public class UserModel
    {
        [JsonPropertyName("UserId")]
        public int UserId { get; set; }

        [JsonPropertyName("RoleId")]
        public int RoleId { get; set; }

        [JsonPropertyName("HospitalId")]
        public int HospitalId { get; set; }

        [JsonPropertyName("UserName")]
        public string UserName { get; set; } = string.Empty;

        [JsonPropertyName("UserEmail")]
        public string UserEmail { get; set; } = string.Empty;

        [JsonPropertyName("Password")]
        public string Password { get; set; } = string.Empty;

        [JsonPropertyName("UserContact")]
        public string UserContact { get; set; } = string.Empty;

        [JsonPropertyName("CountryId")]
        public int CountryId { get; set; } = 0;

        [JsonPropertyName("StateId")]
        public int StateId { get; set; } = 0;

        [JsonPropertyName("ProfileImg")]
        public string ProfileImg { get; set; } = string.Empty;

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

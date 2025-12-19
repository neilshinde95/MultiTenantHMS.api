using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MultiTenantHMS.DAL.Models
{
    public class DocotorModel
    {
        [JsonPropertyName("DoctorId")]
        public int DoctorId { get; set; }

        [JsonPropertyName("HospitalId")]
        public int HospitalId { get; set; }

        [JsonPropertyName("DoctorName")]
        public string DoctorName { get; set; } = string.Empty;

        [JsonPropertyName("DoctorEmail")]
        public string DoctorEmail { get; set; } = string.Empty;
        
        [JsonPropertyName("SpecializationId")]
        public int SpecializationId { get; set; }
        
        [JsonPropertyName("ProfileImg")]
        public string ProfileImg { get; set; } = string.Empty;

        [JsonPropertyName("Address")]
        public string Address { get; set; } = string.Empty;

        [JsonPropertyName("Status")]
        public int Status { get; set; }

        [JsonPropertyName("CreatedOn")]
        public DateTime? CreatedOn { get; set; }

        [JsonPropertyName("Createdby")]
        public string? CreatedBy { get; set; }

        [JsonPropertyName("ModifyOn")]
        public DateTime? ModifyOn { get; set; }

        [JsonPropertyName("Modifyby")]
        public string? ModifyBy { get; set; }

        [JsonPropertyName("IsDeleted")]
        public int IsDeleted { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MultiTenantHMS.DAL.DTO_s
{
    public class PatientDTO
    {
        [JsonPropertyName("patientname")]
        [Required]
        public string PatientName { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("dateOfbirth")]
        public DateTime? DateOfBirth { get; set; }

        [JsonPropertyName("contactnumber")]
        [Required]
        public string ContactNumber { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("emergencycontact")]
        public string EmergencyContact { get; set; }

        [JsonPropertyName("bloodgroup")]
        public string BloodGroup { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("createdby")]
        public string CreatedBy { get; set; }

        [JsonPropertyName("modifyby")]
        public string ModifyBy { get; set; }

        [JsonPropertyName("isdeleted")]
        public bool IsDeleted { get; set; }
    }
}

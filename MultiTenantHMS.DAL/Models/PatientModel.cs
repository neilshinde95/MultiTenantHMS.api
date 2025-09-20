using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MultiTenantHMS.DAL.Models
{
    public class PatientModel
    {
        [JsonPropertyName("patientId")]
        public int PatientId { get; set; }

        [JsonPropertyName("patientname")]
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
        public int Status { get; set; }

        [JsonPropertyName("createdon")]
        public DateTime? CreatedOn { get; set; }

        [JsonPropertyName("createdby")]
        public string CreatedBy { get; set; }

        [JsonPropertyName("modifyon")]
        public DateTime? ModifyOn { get; set; }

        [JsonPropertyName("modifyby")]
        public string ModifyBy { get; set; }

        [JsonPropertyName("isdeleted")]
        public int IsDeleted { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MultiTenantHMS.DAL.Models.Main
{
    public class HospitalModel
    {
        [JsonPropertyName("HospitalId")]
        public int HospitalId { get; set; }

        [JsonPropertyName("HospitalName")]
        public string HospitalName { get; set; } = string.Empty;

        [JsonPropertyName("Address")]
        public string Address { get; set; } = string.Empty;


        [JsonPropertyName("City")]
        public string City { get; set; } = string.Empty;

        [JsonPropertyName("State")]
        public string State { get; set; } = string.Empty;

        [JsonPropertyName("Country")]
        public string Country { get; set; } = string.Empty;

        [JsonPropertyName("ContactNumber")]
        public string ContactNumber { get; set; } = string.Empty;
        [JsonPropertyName("Email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("Website")]
        public string Website { get; set; } = string.Empty;

        [JsonPropertyName("LogoPath")]
        public string LogoPath { get; set; } = string.Empty;

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MultiTenantHMS.DAL.Models
{
    public class ServiceModel
    {
        [JsonPropertyName("serviceId")]
        public int ServiceId
        {
            get;
            set;
        }

        [JsonPropertyName("servicename")]
        public string? ServiceName
        {
            get;
            set;
        }

        [JsonPropertyName("servicecode")]
        public string? ServiceCode
        {
            get;
            set;
        }

        [JsonPropertyName("servicetype")]
        public string? ServiceType
        {
            get;
            set;
        }

        [JsonPropertyName("chargetype")]
        public string? ChargeType
        {
            get;
            set;
        }
        [JsonPropertyName("amount")]
        public decimal Amount
        {
            get;
            set;
        }

        [JsonPropertyName("remarks")]
        public string? Remarks
        {
            get;
            set;
        }

        [JsonPropertyName("status")]
        public int Status
        {
            get;
            set;
        }

        [JsonPropertyName("createdon")]
        public DateTime? CreatedOn
        {
            get;
            set;
        }
        [JsonPropertyName("createdby")]
        public string? CreatedBy
        {
            get;
            set;
        }

        [JsonPropertyName("modifyon")]
        public DateTime? ModifyOn
        {
            get;
            set;
        }

        [JsonPropertyName("modifyby")]
        public string? ModifyBy
        {
            get;
            set;
        }

        [JsonPropertyName("isdeleted")]
        public int IsDeleted { get; set; }
    }
}
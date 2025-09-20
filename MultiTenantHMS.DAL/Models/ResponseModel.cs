using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantHMS.DAL.Models
{
    public class ResponseModel
    {
        public bool status {  get; set; }
        public string? msg { get; set; }
        public dynamic? data { get; set; }
    }
}

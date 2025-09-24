using MultiTenantHMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MultiTenantHMS.BLL.Interfaces
{
    public interface ICommonService
    {
        Task<JsonObject> ManageAsync(JsonObject model);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MultiTenantHMS.BLL.Helper
{
    public static class JsonHelper
    {
        /// <summary>
        /// Serializes a C# object to a JSON string.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialize.</typeparam>
        /// <param name="obj">The object to serialize.</param>
        /// <returns>A JSON string representation of the object.</returns>
        public static string Serialize<T>(T obj)
        {
            // Use JsonSerializer for efficient and modern serialization.
            return JsonSerializer.Serialize(obj);
        }

        /// <summary>
        /// Deserializes a JSON string to a C# object.
        /// </summary>
        /// <typeparam name="T">The type of the object to deserialize to.</typeparam>
        /// <param name="json">The JSON string to deserialize.</param>
        /// <returns>The deserialized object.</returns>
        public static T Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }

        public static dynamic Response(bool status, string msg, object data)
        {
            var response = new JsonObject 
            { 
                ["status"] = status, 
                ["msg"] = msg, 
                ["data"] = Newtonsoft.Json.JsonConvert.SerializeObject(data) 
            };
            return response;
        }
    }
}

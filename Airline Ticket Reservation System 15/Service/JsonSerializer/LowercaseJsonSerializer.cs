using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Service.JsonSerializer
{
    public class LowercaseJsonSerializer
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            ContractResolver = new LowercaseContractResolver()
        };

        public static string SerializeObject(object o)
        {
            return JsonConvert.SerializeObject(o, Formatting.Indented, Settings);
        }

        public class LowercaseContractResolver : DefaultContractResolver
        {
            protected override string ResolvePropertyName(string propertyName)
            {
                return char.ToLowerInvariant(propertyName[0]) + propertyName.Substring(1);
            }
        }
    }
}

using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GovukRegistersApiClientNet.Implementation.Helpers
{
    public class DashToUnderscoreJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);

            foreach (var property in jObject.Properties().ToList())
            {
                if (property.Name.Contains("-"))
                {
                    var name = property.Name.Replace("-", "_");
                    property.Replace(new JProperty(name, property.Value));
                }
            }

            return jObject;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}

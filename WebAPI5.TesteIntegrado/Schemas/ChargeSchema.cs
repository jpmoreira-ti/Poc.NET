using System.IO;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace WebAPI5.TesteIntegrado.Schemas
{
    public class ChargeSchema
    {
        public static string ReadSchema(string SchemaName)
        {            
            return File.ReadAllText("./Schemas/" + SchemaName + ".json");
        }

        public static bool IsValidSchemaObject(string SchemaName, string jsonResponse)
        {
            // USAR ESTE CASO, RETORNE UM OBJETO
            JObject data = JObject.Parse(jsonResponse);

            var jsonFile = ChargeSchema.ReadSchema("WeatherSchema");
            var jsonSchema = JSchema.Parse(jsonFile);

            bool valid = data.IsValid(jsonSchema);

            return valid;
        }

        public static bool IsValidSchemaArray(string SchemaName, string jsonResponse)
        {
            // USAR ESTE CASO, RETORNE UM OBJETO
            var data = JArray.Parse(jsonResponse);

            var jsonFile = ChargeSchema.ReadSchema("WeatherSchema");
            var jsonSchema = JSchema.Parse(jsonFile);

            bool valid = data.IsValid(jsonSchema);

            return valid;
        }
    }
}
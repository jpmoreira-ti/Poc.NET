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
            if (string.IsNullOrEmpty(SchemaName))
            {
                throw new System.ArgumentException($"'{nameof(SchemaName)}' cannot be null or empty.", nameof(SchemaName));
            }

            if (string.IsNullOrEmpty(jsonResponse))
            {
                throw new System.ArgumentException($"'{nameof(jsonResponse)}' cannot be null or empty.", nameof(jsonResponse));
            }
            // USAR ESTE CASO, RETORNE UM OBJETO
            JObject data = JObject.Parse(jsonResponse);

            var jsonFile = ChargeSchema.ReadSchema(SchemaName);
            var jsonSchema = JSchema.Parse(jsonFile);

            bool valid = data.IsValid(jsonSchema);

            return valid;
        }

        public static bool IsValidSchemaArray(string SchemaName, string jsonResponse)
        {
            if (string.IsNullOrEmpty(SchemaName))
            {
                throw new System.ArgumentException($"'{nameof(SchemaName)}' cannot be null or empty.", nameof(SchemaName));
            }

            if (string.IsNullOrEmpty(jsonResponse))
            {
                throw new System.ArgumentException($"'{nameof(jsonResponse)}' cannot be null or empty.", nameof(jsonResponse));
            }

            // USAR ESTE CASO, RETORNE UM ARRAY
            var data = JArray.Parse(jsonResponse);

            var jsonFile = ChargeSchema.ReadSchema(SchemaName);
            var jsonSchema = JSchema.Parse(jsonFile);

            bool valid = data.IsValid(jsonSchema);

            return valid;
        }
    }
}
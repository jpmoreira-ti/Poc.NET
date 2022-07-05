using System.IO;

namespace WebAPI5.TesteIntegrado.Schemas
{
    public class ChargeSchema
    {
        public static string ReadSchema(string SchemaName)
        {            
            return File.ReadAllText("./Schemas/" + SchemaName + ".json");
        }
    }
}
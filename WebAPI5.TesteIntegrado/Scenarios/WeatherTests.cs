using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using WebAPI5.TesteIntegrado.Fixtures;
using WebAPI5.TesteIntegrado.Schemas;
using Xunit;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;
using System;

namespace WebAPI5.TesteIntegrado
{
    public class WeatherTests
    {
        private readonly TestContext _testContext;
        private string jsonResponse;
        private string jsonFile;

        public WeatherTests()
        {
            _testContext = new TestContext();
        }

        [Fact]
        [Obsolete]
        public async Task GetShouldReturnOk()
        {
            var response = await _testContext.Client.GetAsync("/WeatherForecast");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            jsonResponse = await response.Content.ReadAsStringAsync();

            var data = JArray.Parse(jsonResponse);

            // USAR ESTE CASO, RETORNE UM OBJETO
            //JObject data = JObject.Parse(json);

            jsonFile = ChargeSchema.ReadSchema("WeatherSchema");
            var jsonSchema = JSchema.Parse(jsonFile);

            bool valid = data.IsValid(jsonSchema);
          
            valid.Should().BeTrue();
        }
    }
}


using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using WebAPI5.TesteIntegrado.Fixtures;
using WebAPI5.TesteIntegrado.Schemas;
using Xunit;
using System;

namespace WebAPI5.TesteIntegrado
{
    public class WeatherTests
    {
        private readonly TestContext _testContext;
        private string jsonResponse;

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
            ChargeSchema.IsValidSchemaArray("WeatherSchema", jsonResponse).Should().BeTrue();
        }
    }
}


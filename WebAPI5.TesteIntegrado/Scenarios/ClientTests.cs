using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using WebAPI5.TesteIntegrado.Fixtures;
using Xunit;
using System.Net.Http.Json;
using WebAPI5.Models;
using WebAPI5.TesteIntegrado.Schemas;

namespace WebAPI5.TesteIntegrado
{
    public class ClientTests
    {
        private readonly TestContext _testContext;
        private string jsonResponse;

        public ClientTests()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task CreateShouldReturnOk()
        {
            Client client = new()
            {
                Name = "João",
               Document = "17418609035"
            };

            var response = await _testContext.Client.PostAsJsonAsync("/Client", client);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            jsonResponse = await response.Content.ReadAsStringAsync();
            ChargeSchema.IsValidSchemaObject("ClientSchema", jsonResponse).Should().BeTrue();
        }

        [Fact]
        public async Task GetOneShouldReturnOk()
        {
            Client client = new()
            {
                Document = "17418609035"
            };

            var response = await _testContext.Client.GetAsync("/Client/" + client);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetAllShouldReturnOk()
        {
            var response = await _testContext.Client.GetAsync("/Client");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task RemoveShouldReturnOk()
        {
            Client client = new()
            {
                Document = "17418609035"
            };

            var response = await _testContext.Client.DeleteAsync("/Client/" + client);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            jsonResponse = await response.Content.ReadAsStringAsync();
            ChargeSchema.IsValidSchemaObject("ClientSchema", jsonResponse).Should().BeTrue();
        }
    }
}


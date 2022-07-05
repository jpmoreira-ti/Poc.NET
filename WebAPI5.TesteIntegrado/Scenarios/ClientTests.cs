using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using WebAPI5.TesteIntegrado.Fixtures;
using WebAPI5.TesteIntegrado.Schemas;
using Xunit;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http.Json;
using WebAPI5.Models;

namespace WebAPI5.TesteIntegrado
{
    public class ClientTests
    {
        private readonly TestContext _testContext;
        private string jsonResponse;
        private string jsonFile;

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
            var data = response.Content.ReadAsStringAsync();
            data.Result.Should().Be("Cliente cadastrado com sucesso!");
        }

        [Fact]
        public async Task GetOneShouldReturnOk()
        {
            Client client = new()
            {
                Document = "17418609035"
            };

            var response = await _testContext.Client.GetAsync("/Client/" + client);
            var data = response.StatusCode.Should().Be(HttpStatusCode.OK);
            //data.Result.Should().Be("Cliente cadastrado com sucesso!");
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
            var data = response.Content.ReadAsStringAsync();
            data.Result.Should().Be("Cliente removido com sucesso!");
        }
    }
}


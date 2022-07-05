using Microsoft.AspNetCore.Mvc;
using WebAPI5.Models;

namespace WebAPI5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private ClientRepository _repository;

        public ClientController(ClientRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var clients = _repository.ReturnAll();
            return Ok(clients);
        }

        [HttpPost]
        public IActionResult Post(Client client)
        {
            var existsClient = _repository.ReturnOne(client.Document);
            if (existsClient != null) {
                return BadRequest(
                    "Cliente já existe!"
                );
            }
            _repository.Add(client);
            return Ok(
                "Cliente cadastrado com sucesso!"
            );
        }

        [HttpDelete ("{document}")]
        public IActionResult Delete(string document)
        {
            _repository.Remove(document);
            return Ok(
                "Cliente removido com sucesso!"
            );
        }

        [HttpGet ("{document}")]
        public IActionResult GetByDocument(string document)
        {
            var client = _repository.ReturnOne(document);
            if (client == null)
            {
                return Content(
                    "Cliente não encontrado!"
                );
            }
            return Ok(client);
        }
    }
}


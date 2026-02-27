using Microsoft.AspNetCore.Mvc;
using ClientesApi.Models;
using ClientesApi.Services;

namespace ClientesApi.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteService _service;

        public ClientesController(ClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Cliente>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Cliente> GetById(int id)
        {
            var cliente = _service.GetById(id);
            if (cliente == null) return NotFound();

            return Ok(cliente);
        }

        [HttpPost]
        public ActionResult<Cliente> Create(Cliente cliente)
        {
            var nuevo = _service.Add(cliente);
            return CreatedAtAction(nameof(GetById), new { id = nuevo.Id }, nuevo);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Cliente cliente)
        {
            if (!_service.Update(id, cliente))
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_service.Delete(id))
                return NotFound();

            return NoContent();
        }
    }
}
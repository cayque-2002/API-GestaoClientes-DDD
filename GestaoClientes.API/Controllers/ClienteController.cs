using GestaoClientes.Application.Clientes.CriarCliente;
using GestaoClientes.Application.Clientes.ObterClientePorId;
using GestaoClientes.Application.Clientes.ObterTodosClientes;
using GestaoClientes.Application.Excecoes;
using Microsoft.AspNetCore.Mvc;

namespace GestaoClientes.API.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly CriarClienteCommandHandler _criarHandler;
        private readonly ObterClientePorIdQueryHandler _obterHandler;
        private readonly ObterTodosClientesQueryHandler _obterTodosHandler;

        public ClientesController(
            CriarClienteCommandHandler criarHandler,
            ObterClientePorIdQueryHandler obterHandler,
            ObterTodosClientesQueryHandler obterTodosHandler)
        {
            _criarHandler = criarHandler;
            _obterHandler = obterHandler;
            _obterTodosHandler = obterTodosHandler!; 
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarClienteCommand command)
        {
            try
            {
                var id = await _criarHandler.HandleAsync(command);
                return CreatedAtAction(nameof(ObterPorId), new { id }, null);
            }
            catch (ExcecoesApplication ex)
            {
                return Conflict(new { erro = ex.Message });
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var cliente = await _obterHandler.HandleAsync(
                new ObterClientePorIdQuery(id));

            if (cliente is null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var clientes = await _obterTodosHandler.HandleAsync(new ObterTodosClientesQuery());
            return Ok(clientes);
        }
    }
}

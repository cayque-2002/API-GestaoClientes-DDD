using GestaoClientes.Application.Clientes.CriarCliente;
using GestaoClientes.Application.Clientes.ObterClientePorId;
using GestaoClientes.Infrastructure.Repositorios;
using Xunit;

namespace GestaoClientes.Tests.Clientes;

public class ObterClientePorIdQueryHandlerTests
{
    [Fact]
    public async Task Deve_retornar_cliente_quando_id_existir()
    {
        
        var repository = new ClienteRepository();

        var criarHandler = new CriarClienteCommandHandler(repository);
        var clienteId = await criarHandler.HandleAsync(
            new CriarClienteCommand("Academia Fighter", "12.345.678/0001-90", true));

        var queryHandler = new ObterClientePorIdQueryHandler(repository);

        var cliente = await queryHandler.HandleAsync(
            new ObterClientePorIdQuery(clienteId));


        Assert.NotNull(cliente);
        Assert.Equal(clienteId, cliente!.Id);
    }

    [Fact]
    public async Task Deve_retornar_nulo_quando_id_nao_existir()
    {
        
        var repository = new ClienteRepository();
        var handler = new ObterClientePorIdQueryHandler(repository);

        var cliente = await handler.HandleAsync(
            new ObterClientePorIdQuery(Guid.NewGuid()));

        
        Assert.Null(cliente);
    }
}

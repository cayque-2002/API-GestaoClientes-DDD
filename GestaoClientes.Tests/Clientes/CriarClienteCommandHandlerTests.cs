using GestaoClientes.Application.Clientes.CriarCliente;
using GestaoClientes.Application.Excecoes;
using GestaoClientes.Domain.Excecoes;
using GestaoClientes.Domain.ValueObjetcs;
using GestaoClientes.Infrastructure.Repositorios;
using Xunit;

namespace GestaoClientes.Tests.Clientes;

public class CriarClienteCommandHandlerTests
{
    [Fact]
    public async Task Deve_criar_cliente_com_sucesso_quando_dados_sao_validos()
    {

        var repository = new ClienteRepository();
        var handler = new CriarClienteCommandHandler(repository);

        var command = new CriarClienteCommand("Academia Fighter", "12.345.678/0001-90", true);

        var clienteId = await handler.HandleAsync(command);

        
        Assert.NotEqual(Guid.Empty, clienteId);
    }

    [Fact]
    public async Task Deve_retornar_erro_quando_cnpj_ja_existir()
    {
        
        var repository = new ClienteRepository();
        var handler = new CriarClienteCommandHandler(repository);

        var command = new CriarClienteCommand("Academia Fighter", "12.111.678/0001-90", true);
        await handler.HandleAsync(command);


        await Assert.ThrowsAsync<ExcecoesApplication>(() =>
            handler.HandleAsync(command));
    }

    [Fact]
    public async Task Deve_retornar_erro_quando_nome_for_invalido()
    {
        
        var repository = new ClienteRepository();
        var handler = new CriarClienteCommandHandler(repository);

        var command = new CriarClienteCommand("", "12.345.799/0001-90", true);

        
        await Assert.ThrowsAsync<ExcecaoDomain>(() =>
            handler.HandleAsync(command));
    }
}

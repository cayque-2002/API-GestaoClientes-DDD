using GestaoClientes.Application.DTOS;
using GestaoClientes.Application.Interfaces;
using GestaoClientes.Domain.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoClientes.Application.Clientes.ObterTodosClientes
{
    public class ObterTodosClientesQueryHandler
    {
        private readonly IClienteRepository _repository;

        public ObterTodosClientesQueryHandler(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ClienteDto>> HandleAsync(ObterTodosClientesQuery query)
        {
            var clientes = await _repository.ObterTodosAsync();

            return clientes.Select(c => new ClienteDto
            {
                Id = c.Id,
                NomeFantasia = c.NomeFantasia,
                Cnpj = c.Cnpj?.Valor ?? string.Empty,
                Ativo = c.Ativo
            }).ToList();
        }
    }
}

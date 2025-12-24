using GestaoClientes.Application.Interfaces;
using GestaoClientes.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoClientes.Application.Clientes.ObterClientePorId
{
    public class ObterClientePorIdQueryHandler
    {
        private readonly IClienteRepository _repository;

        public ObterClientePorIdQueryHandler(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Cliente?> HandleAsync(ObterClientePorIdQuery query)
        {
            return await _repository.ObterPorIdAsync(query.ClienteId);
        }
    }
}

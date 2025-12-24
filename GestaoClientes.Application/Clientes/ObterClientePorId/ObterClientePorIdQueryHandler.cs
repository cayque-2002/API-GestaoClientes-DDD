using GestaoClientes.Application.DTOS;
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

        public async Task<ClienteDto?> HandleAsync(ObterClientePorIdQuery query)
        {
            var cliente = await _repository.ObterPorIdAsync(query.ClienteId);

            if (cliente is null)
                return null;

            return new ClienteDto
            {
                Id = cliente.Id,
                NomeFantasia = cliente.NomeFantasia,
                Cnpj = cliente.Cnpj.Valor,
                Ativo = cliente.Ativo
            };
        }
    }
}

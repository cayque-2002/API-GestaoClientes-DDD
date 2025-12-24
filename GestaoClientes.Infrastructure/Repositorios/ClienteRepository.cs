using GestaoClientes.Application.Interfaces;
using GestaoClientes.Domain.Entidades;
using GestaoClientes.Domain.ValueObjetcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoClientes.Infrastructure.Repositorios
{
    public class ClienteRepository : IClienteRepository
    {
        private static readonly List<Cliente> _clientes = new();

        public Task AdicionarAsync(Cliente cliente)
        {
            _clientes.Add(cliente);
            return Task.CompletedTask;
        }

        public Task<Cliente?> ObterPorIdAsync(Guid id)
        {
            var cliente = _clientes.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(cliente);
        }

        public Task<IEnumerable<Cliente>> ObterTodosAsync()
        {
            return Task.FromResult<IEnumerable<Cliente>>(_clientes);
        }

        public Task<bool> ExisteCnpjAsync(Cnpj cnpj)
        {
            var existe = _clientes.Any(c => c.Cnpj.Equals(cnpj));
            return Task.FromResult(existe);
        }
    }
}

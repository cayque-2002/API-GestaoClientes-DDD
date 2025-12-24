using GestaoClientes.Domain.Entidades;
using GestaoClientes.Domain.ValueObjetcs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoClientes.Application.Interfaces
{
    public interface IClienteRepository
    {
        Task AdicionarAsync(Cliente cliente);
        Task<Cliente?> ObterPorIdAsync(Guid id);
        Task<bool> ExisteCnpjAsync(Cnpj cnpj);
    }
}

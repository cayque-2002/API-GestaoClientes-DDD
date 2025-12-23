using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestaoClientes.Domain.Entidades;

namespace GestaoClientes.Application.Interfaces
{
    public interface IClienteRepository
    {
        Task AddAsync(Cliente cliente);
        Task<Cliente?> GetByIdAsync(Guid id);
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task UpdateAsync(Cliente cliente);
        Task RemoveAsync(Guid id);
    }
}

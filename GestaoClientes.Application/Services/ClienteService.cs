using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestaoClientes.Application.Interfaces;
using GestaoClientes.Domain.Entidades;
using GestaoClientes.Application.Excecoes;

namespace GestaoClientes.Application.Services
{
    public class ClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Cliente> CriarAsync(string nome, Domain.ValueObjetcs.Cnpj cnpj, bool ativo)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new ExcecaoApplication("Nome inválido.");

            var cliente = Cliente.Criar(nome, cnpj, ativo);
            await _repository.AddAsync(cliente);
            return cliente;
        }

        public Task<Cliente?> ObterPorIdAsync(Guid id) => _repository.GetByIdAsync(id);

        public Task<IEnumerable<Cliente>> ObterTodosAsync() => _repository.GetAllAsync();

        public async Task AtualizarAsync(Cliente cliente)
        {
            if (cliente == null) throw new ExcecaoApplication("Cliente inválido.");
            await _repository.UpdateAsync(cliente);
        }

        public async Task RemoverAsync(Guid id)
        {
            var existente = await _repository.GetByIdAsync(id);
            if (existente == null) throw new ExcecaoApplication("Cliente não encontrado.");
            await _repository.RemoveAsync(id);
        }
    }
}

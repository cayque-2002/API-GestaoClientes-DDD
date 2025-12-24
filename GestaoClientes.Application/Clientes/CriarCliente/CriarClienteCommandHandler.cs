using GestaoClientes.Application.Interfaces;
using GestaoClientes.Domain.Entidades;
using GestaoClientes.Domain.ValueObjetcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoClientes.Application.Clientes.CriarCliente
{
    public class CriarClienteCommandHandler
    {
        private readonly IClienteRepository _repository;

        public CriarClienteCommandHandler(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> HandleAsync(CriarClienteCommand command)
        {
            var cnpj = new Cnpj(command.Cnpj);

            if (await _repository.ExisteCnpjAsync(cnpj))
                throw new Excecoes.ExcecoesApplication("Já existe um cliente cadastrado com este CNPJ.");

            var cliente = Cliente.Criar(command.NomeFantasia, cnpj, command.ativo);

            await _repository.AdicionarAsync(cliente);

            return cliente.Id;
        }
    }
}

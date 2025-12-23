using System;
using GestaoClientes.Domain.ValueObjetcs;
using GestaoClientes.Domain.Excecoes;

namespace GestaoClientes.Domain.Entidades
{
    public class Cliente
    {
        public Guid Id { get;  private set; }
        public string NomeFantasia { get; private set; }
        public Cnpj Cnpj { get; private set; }
        public bool Ativo { get; private set; }

        public Cliente(Guid id, string nome, Cnpj cnpj, bool ativo)
        {

            if (string.IsNullOrWhiteSpace(nome)) 
                    throw new ExcecaoDomain("Nome Fantasia inválido.");
            
            Id = id;
            NomeFantasia = nome;
            Cnpj = cnpj;
            Ativo = ativo;

        }

        public static Cliente Criar(string nome, Cnpj cnpj, bool ativo) => new Cliente(Guid.NewGuid(), nome, cnpj, ativo);

        public void Desativar()
        {
            Ativo = false;
        }

    }
}

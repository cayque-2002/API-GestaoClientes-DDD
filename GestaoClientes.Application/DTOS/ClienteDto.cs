using System;

namespace GestaoClientes.Application.DTOS
{
    public class ClienteDto
    {
        public Guid Id { get; set; }
        public string NomeFantasia { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public bool Ativo { get; set; }
    }
}

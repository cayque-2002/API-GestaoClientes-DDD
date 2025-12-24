using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoClientes.Application.Clientes.CriarCliente;

public record CriarClienteCommand(string NomeFantasia, string Cnpj, bool ativo);


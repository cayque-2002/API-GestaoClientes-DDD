using System;
using System.Text.RegularExpressions;
using GestaoClientes.Domain.Excecoes;

namespace GestaoClientes.Domain.ValueObjetcs
{
    public class Cnpj
    {
        public string Valor { get; private set; }

        public Cnpj(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor)) throw new ExcecaoDomain("CNPJ inválido.");

            var apenasDigitos = Regex.Replace(valor, @"\D", "");
            if (apenasDigitos.Length != 14) throw new ExcecaoDomain("CNPJ deve conter 14 dígitos.");

            Valor = apenasDigitos;
        }

        public override string ToString() => Valor;
    }
}

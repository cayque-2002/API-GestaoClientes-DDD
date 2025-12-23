using System;

namespace GestaoClientes.Domain.Excecoes
{
    public class ExcecaoDomain : Exception
    {
        public ExcecaoDomain(string message) : base(message) 
        { 
        }
       
    }
}

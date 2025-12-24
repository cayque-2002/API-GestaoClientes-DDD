using System;

namespace GestaoClientes.Application.Excecoes
{
    public class ExcecoesApplication : Exception
    {
        public ExcecoesApplication(string message) : base(message) 
        {
        }
        
    }
}

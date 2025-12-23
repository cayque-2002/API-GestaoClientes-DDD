using System;

namespace GestaoClientes.Application.Excecoes
{
    public class ExcecaoApplication : Exception
    {
        public ExcecaoApplication(string message) : base(message) 
        {
        }
        
    }
}

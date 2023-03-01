using System;

namespace ProjetoEcommerceAPI.Exceptions
{
    public class ObjetoExistenteException : Exception
    {
        private const string Message = "Objeto já existe";
        public ObjetoExistenteException() : base(Message)
        {

        }
        public ObjetoExistenteException(string message) : base(message)
        {

        }
        public ObjetoExistenteException(Exception innerexception) : base (Message, innerexception)
        {

        }
    }
    
}

using System;

namespace ProjetoEcommerceAPI.Exceptions
{
    public class MinimoCaracteresException : Exception
    {
        private const string Message = "O minimo de caracteres não foi atingido";

        public MinimoCaracteresException() : base(Message)
        {

        }

        public MinimoCaracteresException(string message) : base(message)
        {

        }

        public MinimoCaracteresException(Exception innerexception) : base (Message, innerexception)
        {

        }
    }
}

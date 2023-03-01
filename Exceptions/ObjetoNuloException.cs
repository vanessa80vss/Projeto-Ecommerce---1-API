using System;

namespace ProjetoEcommerceAPI.Exceptions
{
    public class ObjetoNuloException : Exception
    {
        private const string Message = "Objeto não encontrado";
        public ObjetoNuloException() : base( Message)
        {

        }
        public ObjetoNuloException(string message) : base( message )
        {

        }
        public ObjetoNuloException(Exception innerException) : base ( Message, innerException)
        {

        }
    }
}

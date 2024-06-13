using System;

namespace BankA_MVVM_Library.Exceptions
{
    public class EmptyNameException : Exception
    {
        public EmptyNameException()
        {
        }

        public EmptyNameException(string message)
            : base(message)
        {
        }

        public EmptyNameException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}

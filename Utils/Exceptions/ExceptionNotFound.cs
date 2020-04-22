using System;
using System.Collections.Generic;
using System.Text;

namespace Utils.Exceptions
{
    public class ExceptionNotFound : Exception
    {
        public ExceptionNotFound(string message) : base(message)
        {
        }
    }
}

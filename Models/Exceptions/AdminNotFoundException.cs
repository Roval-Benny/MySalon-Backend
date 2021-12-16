using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions
{
    public class AdminNotFoundException : ApplicationException
    {
        public AdminNotFoundException() { }
        public AdminNotFoundException(string message) : base(message) { }
    }
}

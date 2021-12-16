using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions
{
    public class JWTValidationException:ApplicationException
    {
        public JWTValidationException() { }
        public JWTValidationException(string message) : base(message) { }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions
{
    public class NullValueException:ApplicationException
    {
        public NullValueException() { }
        public NullValueException(string message) : base(message) { }
    }
}

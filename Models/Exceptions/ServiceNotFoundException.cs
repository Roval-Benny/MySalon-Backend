using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions
{
    public class ServiceNotFoundException:ApplicationException
    {
        public ServiceNotFoundException() { }
        public ServiceNotFoundException(string message) : base(message) { }
    }
}

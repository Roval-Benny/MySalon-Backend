using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions
{
    public class SalonNotFoundException:ApplicationException
    {
        public SalonNotFoundException() { }
        public SalonNotFoundException(string message) : base(message) { }
    }
}

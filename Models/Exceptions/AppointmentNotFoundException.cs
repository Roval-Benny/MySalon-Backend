using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions
{
    public class AppointmentNotFoundException:ApplicationException
    {
        public AppointmentNotFoundException() { }
        public AppointmentNotFoundException(string message) : base(message) { }
    }
}

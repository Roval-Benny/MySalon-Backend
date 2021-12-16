using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions
{
    public class TimeSlotNotFoundException:ApplicationException
    {
        public TimeSlotNotFoundException() { }
        public TimeSlotNotFoundException(string message) : base(message) { }
    }
}

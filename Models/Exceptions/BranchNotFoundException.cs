using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions
{
    public class BranchNotFoundException : ApplicationException
    {
        public BranchNotFoundException() { }
        public BranchNotFoundException(string message) : base(message) { }
    }
}

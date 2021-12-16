using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions
{
    public class CartItemNotFoundException:ApplicationException
    {
        public CartItemNotFoundException() { }
        public CartItemNotFoundException(string message) : base(message) { }
    }
}

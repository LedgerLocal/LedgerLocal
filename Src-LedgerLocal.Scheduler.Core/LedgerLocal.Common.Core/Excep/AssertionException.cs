using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LedgerLocal.Common.Core
{
    public class AssertionException : Exception
    {
        public AssertionException(string message) : base(message)
        {
        }

        public AssertionException(string message, Exception inner)
            : base(message, inner)
        {
        } 
    }
}

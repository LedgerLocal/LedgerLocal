using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LedgerLocal.Common.Core
{
    public class InvariantException : Exception
    {
        public InvariantException(string message) : base(message)
        {
        }

        public InvariantException(string message, Exception inner)
            : base(message, inner)
        {
        } 
    }
}

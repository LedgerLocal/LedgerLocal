using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LedgerLocal.Common.Core
{
    public class PostconditionException : Exception
    {
        public PostconditionException(string message) : base(message)
        {
        }

        public PostconditionException(string message, Exception inner)
            : base(message, inner)
        {
        } 
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClean.Application
{
    public class ApplicationException : Exception
    {
        internal ApplicationException(string businessMessage)
                : base(businessMessage)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZParsing.CSharp
{
    public class CSharpException : Exception
    {
        public CSharpException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

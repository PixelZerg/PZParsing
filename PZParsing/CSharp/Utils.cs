using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZParsing.CSharp
{
    public static class Utils
    {
        public static bool ContainsNonVarCharacters(string var)
        {
            if (var.Contains(' '))
            {
                return true;
            }
            if (char.IsNumber(var[0]))
            {
                return true;
            }
            return false;
        }

        //public static bool ParseVariableDefinition
    }
}

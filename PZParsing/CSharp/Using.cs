using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZParsing.CSharp
{
    public enum UsingType
    {
        Namespace,
        Alias,
    }

    public class Using : INode
    {
        public UsingType usingType = UsingType.Namespace;
        public string aliasName = "";
        public string namespaceName = "";

        public string GetName()
        {
            return "Using";
        }

        public Dictionary<string, string> GetAttributes()
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();
            ret.Add("usingType", usingType.ToString());
            if (usingType == UsingType.Alias)
            {
                ret.Add("aliasName", aliasName);
            }
            ret.Add("namespaceName", namespaceName);
            return ret;
        }

        public string GetValue()
        {
            return "";
        }

        public List<INode> GetChildren()
        {
            return new List<INode>();
        }
    }
}

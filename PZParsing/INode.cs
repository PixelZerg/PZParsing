using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZParsing
{
    public interface INode
    {
        string GetName();
        Dictionary<string, string> GetAttributes();
        string GetValue();
        List<INode> GetChildren();
    }
}

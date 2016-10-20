using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZParsing.CSharp
{
    public class File : INode
    {
        public List<Using> Usings = new List<Using>();
        public List<Namespace> Namespaces = new List<Namespace>();

        public List<string> Errors = new List<string>();
        public List<string> Warnings = new List<string>();
        public List<string> Messages = new List<string>();

        public string GetName()
        {
            return "";
        }

        public Dictionary<string,string> GetAttributes()
        {
            return new Dictionary<string, string>();
        }

        public string GetValue()
        {
            return "";
        }

        public List<INode> GetChildren()
        {
            List<INode> ret = new List<INode>();
            if (Errors.Count > 0)
            {
                foreach (string error in Errors)
                {
                    GenericNode node = new GenericNode();
                    node.Value = error;
                    ret.Add(node);
                }
            }
            else
            {
                GenericNode WarningNode = new GenericNode("ParsingWarnings");
                foreach (string warning in Warnings)
                {
                    GenericNode node = new GenericNode();
                    node.Value = warning;
                    WarningNode.AddChild(node);
                }
                WarningNode.Attributes.Add("Count", Warnings.Count.ToString());
                ret.Add(WarningNode);

                GenericNode MessagesNode = new GenericNode("ParsingMessages");
                foreach (string message in Messages)
                {
                    GenericNode node = new GenericNode();
                    node.Value = message;
                    MessagesNode.AddChild(node);
                }
                MessagesNode.Attributes.Add("Count", Messages.Count.ToString());
                ret.Add(MessagesNode);

                GenericNode usingsNode = new GenericNode("Usings");
                usingsNode.Children.AddRange(Usings);
                ret.Add(usingsNode);
                //TODO
            }
            return ret;
        }
    }
}

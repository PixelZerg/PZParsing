using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZParsing
{
    public class GenericNode : INode
    {
        public string Name = "";
        public Dictionary<string, string> Attributes = new Dictionary<string, string>();
        public string Value = "";
        public List<INode> Children = new List<INode>();

        public GenericNode() { }

        public GenericNode(string Name)
        {
            this.Name = Name;
        }

        public GenericNode(string Name, string Value/*, params string[] Attributes*/)
        {
            this.Name = Name;
            this.Value = Value;
            //this.Attributes = Attributes.ToList();
        }

        //public GenericNode(string Name, params string[] Attributes)
        //{
        //    this.Name = Name;
        //    this.Attributes = Attributes.ToList();
        //}

        public string GetName()
        {
            return this.Name;
        }

        public Dictionary<string,string> GetAttributes()
        {
            return this.Attributes;
        }

        public string GetValue()
        {
            return this.Value;
        }

        public List<INode> GetChildren()
        {
            return this.Children;
        }

        public void AddChild(INode child)
        {
            this.Children.Add(child);
        }
    }
}

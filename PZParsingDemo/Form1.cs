using PZParsing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PZParsingDemo
{
    public partial class Form1 : Form
    {
        public enum Demo
        {
            CSharp    
        }

        public Form1()
        {
            InitializeComponent();
            foreach (Demo demo in Enum.GetValues(typeof(Demo)))
            {
                this.toolStripComboBox1.Items.Add(demo);
            }
            try
            {
                this.toolStripComboBox1.SelectedIndex = 0;
            }
            catch { }
        }

        private void inputBox_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.WriteLine();
            }

            this.treeView1.Nodes.Clear();
            switch ((Demo)this.toolStripComboBox1.SelectedItem)
            {
                case Demo.CSharp:
                    DoCSharp();
                    break;
            }
            treeView1.ExpandAll();
        }

        private void DoCSharp()
        {
            //GenericNode node = new GenericNode("moo");
            //node.AddChild(new GenericNode("mooo"));
            //node.AddChild(new GenericNode("bob")
            //{
            //    Children = new INode[] { new GenericNode("", "val"), }.ToList(),
            //    Attributes = new Dictionary<string, string>(),
            //});
            //this.treeView1.Nodes.Add(NodeToTreeNode(node));
            INode node = new PZParsing.CSharp.CSharpParser().ParseFile(this.inputBox.Text);
            this.treeView1.Nodes.Add(NodeToTreeNode(node));
        }

        private TreeNode NodeToTreeNode(PZParsing.INode node)
        {
            TreeNode newNode = new TreeNode();
            newNode.Text = node.GetName();
            foreach (var attr in node.GetAttributes())
            {
                newNode.Nodes.Add(new TreeNode("@"+attr.Key.ToString()+": "+attr.Value.ToString()) { ForeColor = Color.Green });
            }
            string val = node.GetValue();
            if (!string.IsNullOrEmpty(val))
            {
                newNode.Nodes.Add(new TreeNode(val) { ForeColor = Color.Blue });
            }
            foreach (PZParsing.INode child in node.GetChildren())
            {
                if (string.IsNullOrEmpty(child.GetName()))
                {
                    newNode.Nodes.Add(new TreeNode(child.GetValue()) { ForeColor = Color.Blue });
                }
                else {
                    newNode = (NodeToTreeNode(newNode, child));
                }
            }
            newNode.ToolTipText = newNode.Text;
            return newNode;
        }

        private TreeNode NodeToTreeNode(TreeNode root, PZParsing.INode node)
        {
            TreeNode newNode = new TreeNode();
            newNode.Text = node.GetName();
            foreach(var attr in node.GetAttributes())
            {
                newNode.Nodes.Add(new TreeNode("@" + attr.Key.ToString() + ": " + attr.Value.ToString()) { ForeColor = Color.Green });
            }
            string val = node.GetValue();
            if (!string.IsNullOrEmpty(val))
            { 
                newNode.Nodes.Add(new TreeNode(val) { ForeColor = Color.Blue });
            }
            foreach (PZParsing.INode child in node.GetChildren())
            {
                if (string.IsNullOrEmpty(child.GetName()) && child.GetChildren().Count == 0 && child.GetAttributes().Count == 0)
                {
                    newNode.Nodes.Add(new TreeNode(child.GetValue()) { ForeColor = Color.Blue });
                }
                else {
                    newNode = (NodeToTreeNode(newNode, child));
                }
            }
            TreeNode ret = (TreeNode)root.Clone();
            newNode.ToolTipText = newNode.Text;
            ret.Nodes.Add(newNode);
            return ret;
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            MessageBox.Show(treeView1.SelectedNode.Text);
        }
    }
}

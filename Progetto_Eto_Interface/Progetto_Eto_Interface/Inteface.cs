using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Progetto_Eto_Interface
{

    public partial class Inteface : Form
    {
        ReaderFile thisReader;
        
        public Inteface(ReaderFile reader)
        {
            InitializeComponent();

            thisReader = reader;

            // Selezione TreeView
            treeView1.AfterSelect += TreeViewAfterSelect;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Caricamento JSON e visualizzazione TreeView
            JsonTreeView.JsonTreeViewLoader.LoadJsonToTreeView(treeView1, thisReader.Value);
        }

        private void TreeViewAfterSelect(object sender, TreeViewEventArgs e)
        {
            string nodeText = treeView1.SelectedNode.Text;

            textBox1.Clear();

            // Show entire subtree
            foreach (TreeNode thisNode in treeView1.SelectedNode.Nodes)
            {
                // Recursion from selected node to children
                ExploreAndPrintSubTree(thisNode, "");
            }
            
        }

        private void ExploreAndPrintSubTree(TreeNode nodeToExplore, string level)
        {
            if(nodeToExplore.GetNodeCount(true) == 0)
            {
                textBox1.AppendText(level + nodeToExplore.Text + Environment.NewLine);
            }
            else
            {
                textBox1.AppendText(level + nodeToExplore.Text + Environment.NewLine);

                foreach (TreeNode thisThisNode in nodeToExplore.Nodes)
                {
                    ExploreAndPrintSubTree(thisThisNode, level+"-");
                }

            }
            
        }
    }

    public class ReaderFile
    {
        string Path;
        public string Value;
        public ReaderFile(string Path) 
        {
            this.Path = "";
            this.Value = LoadFile(Path);
        }
        private string LoadFile(string Path)
        {
            if (System.IO.File.Exists(Path))
            {
                return System.IO.File.ReadAllText(Path);
            }
            return "";
        }
    }
}

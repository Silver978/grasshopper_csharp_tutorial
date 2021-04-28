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

        private void txt_file_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            // Normal text
            string textToShow = thisReader.Value;
            txt_file.Text = textToShow;

            // JSON to treeview
            /*Type type = rot.GetType();
            foreach (PropertyInfo pi in type.GetProperties())
            {
                string a = pi.ToString();
            }*/
            JsonTreeView.JsonTreeViewLoader.LoadJsonToTreeView(treeView1, thisReader.Value);

            /*
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\darkg\Desktop\testJson.json");

            // Display the file contents by using a foreach loop.
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + line);
            }*/
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TreeViewAfterSelect(object sender, TreeViewEventArgs e)
        {
            string nodeText = treeView1.SelectedNode.Text;

            // Update the panel here accordingly
            textBox1.Text = nodeText;
        }

        private void label3_Click(object sender, EventArgs e)
        {

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

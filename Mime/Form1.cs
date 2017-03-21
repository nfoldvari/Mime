using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using akiss.GitHub.YetAnotherMimeMagic;

namespace Mime
{
    public partial class Form1 : Form
    {
        public Stream myStream = null;
        public string fileName;
        public string path;
        public FileInfo fileInfo;

        public Form1()
        {
            InitializeComponent();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            // Insert code to read the stream here.
                            fileInfo = new FileInfo (openFileDialog1.FileName);
                            fileName = Path.GetFileName(openFileDialog1.FileName);
                            path = Path.GetDirectoryName(openFileDialog1.FileName);
                            StreamReader reader = new StreamReader(myStream);
                            textBox1.Text = path + fileName + " is loaded";
                            reader.Close(); 
                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            richTextBox1.Text = MimeMagic.FindMimeType(fileInfo).ToString();
        }
    }
}

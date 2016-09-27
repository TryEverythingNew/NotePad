// Name: xueliang sun ID: 11387859
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void loadFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rs = openFileDialog1.ShowDialog(); // show the dialog to user

            // Open a file
            if (rs.ToString() == "OK")  // if result is ok, then we continue to open the file
            {
                string path = saveFileDialog1.FileName;
                if (File.Exists(path))
                {
                    using (StreamReader sr = new StreamReader(path))    // use streamreader to read from file
                    {
                        LoadText( sr);
                    }
                }
            }

        }

        private void loadFibonacciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FibonacciTextReader ftr = new FibonacciTextReader(50);  // set FibonacciTextReader with 50 lines
            LoadText(ftr);
        }

        private void loadFibonaccifirst100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FibonacciTextReader ftr = new FibonacciTextReader(100); // set FibonacciTextReader with 100 lines
            LoadText(ftr);
        }

        private void saveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rs = saveFileDialog1.ShowDialog(); // show the dialog for saving file
            if(rs.ToString() == "OK" )  // if OK, we continue to save to file
            {
                string path = saveFileDialog1.FileName; // we need to check whether file exists or not
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                using (FileStream fs = File.Create(path))   // use file stream to write data to file
                {
                    byte[] data = Encoding.ASCII.GetBytes(textBox1.Text);
                    fs.Write( data, 0, data.Length);
                }

                
            }
        }

        private void LoadText(TextReader sr)    // to set the text to our textbox
        {
            textBox1.Text = sr.ReadToEnd();
        }


    }
}

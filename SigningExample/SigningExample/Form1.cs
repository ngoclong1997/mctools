using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SigningExample
{
    public partial class Form1 : Form
    {
        byte[] fileBytes;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName;
                fileName = openFileDialog1.FileName;
                tbPath.Text = fileName;
            }
        }

        private void sign_Click(object sender, EventArgs e)
        {

        }

        private void verify_Click(object sender, EventArgs e)
        {
            
        }

        private void browse1_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                string fileName;
                fileName = openFileDialog1.FileName;
                tbPath2.Text = fileName;
            }
        }

        private void tbPath2_TextChanged(object sender, EventArgs e)
        {

        }

        private void outputSign_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                string fileName;
                fileName = openFileDialog1.FileName;
                tbPath2.Text = fileName;
            }
        }
    }
}

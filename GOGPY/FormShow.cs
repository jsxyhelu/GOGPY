using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOGPY
{
    public partial class FormShow : Form
    {
        public FormShow()
        {
            InitializeComponent();
        }

        public void showImage(string strPath)
        {
            if (strPath != null)
            {
                try
                {
                    this.pictureBox1.Image = Image.FromFile(strPath);
                }
                catch
                {

                }
            }
          
        }

        public void showImage(Image aimage)
        {
            if (aimage != null)
            {
                try
                {
                    this.pictureBox1.Image = aimage;
                }
                catch
                {

                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void FormShow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            return;
        }
    }
}

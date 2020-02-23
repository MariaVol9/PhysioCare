using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diploma_Final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show(this);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show(this);
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show(this);
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.Show(this);
        }

        private void Button5_Click(object sender, EventArgs e)
        {

            Form6 frm = new Form6();
            frm.Show(this);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Form7 frm = new Form7();
            frm.Show(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

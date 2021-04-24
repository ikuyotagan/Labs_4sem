using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pract_1
{
    public partial class Form1 : Form
    {
        Form2 dlg1 = new Form2();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dlg1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double Per = dlg1.a + (dlg1.b) + (dlg1.c);
            double Plocsh = Math.Sqrt(Per/2 * (Per/2 - dlg1.a) * (Per/2 - dlg1.b) * (Per/2 - dlg1.c));

            if (dlg1.checkBox1.Checked == dlg1.checkBox2.Checked == true)
            {
                MessageBox.Show("Площадь: " + Math.Round(Plocsh,4) +"\nПериметр: "+ Per, "Результат");
            } else if (dlg1.checkBox1.Checked ==  true)
            {
                MessageBox.Show("Периметр: " + Per, "Результат");
            } else if (dlg1.checkBox2.Checked == true)
            {
                MessageBox.Show("Площадь: " + Math.Round(Plocsh, 4), "Результат");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

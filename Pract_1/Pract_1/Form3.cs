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
    public partial class Form3 : Form
    {
        int a = -1;
        
        public Form3()
        {
            InitializeComponent();
            button1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                label1.Text = Convert.ToString(a, 2);
            }
            else if (radioButton2.Checked)
            {
                label1.Text = Convert.ToString(a, 8);
            }
            else if (radioButton3.Checked)
            {
                label1.Text = Convert.ToString(a, 16);
            }
            else
            {
                MessageBox.Show("Введите число!", "Косяк");
                textBox1.Enter += textBox1_Enter;
            }
        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
            textBox1.Text = "";
            textBox1.Enter -= textBox1_Enter;
        }

        public void textBox1_Leave(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out a))
            {
                textBox1.ForeColor = Color.Silver;//Серый
                textBox1.Enter += textBox1_Enter;
                textBox1.Text = "Введите число:";
                MessageBox.Show("Введите число!", "Косяк");
                textBox1.Focus();
            }
            else
            {
                a = int.Parse(textBox1.Text);
                textBox1.Enter -= textBox1_Enter;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

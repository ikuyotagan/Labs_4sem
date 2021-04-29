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
    public partial class Form2 : Form
    {
        public double a = -1;
        public double b = -1;
        public double c = -1;
        public bool filled = false;
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
            textBox1.Text = "";
            textBox1.Enter -= textBox1_Enter;
        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.ForeColor = Color.Black;
            textBox2.Text = "";
            textBox2.Enter -= textBox2_Enter;
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.ForeColor = Color.Black;
            textBox3.Text = "";
            textBox3.Enter -= textBox3_Enter;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox1.Text, out a))
            {
                textBox1.ForeColor = Color.Silver;//Серый
                textBox1.Enter += textBox1_Enter;
                textBox1.Text = "Сторона А";
                MessageBox.Show("Введите число!", "Косяк");
                textBox1.Focus();
            }
            else
            {
                a = double.Parse(textBox1.Text);
                textBox1.Enter -= textBox1_Enter;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox2.Text, out b))
            {
                textBox2.ForeColor = Color.Silver;//Серый
                textBox2.Enter += textBox2_Enter;
                textBox2.Text = "Сторона B";
                MessageBox.Show("Введите число!", "Косяк");
                textBox2.Focus();
            }
            else
            {
                b = double.Parse(textBox2.Text);
                textBox2.Enter -= textBox2_Enter;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox3.Text, out c))
            {
                textBox3.ForeColor = Color.Silver;//Серый
                textBox3.Enter += textBox3_Enter;
                textBox3.Text = "Сторона C";
                MessageBox.Show("Введите число!", "Косяк");
                textBox3.Focus();
            }
            else
            {
                c = double.Parse(textBox3.Text);
                textBox3.Enter -= textBox3_Enter;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((a+b<=c)||(a+c<=b)||(b+c<=a))
            {
                filled = false;
                MessageBox.Show("Такого треугольника не бывает!", "Косяк");
            }
            else {
                filled = true;
                Close();
            }
        }
    }
}

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
        Form2 Input = new Form2();
        Form3 Conver = new Form3();
        Form4 Analysis = new Form4();
        public Form1()
        {
            InitializeComponent(); 
            Input.textBox1.ForeColor = Color.Silver;
            Conver.textBox1.ForeColor = Color.Silver;
            Input.textBox2.ForeColor = Color.Silver;
            Input.textBox3.ForeColor = Color.Silver;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Input.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double Per = Input.a + (Input.b) + (Input.c);
            double Plocsh = Math.Sqrt(Per/2 * (Per/2 - Input.a) * (Per/2 - Input.b) * (Per/2 - Input.c));
            if (Input.filled) {
                if (Input.checkBox1.Checked == Input.checkBox2.Checked == true)
                {
                    MessageBox.Show("Площадь: " + Math.Round(Plocsh, 4) + "\nПериметр: " + Per, "Результат");
                } else if (Input.checkBox1.Checked == true)
                {
                    MessageBox.Show("Периметр: " + Per, "Результат");
                } else if (Input.checkBox2.Checked == true)
                {
                    MessageBox.Show("Площадь: " + Math.Round(Plocsh, 4), "Результат");
                }
            }
            else
            {
                MessageBox.Show("Заполните форму!", "Косяк");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Conver.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Игорь\n\nСтудент Итмо", "About");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Analysis.ShowDialog();
        }
    }
}

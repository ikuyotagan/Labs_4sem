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
    public partial class Form4 : Form
    {
        char a;
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        string fileText;

        public Form4()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            fileText = System.IO.File.ReadAllText(filename);
            fileText = fileText.ToLower();
            MessageBox.Show("Файл открыт");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
            textBox1.Text = "";
            textBox1.Enter -= textBox1_Enter;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (!char.TryParse(textBox1.Text, out a))
            {
                textBox1.ForeColor = Color.Silver;//Серый
                textBox1.Enter += textBox1_Enter;
                textBox1.Text = "Буква";
                MessageBox.Show("Введите букву!", "Косяк");
                textBox1.Focus();
            }
            else
            {
                a = char.Parse(textBox1.Text.ToLower());
                textBox1.Enter -= textBox1_Enter;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int count = fileText.Split(new string[] { " ","\n" }, StringSplitOptions.RemoveEmptyEntries).Length;
            label1.Text = Convert.ToString(count);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int calc = 0;
            foreach (char b in fileText)
                if (b == a) calc++;
            label2.Text = Convert.ToString(calc);
        }
    }
}

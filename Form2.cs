using System;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form2 : Form
    {
        public float xF2 = 0;
        public float yF2 = 0;
        public float angleF2 = 0;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (float.TryParse(textBox1.Text, out float xResult))
            {
                xF2 = xResult; // Сохраняем значение в статическую переменную
            }

            if (float.TryParse(textBox2.Text, out float yResult))
            {
                yF2 = yResult; // Сохраняем значение в статическую переменную
            }

            if (float.TryParse(textBox3.Text, out float angleResult))
            {
                angleF2 = angleResult; // Сохраняем значение в статическую переменную
            }

            this.Close();
        }
    }
}

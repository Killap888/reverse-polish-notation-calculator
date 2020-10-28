using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc_Polc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button_1_num_Click(object sender, EventArgs e)
        {
            textBox_stroka.Text = textBox_stroka.Text + "1";
        }

        private void button_2_num_Click(object sender, EventArgs e)
        {
            textBox_stroka.Text = textBox_stroka.Text + "2";
        }

        private void button_3_num_Click(object sender, EventArgs e)
        {
            textBox_stroka.Text = textBox_stroka.Text + "3";
        }

        private void button_4_num_Click(object sender, EventArgs e)
        {
            textBox_stroka.Text = textBox_stroka.Text + "4";
        }

        private void button_5_num_Click(object sender, EventArgs e)
        {
            textBox_stroka.Text = textBox_stroka.Text + "5";
        }

        private void button_6_num_Click(object sender, EventArgs e)
        {
            textBox_stroka.Text = textBox_stroka.Text + "6";
        }

        private void button_7_num_Click(object sender, EventArgs e)
        {
            textBox_stroka.Text = textBox_stroka.Text + "7";
        }

        private void button_8_num_Click(object sender, EventArgs e)
        {
            textBox_stroka.Text = textBox_stroka.Text + "8";
        }

        private void button_9_num_Click(object sender, EventArgs e)
        {
            textBox_stroka.Text = textBox_stroka.Text + "9";
        }

        private void button_0_num_Click(object sender, EventArgs e)
        {
            textBox_stroka.Text = textBox_stroka.Text + "0";
        }

        private void button_dot_Click(object sender, EventArgs e)
        {
            textBox_stroka.Text = textBox_stroka.Text + ",";
        }

        private void button_plus_Click(object sender, EventArgs e)
        {
            textBox_stroka.Text = textBox_stroka.Text + "+";
        }

        private void button_minus_Click(object sender, EventArgs e)
        {
            textBox_stroka.Text = textBox_stroka.Text + "-";
        }

        private void button_multiply_Click(object sender, EventArgs e)
        {
            textBox_stroka.Text = textBox_stroka.Text + "*";
        }

        private void button_split_Click(object sender, EventArgs e)
        {
            textBox_stroka.Text = textBox_stroka.Text + "/";
        }

        private void button_percent_Click(object sender, EventArgs e)
        {
            textBox_stroka.Text = textBox_stroka.Text + "%";
        }

        private void button_extent_Click(object sender, EventArgs e)
        {
            textBox_stroka.Text = textBox_stroka.Text + "^";
        }

        private void button_square_Click(object sender, EventArgs e)
        {
            textBox_stroka.Text = textBox_stroka.Text + "\u221a";
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            int i = textBox_stroka.Text.Length;

            if (i > 0)
            {
                textBox_stroka.Text = textBox_stroka.Text.Remove(i - 1);
            }
        }

       

        private void button_equal_Click(object sender, EventArgs e)////////////////////////////////////////
        {
            string virashenie = textBox_stroka.Text.ToString();

            try
            {
                textBox_stroka.Text = Reverse_Notation.Calculate(virashenie).ToString();
            }
            catch
            {
                DialogResult rezult = MessageBox.Show("Произошла ошибка! Проверьте правильность ввода уравнения!",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            


            //MessageBox.Show(Reverse_Notation.Calculate(virashenie).ToString());

            

            
        }


    }
}

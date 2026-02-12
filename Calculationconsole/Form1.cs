using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculationconsole
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void result_TextChanged(object sender, EventArgs e)
        {

        }

        private void addition_Click(object sender, EventArgs e)
        {
            int res = Convert.ToInt32(firstnumber.Text) + Convert.ToInt32(secondnumber.Text);
            resulttext.Text = Convert.ToString(res);
            MessageBox.Show("Addition is successful");
            DialogResult result = MessageBox.Show("Addition is done.Do you want to add more numbers", "Confirm", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                firstnumber.Text = "";
                secondnumber.Text = "";
                resulttext.Text = "";
            }
            else
            {

            }
        }

        private void Subtraction_Click(object sender, EventArgs e)
        {
            int res = Convert.ToInt32(firstnumber.Text) - Convert.ToInt32(secondnumber.Text);
            resulttext.Text = Convert.ToString(res);
            MessageBox.Show("subtraction is successful");
            DialogResult result = MessageBox.Show("Subtraction is done.Do you want to add more numbers", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                firstnumber.Text = "";
                secondnumber.Text = "";
                resulttext.Text = "";
            }
            else
            {

            }
        }

        private void Multiplication_Click(object sender, EventArgs e)
        {
            int res = Convert.ToInt32(firstnumber.Text) * Convert.ToInt32(secondnumber.Text);
            resulttext.Text = Convert.ToString(res);
            MessageBox.Show("Multiplication is successful");
            DialogResult result = MessageBox.Show("Multiplication is done.Do you want to add more numbers", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                firstnumber.Text = "";
                secondnumber.Text = "";
                resulttext.Text = "";
            }
            else
            {

            }
        }

        private void Division_Click(object sender, EventArgs e)
        {
            int res = Convert.ToInt32(firstnumber.Text) / Convert.ToInt32(secondnumber.Text);
            resulttext.Text = Convert.ToString(res);
            MessageBox.Show("Division is successful");
            DialogResult result = MessageBox.Show("Division is done.Do you want to add more numbers", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                firstnumber.Text = "";
                secondnumber.Text = "";
                resulttext.Text = "";
            }
            else
            {

            }
        }
    }
}

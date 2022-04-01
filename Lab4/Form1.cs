using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.Text = "EC447 Lab 4";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        
        private static string ReverseStr(string str)
        {
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
        private static string OneDigit(int num)
        {
            int max = 11;
            if(num < 10)
            {
                return num.ToString();
            }
            else
            {
                return max.ToString();
            }
        }
        
        private static Boolean TwoPlusDigits(int num)
        {
            string number = num.ToString();
            string reverse = String.Empty;
            reverse = ReverseStr(number);
            if (reverse == number)
                return true;
            else
            {
                return false;
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            label5.Hide();
            string num = textBox1.Text; // starting num, is string
            string countstr = textBox2.Text; // count of palindromes, is string

            int number = Int32.Parse(num); // convert starting number to integer, check range
            int count = Int32.Parse(countstr); // convert palindromes count to integer, check range

            int n = 0; // check closeness to max palindrome count
            Boolean twoplus = false; // check if 2+ digit number is valid

            if (count > 100 || count < 0) // if count out of bounds
            {
                textBox3.Text = String.Empty;
                label5.Show();  
            }
            if (number > 1000000000 || number < 0) // if number is out of bounds
            {
                textBox3.Text = String.Empty;
                label5.Show();
            }
            else if (count >= 0 && count <= 100 && number >= 0 && number <= 1000000000) // if all valid
            {
                textBox3.Text = String.Empty;

                while (n < count)
                {
                    string update = String.Empty;
                    if(number <= 10)
                    {
                        update = OneDigit(number);
                        textBox3.AppendText(update);
                        textBox3.AppendText(Environment.NewLine);
                        if(Int32.Parse(update) == 11)
                        {
                            number = 11;
                        }
                        number += 1;
                        n += 1;
                    }
                    else
                    {
                        twoplus = TwoPlusDigits(number);
                        if(twoplus == true)
                        {
                            textBox3.AppendText(number.ToString());
                            textBox3.AppendText(Environment.NewLine);
                            number += 1;
                            n += 1;
                        }
                        else if(twoplus == false)
                        {
                            number += 1;
                        }
                    }

                }
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.Handled=!char.IsDigit(e.KeyChar))
            {
                textBox3.Text = String.Empty;
                label5.Show();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar))
            {
                textBox3.Text = String.Empty;
                label5.Show();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crypto_lab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputString1 = box1.Text;
            int tryParseRes = 0;

            if (!Int32.TryParse(inputString1, out tryParseRes)) //проверка второй строки на символы
            {
                result.Visible = true;
                result.Text = "ERROR! Wrong symbols in number";
            }
            else
            {
                int num = Convert.ToInt32(inputString1);
                if (num <= 0)
                {
                    result.Visible = true;
                    result.Text = "ERROR! Uncorrect number";
                }
                else
                {
                    int maxPower = (int)Math.Log(num, 2);
                    string res = Convert.ToString(maxPower);
                    result.Visible = true;
                    result.Text = res;
                }
            }
        }
    }
    }


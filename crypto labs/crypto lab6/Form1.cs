using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crypto_lab7
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
            int ErrCode = 0;

            char[] inputString1ArrOfChar = inputString1.ToCharArray();

            for (int i = 0; i < inputString1.Length; i++)
            {
                if ((inputString1ArrOfChar[i] != '0') && (inputString1ArrOfChar[i] != '1'))
                {
                    ErrCode = 1;
                    break;
                }
            }

            if (inputString1 == "") //проверка строк на пустоту  
            {
                result.Visible = true;
                result.Text = "ERROR! Empty number";
            }

            else if (ErrCode == 1)   //проверка первой строки на символы
            {
                result.Visible = true;
                result.Text = "ERROR! Wrong symbols in number";
            }

            else if (inputString1.Length > 32) //проверка строк на размер
            {
                result.Visible = true;
                result.Text = "ERROR! Wrong number of symbols";
            }
            else
            {
                uint num = Convert.ToUInt32(inputString1, 2);
               // if (num % 2 != 0)
                //{
                  //  result.Visible = true;
                 //   result.Text = "ERROR! Wrong number (num%2 !=0)";
               // }
               // else
               // {
                    uint res = num & 1;

                    for (int i = 1; i < inputString1.Length; i++)
                    {
                        res ^= ((num >> i) & 1u);
                    }

                    string resString = Convert.ToString(res);
                    result.Visible = true;
                    result.Text = resString;
               // }
            }
        }
    }
}

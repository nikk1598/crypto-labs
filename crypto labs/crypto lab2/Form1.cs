using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crypto_lab_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputString1 = box1.Text, inputString2 = box2.Text;
            int ErrCode = 0, tryParseRes = 0;

            char[] inputString1ArrOfChar = inputString1.ToCharArray();

            for (int i = 0; i < inputString1.Length; i++)
            {
                if ((inputString1ArrOfChar[i] != '0') && (inputString1ArrOfChar[i] != '1'))
                {
                    ErrCode = 1;
                    break;
                }
            }

            if ((inputString1 == "") || (inputString2 == "")) //проверка строк на пустоту  
            {
                result.Visible = true;
                result.Text = "ERROR! Empty number";
            }

            else if (!Int32.TryParse(inputString2, out tryParseRes)) //проверка второй строки на символы
            {
                result.Visible = true;
                result.Text = "ERROR! Wrong symbols in number 2";
            }

            else if (ErrCode == 1)
            {
                result.Visible = true;
                result.Text = "ERROR! Wrong symbols in number 1"; //проверка первой строки на символы
            }

            else if ((inputString1.Length > 32) || (inputString2.Length > 2)) //проверка строк на размер
            {
                result.Visible = true;
                result.Text = "ERROR! Wrong number of symbols";
            }
            else
            {
                int numInt = Convert.ToInt32(inputString1, 2);
                int i = Convert.ToInt32(inputString2);
                if (i > inputString1.Length / 2)
                {
                    result.Visible = true;
                    result.Text = "ERROR! Wrong number 2";

                }
                else if (i == 0)
                {
                    result.Visible = true;
                    result.Text = "Number 2 is 0, so result is empty string";
                }
                else
                {
                    int resRightInt = ~((~0) << i) & numInt;
                    int resLeftInt = (numInt >> (inputString1.Length - i) << i);

                    int resInt = resLeftInt | resRightInt;
                    string resString = Convert.ToString(resInt, 2).PadLeft(i * 2, '0');
                    result.Visible = true;
                    result.Text = resString;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string inputString1 = box1.Text, inputString2 = box3.Text;
            int ErrCode = 0, tryParseRes = 0;

            char[] inputString1ArrOfChar = inputString1.ToCharArray();

            for (int i = 0; i < inputString1.Length; i++)
            {
                if ((inputString1ArrOfChar[i] != '0') && (inputString1ArrOfChar[i] != '1'))
                {
                    ErrCode = 1;
                    break;
                }
            }

            if ((inputString1 == "") || (inputString2 == "")) //проверка строк на пустоту  
            {
                result2.Visible = true;
                result2.Text = "ERROR! Empty number";
            }

            else if (!Int32.TryParse(inputString2, out tryParseRes)) //проверка второй строки на символы
            {
                result2.Visible = true;
                result2.Text = "ERROR! Wrong symbols in number 2";
            }

            else if (ErrCode == 1)
            {
                result2.Visible = true;
                result2.Text = "ERROR! Wrong symbols in number 1"; //проверка первой строки на символы
            }

            else if ((inputString1.Length > 32) || (inputString2.Length > 2)) //проверка строк на размер
            {
                result2.Visible = true;
                result2.Text = "ERROR! Wrong number of symbols";
            }
            else
            {
                int numInt = Convert.ToInt32(inputString1, 2);
                int i = Convert.ToInt32(inputString2);
                if (i > inputString1.Length / 2)
                {
                    result2.Visible = true;
                    result2.Text = "ERROR! Wrong number 2";

                }
                else if (i == (double)inputString1.Length / 2)
                {
                    result2.Visible = true;
                    result2.Text = "Result is empty string";
                }
                else
                {
                    int resInt = (~((~0) << (inputString1.Length - i)) & numInt) >> i;

                    string resString = Convert.ToString(resInt, 2).PadLeft(inputString1.Length - (i * 2), '0');

                    Console.WriteLine(resString);
                    result2.Visible = true;
                    result2.Text = resString;
                }
            }
        }
    }
}

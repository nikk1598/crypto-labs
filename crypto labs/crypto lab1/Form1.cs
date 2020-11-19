using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crypto_lab_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string Transform(uint num) //перевод в двоичную систему счисления
        {
            string preResult = "";
            while (num > 0)
            {
                preResult += num % 2;
                num /= 2;
            }
            char[] preResReverse = preResult.ToCharArray();
            Array.Reverse(preResReverse);
            string result = new string(preResReverse).PadLeft(32, '0');
            return result;
        }

        private void button1_Click(object sender, EventArgs e) //получение бита
        {
            string inputString1 = box1.Text;
            string inputString2 = box2.Text;
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
                result1.Visible = true;
                result1.Text = "ERROR! Empty number";
            }

            else if (!Int32.TryParse(inputString2, out tryParseRes)) //проверка второй строки на символы
            {
                result1.Visible = true;
                result1.Text = "ERROR! Wrong symbols in number 2";
            }

            else if (ErrCode == 1)
            {
                result1.Visible = true;
                result1.Text = "ERROR! Wrong symbols in number 1"; //проверка первой строки на символы
            }

            else if ((inputString1.Length != 32) || (inputString2.Length > 2)) //проверка строк на размер
            {
                result1.Visible = true;
                result1.Text = "ERROR! Wrong number of symbols";
            }

            else
            {
                int num = Convert.ToInt32(inputString1, 2);
                int bit = Convert.ToInt32(inputString2);
                if (bit > 31)
                {
                    result1.Visible = true;
                    result1.Text = "ERROR! Wrong size of number 2"; //проверка первой строки на символы 2
                }
                else
                {
                    int res = (num >> bit) & 1; //КЛЮЧЕВАЯ СТРОКА
                    result1.Visible = true;
                    result1.Text = Convert.ToString(res);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) //выставление бита
        {
            string inputString1 = box1.Text;
            string inputString2 = box3.Text;
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

            else if ((inputString1.Length != 32) || (inputString2.Length > 2)) //проверка строк на размер
            {
                result2.Visible = true;
                result2.Text = "ERROR! Wrong number of symbols";
            }

            else
            {
                uint num = Convert.ToUInt32(inputString1, 2);
                int bit = Convert.ToInt32(inputString2);
                if (bit > 31)
                {
                    result2.Visible = true;
                    result2.Text = "ERROR! Wrong size of number 2";
                }
                else
                {
                    uint res = num | (1u << bit); //КЛЮЧЕВАЯ СТРОКА
                    string resStr = Transform(res);

                    result2.Visible = true;
                    result2.Text = Convert.ToString(resStr);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) //снятие бита
        {
            string inputString1 = box1.Text;
            string inputString2 = box4.Text;
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
                result3.Visible = true;
                result3.Text = "ERROR! Empty number";
            }

            else if (!Int32.TryParse(inputString2, out tryParseRes)) //проверка второй строки на символы
            {
                result3.Visible = true;
                result3.Text = "ERROR! Wrong symbols in number 2";
            }

            else if (ErrCode == 1)
            {
                result3.Visible = true;
                result3.Text = "ERROR! Wrong symbols in number 1"; //проверка первой строки на символы
            }

            else if ((inputString1.Length != 32) || (inputString2.Length > 2)) //проверка строк на размер
            {
                result3.Visible = true;
                result3.Text = "ERROR! Wrong number of symbols";
            }

            else
            {
                uint num = Convert.ToUInt32(inputString1, 2);
                int bit = Convert.ToInt32(inputString2);
                if (bit > 31)
                {
                    result3.Visible = true;
                    result3.Text = "ERROR! Wrong size of number 2";
                }
                else
                {
                    uint res = num & ~(1u << bit);  //КЛЮЧЕВАЯ СТРОКА
                    string resStr = Transform(res);

                    result3.Visible = true;
                    result3.Text = Convert.ToString(resStr);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e) //поменять местами два бита
        {
            string inputString1 = box1.Text, inputString2 = box5.Text, inputString3 = box6.Text;

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

            if ((inputString1 == "") || (inputString2 == "") || (inputString3 == "")) //проверка строк на пустоту  
            {
                result4.Visible = true;
                result4.Text = "ERROR! Empty number";
            }

            else if (!Int32.TryParse(inputString2, out tryParseRes)) //проверка второй строки на символы
            {
                result4.Visible = true;
                result4.Text = "ERROR! Wrong symbols in number 2";
            }

            else if (!Int32.TryParse(inputString3, out tryParseRes)) //проверка второй строки на символы
            {
                result4.Visible = true;
                result4.Text = "ERROR! Wrong symbols in number 3";
            }

            else if (ErrCode == 1)
            {
                result4.Visible = true;
                result4.Text = "ERROR! Wrong symbols in number 1"; //проверка первой строки на символы
            }

            else if ((inputString1.Length != 32) || (inputString2.Length > 2) || (inputString3.Length > 2)) //проверка строк на размер
            {
                result4.Visible = true;
                result4.Text = "ERROR! Wrong number of symbols";
            }

            else
            {
                uint num = Convert.ToUInt32(inputString1, 2);
                int bit1 = Convert.ToInt32(inputString2), bit2 = Convert.ToInt32(inputString3);

                if (bit1 > 31)
                {
                    result4.Visible = true;
                    result4.Text = "ERROR! Wrong size of number 2";
                }
                else if (bit2 > 31)
                {
                    result4.Visible = true;
                    result4.Text = "ERROR! Wrong size of number 3";
                }
                else
                { //КЛЮЧЕВАЯ ЧАСТЬ
                    if ((((num >> bit1) & 1) == 1) && (((num >> bit2) & 1) == 0))  //если первый бит 1, второй 0
                    {
                        num &= ~(1u << bit1);  //снимаем  первый бит
                        num |= (1u << bit2); //устанавливаем второй бит
                    }
                    else if (((((num >> bit1) & 1) == 0) && (((num >> bit2) & 1) == 1))) //если первый бит 0, второй 1
                    {
                        num &= ~(1u << bit2);  //снимаем второй бит
                        num |= (1u << bit1); //устанавливаем второй бит
                    }

                    string resStr = Transform(num);

                    result4.Visible = true;
                    result4.Text = Convert.ToString(resStr);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e) //обнулить младшие биты
        {
            string inputString1 = box1.Text;
            string inputString2 = box7.Text;
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
                result5.Visible = true;
                result5.Text = "ERROR! Empty number";
            }

            else if (!Int32.TryParse(inputString2, out tryParseRes)) //проверка второй строки на символы
            {
                result5.Visible = true;
                result5.Text = "ERROR! Wrong symbols in number 2";
            }

            else if (ErrCode == 1)
            {
                result5.Visible = true;
                result5.Text = "ERROR! Wrong symbols in number 1"; //проверка первой строки на символы
            }

            else if ((inputString1.Length != 32) || (inputString2.Length > 2)) //проверка строк на размер
            {
                result5.Visible = true;
                result5.Text = "ERROR! Wrong number of symbols";
            }

            else
            {
                uint num = Convert.ToUInt32(inputString1, 2);
                int bit = Convert.ToInt32(inputString2);
                if (bit > 31)
                {
                    result5.Visible = true;
                    result5.Text = "ERROR! Wrong size of number 2";
                }
                else if (bit == 31)
                {
                    result5.Visible = true;
                    result5.Text = "00000000000000000000000000000000";
                }
                else
                {
                    uint res = num & ((~0u) << (bit + 1));  //КЛЮЧЕВАЯ СТРОКА
                    string resStr = Transform(res);

                    result5.Visible = true;
                    result5.Text = Convert.ToString(resStr);
                }
            }
        }
    }
}

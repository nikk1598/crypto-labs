using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crypto_lab8 { 
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string Transform(ulong num, string[] input) //функция, которая осуществляет перевод в двоичную систему
        {
            string preResult = "";
            while (num > 0)
            {
                preResult += num % 2;
                num /= 2;
            }
            char[] preResReverse = preResult.ToCharArray();
            Array.Reverse(preResReverse);
            string result = new string(preResReverse).PadLeft(input.Length, '0');
            return result;
        }

        public static ulong InitialPermutation(ulong block, string[] input) //функция, которая осуществляет перестановку
        {
            int inputArrLength = input.GetLength(0);

            int[] initialPermutationArray = new int[inputArrLength];

            for (int i = 0; i < inputArrLength; i++)
            {
                initialPermutationArray[i] = Convert.ToInt32(input[i]);
            }

            ulong result = 0;
            for (int i = 0; i < initialPermutationArray.Length; i++)
            {
                byte b = (byte)((block >> (inputArrLength - initialPermutationArray[i] - 1)) & 1);
                if (b == 1)
                {
                    result |= (1UL << (inputArrLength - i - 1));
                }
                else
                    result &= (~(1UL << (inputArrLength - i - 1)));
            }
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ErrCode = 0, num = 0;
            string inputString1 = box1.Text;
            string inputString2 = box2.Text;
            string[] inputString2Arr = inputString2.Split(',');

            for (int i = 0; i < inputString1.Length; i++)
            {
                if ((inputString1[i] != '0') && (inputString1[i] != '1'))
                {
                    ErrCode = 1;
                    break;
                }
            }
            for (int i = 0; i < inputString2.Length; i++)
            {
                if ((inputString2[i] - '0' > 10) || (inputString2[i] - '0' < -1) && (inputString2[i] != ','))
                {
                    ErrCode = 1;
                    break;
                }

                if ((i != inputString2.Length - 1) && ((inputString2[i] == ',') && (inputString2[i + 1] == ',')))
                {
                    ErrCode = 1;
                    break;
                }
                /* if (inputString2[i] > inputString1.Length)
                {
                    ErrCode = 1;
                    break;
                } */
            }


            if ((inputString1 == "") || (inputString2 == "")) //проверка строк на пустоту  
            {
                result.Visible = true;
                result.Text = "ERROR! Empty string";
            }
            else if ((inputString1.Length > 64) || (inputString2.Length > 64)) //проверка строк на размер
            {
                result.Visible = true;
                result.Text = "ERROR! Too big string";
            }
            else if (ErrCode == 1) //проверка строк на символы 
            {
                result.Visible = true;
                result.Text = "ERROR! Wrong symbols";
            }

            else if ((inputString2[inputString2.Length - 1] == ',') || (inputString2[0] == ','))
            {
                result.Visible = true;
                result.Text = "ERROR! Wrong symbols";
            }

            else if (inputString1.Length != inputString2Arr.Length) //проверка строк на равенство символов 
            {
                result.Visible = true;
                result.Text = "ERROR! String lengths do not match";
            }


            else
            {
                char[] preResReverse = inputString1.ToCharArray();
                Array.Reverse(preResReverse);
                string resString = new string(preResReverse);

                ulong inputUlong = Convert.ToUInt64(resString, 2);

                ulong permutedInputUlong = InitialPermutation(inputUlong, inputString2Arr);

                string res = Transform(permutedInputUlong, inputString2Arr);

                result.Visible = true;
                result.Text = res;
            }
        }
    }
}

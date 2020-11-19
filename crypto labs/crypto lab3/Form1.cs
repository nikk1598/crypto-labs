using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crypto_lab3
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
            int ErrCode = 0;


            char[] inputString1ArrOfChar = inputString1.ToCharArray();
            char[] inputString2ArrOfChar = inputString2.ToCharArray();

            for (int i = 0; i < inputString1.Length; i++)
            {
                if ((inputString1ArrOfChar[i] != '0') && (inputString1ArrOfChar[i] != '1'))
                {
                    ErrCode = 1;
                    break;
                }
            }

            for (int i = 0; i < inputString2.Length; i++)
            {
                if ((inputString2ArrOfChar[i] != '0') && (inputString2ArrOfChar[i] != '1')
                                && (inputString2ArrOfChar[i] != '2') && (inputString2ArrOfChar[i] != '3'))
                {
                    ErrCode = 2;
                    break;
                }
            }

            if ((inputString1 == "") || (inputString2 == "")) //проверка строк на пустоту  
            {
                result.Visible = true;
                result.Text = "ERROR! Empty number";
            }

            else if (ErrCode == 1) //проверка первой строки на символы
            {
                result.Visible = true;
                result.Text = "ERROR! Wrong symbols in number 1";
            }

            else if (ErrCode == 2) //проверка второй строки на символы
            {
                result.Visible = true;
                result.Text = "ERROR! Wrong symbols in number 2";
            }

            else if ((inputString1.Length != 32) || (inputString2.Length != 4)) //проверка строк на размер
            {
                result.Visible = true;
                result.Text = "ERROR! Wrong number of symbols";
            }
            else
            {
                int[] bytePermutation = new int[4];
                uint[] preResultArray = new uint[4];
                uint num = Convert.ToUInt32(inputString1, 2), res = 0; ;
                int padLeftNumOfBits = 0, padRightNumOfBits = 0;

                for (int i = 0; i < 4; i++)
                {
                    bytePermutation[i] = Convert.ToInt32(inputString2ArrOfChar[i]);
                }

                for (int i = 0; i < 4; i++)
                {
                    padRightNumOfBits = 8 * bytePermutation[i];
                    preResultArray[i] = ((num >> padRightNumOfBits) & (~((~0 << 8)))) << padLeftNumOfBits;
                    padLeftNumOfBits += 8;
                }

                res |= preResultArray[0] | preResultArray[1] | preResultArray[2] | preResultArray[3];
                string resString = Convert.ToString(res, 2).PadLeft(32, '0');

                result.Visible = true;
                result.Text = resString;
            }
        }
    }
}

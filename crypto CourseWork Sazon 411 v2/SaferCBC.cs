using System;
using System.Threading;

namespace crypto_CourseWork_Sazon_411_v2
{
    static class SaferCBC
    {
        public static void LabelChange(Form1 obj, string info)
        {
            obj.BeginInvoke(new ThreadStart(delegate
            {
                obj.progressLabel.Text = info;
            }));
        }
        public static void ProgressBarInit(Form1 obj, int max, int step)
        {
            obj.BeginInvoke(new ThreadStart(delegate
            {
                obj.progressBar1.Maximum = max;
                obj.progressBar1.Step = step;
                obj.progressBar1.Value = 0;
            }));
        }

        public static void ProgressBarStep(Form1 obj)
        {
            obj.BeginInvoke(new ThreadStart(delegate
            {
                obj.progressBar1.PerformStep();
            }));
        }

        public static byte[] Encrypt(byte[] inputBytes, byte[] inputKey, Form1 obj, CancellationToken token)
        {
            byte valueInPadding = 1; //число, которое будет на 1 больше числа недостающих байт (соотв. с рекомнедацией)
            byte[] bytesToGo = new byte[8], bytesResult = new byte[inputBytes.Length + 8], vector = new byte[8];
            int inputBytesArrNewLength = inputBytes.Length;

            if (inputKey.Length != 8)
            {
                LabelChange(obj, "      Wrong key file!");
                return inputBytes;
            }

            while (inputBytesArrNewLength % 8 != 0) //получаем это число
            {
                inputBytesArrNewLength++;
                valueInPadding++;
            }
            Array.Resize(ref inputBytes, inputBytesArrNewLength);
            Array.Resize(ref bytesResult, inputBytesArrNewLength + 8);
            for (int i = 0; i < 8; i++)
                vector[i] = (byte)(valueInPadding);

            bytesToGo = Safer.Encrypt(BitConverter.GetBytes((long)(valueInPadding - 1)), inputKey); //превращаем его в массив из 8 байтов

            Array.Copy(bytesToGo, 0, bytesResult, 0, 8); //записываем полученный массив байт как первые 8 байтов результирующего массива 

            for (int i = inputBytes.Length - valueInPadding + 1; i < inputBytes.Length; i++) //забиваем числом недостающие байты 
            { 
                inputBytes[i] = valueInPadding;
            }

            LabelChange(obj, " Encrypting your data");  //шифруем данные 
            ProgressBarInit(obj, inputBytes.Length, 8);
            for (int i = 0; i < inputBytes.Length; i = i + 8)
            {
                if (token.IsCancellationRequested)
                {
                    ProgressBarInit(obj, 0, 0);
                    return inputBytes;
                }
;

                Array.Copy(inputBytes, i, bytesToGo, 0, 8);

                for (int j = 0; j < 8; j++)
                    bytesToGo[j] ^= vector[j];

  
               bytesToGo = Safer.Encrypt(bytesToGo, inputKey);

               Array.Copy(bytesToGo, 0, vector, 0, 8);

               Array.Copy(bytesToGo, 0, bytesResult, i + 8, 8);

                ProgressBarStep(obj);
            }
            LabelChange(obj, "     Result is ready!");
            return bytesResult;
        }

        public static byte[] Decrypt(byte[] inputBytes, byte[] inputKey, Form1 obj, CancellationToken token)
        {
            int lengthOfPadding = 0;
            byte[] bytesToGo = new byte[8], bytesResult = new byte[inputBytes.Length - 8], vector = new byte[8], savedBytes=new byte[8];

            if (inputBytes.Length % 8 != 0) 
            {
                LabelChange(obj, "     Wrong data file!");
                return inputBytes;
            }

            if (inputKey.Length != 8)
            {
                LabelChange(obj, "      Wrong key file!");
                return inputBytes;
            }

            Array.Copy(inputBytes, 0, bytesToGo, 0, 8);

            lengthOfPadding = (int)BitConverter.ToInt64(Safer.Decrypt(bytesToGo, inputKey), 0);
            for (int i = 0; i < 8; i++)
                vector[i] =(byte) (lengthOfPadding + 1);

            LabelChange(obj, " Decrypting your data");
            ProgressBarInit(obj, inputBytes.Length-8, 8);
            for (int i = 8; i < inputBytes.Length; i = i + 8)
            {
                if (token.IsCancellationRequested)
                {
                    ProgressBarInit(obj, 0, 0);
                    return inputBytes;
                }

                Array.Copy(inputBytes, i, bytesToGo, 0, 8);

                Array.Copy(inputBytes, i, savedBytes, 0, 8);

                bytesToGo = Safer.Decrypt(bytesToGo, inputKey);
               
               for (int j = 0; j < 8; j++)
                    bytesToGo[j] ^= vector[j];

                Array.Copy(savedBytes, 0, vector, 0, 8);

                Array.Copy(bytesToGo, 0, bytesResult, i - 8, 8);

                ProgressBarStep(obj);
            }
            Array.Resize(ref bytesResult, bytesResult.Length - lengthOfPadding);
            LabelChange(obj, "     Result is ready!");
            return bytesResult;
        }
    }
}


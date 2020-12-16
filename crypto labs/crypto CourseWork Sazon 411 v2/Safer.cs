using System;
using System.Numerics;

namespace crypto_CourseWork_Sazon_411_v2
{
    static class Safer
    {
        public static byte[] Encrypt(byte[] partsOfBlock, byte[] inputKey)
        {
            int numOfIterations = 6; //число раундов шифрования
            byte[] partsOfKey1 = new byte[8], partsOfKey2 = new byte[8]; /* массивы, в которых
            будет храниться разбитый на байты текст и разбитые на байты текущие ключи - два ключа, используемые в конкретной итерации */
            int[] exptab = new int[257]; //массив, в котором будут храниться значения первого s-Box
            int[] logtab = new int[257]; //массив, в котором будут храниться значения второго s-Box

            byte[,] arrOfKeys = KeysGeneration(inputKey, numOfIterations); //генерация массива ключей

            exptab[0] = 1; logtab[1] = 0; //заполнение s-Boxes
            for (int i = 1; i <= 255; i++)
            {
                exptab[i] = 45 * exptab[i - 1] % 257;
                logtab[exptab[i]] = i;
            }
            exptab[128] = 0; logtab[0] = 128; exptab[0] = 1;


            for (int numOfIteration = 1; numOfIteration <= numOfIterations; numOfIteration++) //основная часть, в которой выполняются все раунды шифрования
            {

                for (int i = 1; i <= 8; i++)  //получение ключей из массива ключей
                {
                    partsOfKey1[i - 1] = arrOfKeys[2 * numOfIteration - 1, i];
                    partsOfKey2[i - 1] = arrOfKeys[2 * numOfIteration, i];
                }

                partsOfBlock[0] ^= partsOfKey1[0]; //побайтовые XOR и сумма по модулю (первый ключ)
                partsOfBlock[3] ^= partsOfKey1[3];
                partsOfBlock[4] ^= partsOfKey1[4];
                partsOfBlock[7] ^= partsOfKey1[7];
                partsOfBlock[1] = (byte)SumModule(partsOfBlock[1], partsOfKey1[1]);
                partsOfBlock[2] = (byte)SumModule(partsOfBlock[2], partsOfKey1[2]);
                partsOfBlock[5] = (byte)SumModule(partsOfBlock[5], partsOfKey1[5]);
                partsOfBlock[6] = (byte)SumModule(partsOfBlock[6], partsOfKey1[6]);

                partsOfBlock[0] = (byte)exptab[partsOfBlock[0]]; //s-Boxes
                partsOfBlock[3] = (byte)exptab[partsOfBlock[3]];
                partsOfBlock[4] = (byte)exptab[partsOfBlock[4]];
                partsOfBlock[7] = (byte)exptab[partsOfBlock[7]];
                partsOfBlock[1] = (byte)logtab[partsOfBlock[1]];
                partsOfBlock[2] = (byte)logtab[partsOfBlock[2]];
                partsOfBlock[5] = (byte)logtab[partsOfBlock[5]];
                partsOfBlock[6] = (byte)logtab[partsOfBlock[6]];

                partsOfBlock[0] = (byte)SumModule(partsOfBlock[0], partsOfKey2[0]);  //побайтовые XOR и сумма по модулю (второй ключ)
                partsOfBlock[3] = (byte)SumModule(partsOfBlock[3], partsOfKey2[3]);
                partsOfBlock[4] = (byte)SumModule(partsOfBlock[4], partsOfKey2[4]);
                partsOfBlock[7] = (byte)SumModule(partsOfBlock[7], partsOfKey2[7]);
                partsOfBlock[1] ^= partsOfKey2[1];
                partsOfBlock[2] ^= partsOfKey2[2];
                partsOfBlock[5] ^= partsOfKey2[5];
                partsOfBlock[6] ^= partsOfKey2[6];

                partsOfBlock = PHT(partsOfBlock); //PHT-преобразование
            }


            for (int i = 1; i <= 8; i++) //дополнительная часть, в которой задействуется последний ключ шифрования
            {
                partsOfKey1[i - 1] = arrOfKeys[2 * numOfIterations + 1, i];
            }

            partsOfBlock[0] ^= partsOfKey1[0];
            partsOfBlock[3] ^= partsOfKey1[3];
            partsOfBlock[4] ^= partsOfKey1[4];
            partsOfBlock[7] ^= partsOfKey1[7];
            partsOfBlock[1] = (byte)SumModule(partsOfBlock[1], partsOfKey1[1]);
            partsOfBlock[2] = (byte)SumModule(partsOfBlock[2], partsOfKey1[2]);
            partsOfBlock[5] = (byte)SumModule(partsOfBlock[5], partsOfKey1[5]);
            partsOfBlock[6] = (byte)SumModule(partsOfBlock[6], partsOfKey1[6]);

            return partsOfBlock; //возврат результирующего шифротекста 

        }

        public static byte[] Decrypt(byte[] partsOfBlock, byte[] inputKey)
        {
            int numOfIterations = 6; //число раундов шифрования
            byte[] partsOfKey1 = new byte[8], partsOfKey2 = new byte[8]; /* массивы, в которых
            будет храниться разбитый на байты текст и разбитые на байты текущие ключи - два ключа, используемые в конкретной итерации */
            int[] exptab = new int[257]; //массив, в котором будут храниться значения первого s-Box
            int[] logtab = new int[257]; //массив, в котором будут храниться значения второго s-Box
            string outputString = "";
            ulong outputNum = 0;
            byte[,] arrOfKeys = KeysGeneration(inputKey, numOfIterations); //генерация массива ключей

            exptab[0] = 1; logtab[1] = 0; //заполнение s-Boxes
            for (int i = 1; i <= 255; i++)
            {
                exptab[i] = 45 * exptab[i - 1] % 257;
                logtab[exptab[i]] = i;
            }
            exptab[128] = 0; logtab[0] = 128; exptab[0] = 1;

     

            for (int i = 1; i <= 8; i++)
            {
                partsOfKey1[i - 1] = arrOfKeys[2 * numOfIterations + 1, i];
            }

            partsOfBlock[0] ^= partsOfKey1[0];
            partsOfBlock[3] ^= partsOfKey1[3];
            partsOfBlock[4] ^= partsOfKey1[4];
            partsOfBlock[7] ^= partsOfKey1[7];
            partsOfBlock[1] = (byte)DiffModule(partsOfBlock[1], partsOfKey1[1]);
            partsOfBlock[2] = (byte)DiffModule(partsOfBlock[2], partsOfKey1[2]);
            partsOfBlock[5] = (byte)DiffModule(partsOfBlock[5], partsOfKey1[5]);
            partsOfBlock[6] = (byte)DiffModule(partsOfBlock[6], partsOfKey1[6]);



            for (int numOfIteration = numOfIterations; numOfIteration >= 1; numOfIteration--)
            {

                partsOfBlock = IPHT(partsOfBlock);
                for (int i = 1; i <= 8; i++)  //получение ключей из массива ключей
                {
                    partsOfKey1[i - 1] = arrOfKeys[2 * numOfIteration - 1, i];
                    partsOfKey2[i - 1] = arrOfKeys[2 * numOfIteration, i];
                }
                partsOfBlock[0] = (byte)DiffModule(partsOfBlock[0], partsOfKey2[0]);  //побайтовые XOR и сумма по модулю (второй ключ)
                partsOfBlock[3] = (byte)DiffModule(partsOfBlock[3], partsOfKey2[3]);
                partsOfBlock[4] = (byte)DiffModule(partsOfBlock[4], partsOfKey2[4]);
                partsOfBlock[7] = (byte)DiffModule(partsOfBlock[7], partsOfKey2[7]);
                partsOfBlock[1] ^= partsOfKey2[1];
                partsOfBlock[2] ^= partsOfKey2[2];
                partsOfBlock[5] ^= partsOfKey2[5];
                partsOfBlock[6] ^= partsOfKey2[6];

                partsOfBlock[0] = (byte)logtab[partsOfBlock[0]]; //s-Boxes
                partsOfBlock[3] = (byte)logtab[partsOfBlock[3]];
                partsOfBlock[4] = (byte)logtab[partsOfBlock[4]];
                partsOfBlock[7] = (byte)logtab[partsOfBlock[7]];
                partsOfBlock[1] = (byte)exptab[partsOfBlock[1]];
                partsOfBlock[2] = (byte)exptab[partsOfBlock[2]];
                partsOfBlock[5] = (byte)exptab[partsOfBlock[5]];
                partsOfBlock[6] = (byte)exptab[partsOfBlock[6]];

                partsOfBlock[0] ^= partsOfKey1[0]; //побайтовые XOR и сумма по модулю (первый ключ)
                partsOfBlock[3] ^= partsOfKey1[3];
                partsOfBlock[4] ^= partsOfKey1[4];
                partsOfBlock[7] ^= partsOfKey1[7];
                partsOfBlock[1] = (byte)DiffModule(partsOfBlock[1], partsOfKey1[1]);
                partsOfBlock[2] = (byte)DiffModule(partsOfBlock[2], partsOfKey1[2]);
                partsOfBlock[5] = (byte)DiffModule(partsOfBlock[5], partsOfKey1[5]);
                partsOfBlock[6] = (byte)DiffModule(partsOfBlock[6], partsOfKey1[6]);
            }

            return partsOfBlock;
        }

        static byte[,] KeysGeneration(byte[] inputKey, int numOfIterations) //функция, генерирующая массив ключей на основе ключа, заданного пользователем 
        {
            byte[] inputKeyArr = new byte[9]; //массив, в котором будем хранить ключ, заданный пользователем
            byte[,] outputKeys = new byte[2 * numOfIterations + 2, 9]; //массив, в котором будем хранить все сгенерированные ключи
            int powerInterim, constOfEncryption = 0; //промежуточная степень и константа шифрования

            for (int i = 1; i <= 8; i++)
            {
                inputKeyArr[i] = inputKey[i - 1];
            }

            for (int i = 2; i <= 2 * numOfIterations + 1; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    powerInterim = (int)(BigInteger.Pow(45, (9 * i + j) % 256) % 257);
                    constOfEncryption = (int)(BigInteger.Pow(45, powerInterim) % 257);
                    outputKeys[i, j] = (byte)((((byte)(inputKeyArr[j] >> 3) | (byte)(inputKeyArr[j] << 5)) + constOfEncryption) % 257);
                }
            }
            return outputKeys;
        }

        public static byte SumModule(byte num1, byte num2)
        {
            return (byte)((num1 + num2) % 256);
        }

        public static byte DiffModule(byte num1, byte num2)
        {
            return (byte)((num1 - num2) % 256);
        }

        public static byte[] PHT(byte[] arr)
        {
            int[] mix = { 0, 2, 4, 6, 1, 3, 5, 7 };
            byte[] res = new byte[8];

            for (int i = 0; i < 3; i++)
            {
                arr[1] = (byte)((arr[0] + arr[1]) % 256);
                arr[0] = (byte)((arr[0] + arr[1]) % 256);
                arr[3] = (byte)((arr[2] + arr[3]) % 256);
                arr[2] = (byte)((arr[3] + arr[2]) % 256);
                arr[5] = (byte)((arr[4] + arr[5]) % 256);
                arr[4] = (byte)((arr[5] + arr[4]) % 256);
                arr[7] = (byte)((arr[6] + arr[7]) % 256);
                arr[6] = (byte)((arr[7] + arr[6]) % 256);

                for (int j = 0; j < 8; j++)
                {
                    res[j] = arr[mix[j]];
                }

                for (int j = 0; j < 8; j++)
                {
                    arr[j] = res[j];
                }
            }

            for (int j = 0; j < 8; j++)
            {
                res[mix[j]] = arr[j];
            }
            return res;
        }

        public static byte[] IPHT(byte[] res)
        {
            int[] mix = { 0, 2, 4, 6, 1, 3, 5, 7 };
            byte[] arr = new byte[8];

            for (int j = 0; j < 8; j++)
            {
                arr[j] = res[mix[j]];
            }


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    res[j] = arr[j];
                }

                for (int j = 0; j < 8; j++)
                {
                    arr[mix[j]] = res[j];
                }

                arr[0] = (byte)((arr[0] - arr[1]) % 256);
                arr[1] = (byte)((-arr[0] + arr[1]) % 256);
                arr[2] = (byte)((arr[2] - arr[3]) % 256);
                arr[3] = (byte)((-arr[2] + arr[3]) % 256);
                arr[4] = (byte)((arr[4] - arr[5]) % 256);
                arr[5] = (byte)((-arr[4] + arr[5]) % 256);
                arr[6] = (byte)((arr[6] - arr[7]) % 256);
                arr[7] = (byte)((-arr[6] + arr[7]) % 256);
            }
            return arr;
        }
    }
}

using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Threading;

namespace crypto_CourseWork_Sazon_411_v2
{
    public partial class Form1 : Form
    {
        string nameOfInputFile="", nameOfKeyFile="", nameOfOutputFile="";
        byte[] resultOfAlgorithm;
        CancellationTokenSource cancelTokenSource= new CancellationTokenSource();
        public delegate  byte[] Encryption(byte[] inputData, byte[] inputKey, Form1 obj, CancellationToken token);
        public delegate byte[] Decryption(byte[] inputData, byte[] inputKey, Form1 obj, CancellationToken token);
        Encryption enc;
        Decryption dec;
        public Form1()
        {
            InitializeComponent();
        }

        private void ECB_CheckedChanged(object sender, EventArgs e)
        {
            enc = new Encryption(crypto_CourseWork_Sazon_411_v2.SaferECB.Encrypt);
            dec = new Decryption(crypto_CourseWork_Sazon_411_v2.SaferECB.Decrypt);
        }

        private void CBC_CheckedChanged(object sender, EventArgs e)
        {
           enc = new Encryption(crypto_CourseWork_Sazon_411_v2.SaferCBC.Encrypt);
            dec = new Decryption(crypto_CourseWork_Sazon_411_v2.SaferCBC.Decrypt);
        }

        private void CFB_CheckedChanged(object sender, EventArgs e)
        {
           enc = new Encryption(crypto_CourseWork_Sazon_411_v2.SaferCFB.Encrypt);
            dec = new Decryption(crypto_CourseWork_Sazon_411_v2.SaferCFB.Decrypt);
        }

        private void OFB_CheckedChanged(object sender, EventArgs e)
        {
            enc = new Encryption(crypto_CourseWork_Sazon_411_v2.SaferOFB.Encrypt);
             dec = new Decryption(crypto_CourseWork_Sazon_411_v2.SaferOFB.Decrypt);
        }

        private async void Encrypt_Click(object sender, EventArgs e)
        {
           cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;
            OpenKeyFileBut.Enabled = false;
            OpenTextFileBut.Enabled = false;
            SaveResultBut.Enabled = false;
            EncryptBut.Enabled = false;
            DecryptBut.Enabled = false;
            ECB.Enabled = false;
            CBC.Enabled = false;
            CFB.Enabled = false;
            OFB.Enabled = false;

            try
            {
                resultOfAlgorithm = await Task.Run(() =>
                 {
                     return enc(File.ReadAllBytes(@nameOfInputFile), File.ReadAllBytes(nameOfKeyFile), this, token);
                 });
            }
            catch (System.ArgumentException)
            {
                progressLabel.Text = " Empty file. Try again";
            }
            finally
            {
                OpenKeyFileBut.Enabled = true;
                OpenTextFileBut.Enabled = true;
                EncryptBut.Enabled = true;
                DecryptBut.Enabled = true;
                SaveResultBut.Enabled = true;
                ECB.Enabled = true;
                CBC.Enabled = true;
                CFB.Enabled = true;
                OFB.Enabled = true;
            }
        }

        private async void Decrypt_Click(object sender, EventArgs e)
        {
            cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;
            OpenKeyFileBut.Enabled = false;
            OpenTextFileBut.Enabled = false;
            SaveResultBut.Enabled = false;
            EncryptBut.Enabled = false;
            DecryptBut.Enabled = false;
            ECB.Enabled = false;
            CBC.Enabled = false;
            CFB.Enabled = false;
            OFB.Enabled = false;

            try
            {
                resultOfAlgorithm = await Task.Run(() =>
                {
                    return dec(File.ReadAllBytes(@nameOfInputFile), File.ReadAllBytes(nameOfKeyFile), this, token);
                });
            }
            catch (System.ArgumentException)
            {
                progressLabel.Text = " Empty file. Try again";
            }
            finally
            {
                OpenKeyFileBut.Enabled = true;
                OpenTextFileBut.Enabled = true;
                EncryptBut.Enabled = true;
                DecryptBut.Enabled = true;
                SaveResultBut.Enabled = true;
                ECB.Enabled = true;
                CBC.Enabled = true;
                CFB.Enabled = true;
                OFB.Enabled = true;
                
            }
        }
            private void OpenTextFileBut_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                nameOfInputFile = openFileDialog1.FileName;
                TextFileNameLabel.Text = nameOfInputFile;
            }
        }

        private void cancelBut_Click(object sender, EventArgs e)
        {
            cancelTokenSource.Cancel();
        }

        private void restartBut_Click(object sender, EventArgs e)
        {
              Application.Restart();
        }

        private void OpenKeyFileBut_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                nameOfKeyFile = openFileDialog1.FileName;
                KeyFileNameLabel.Text = nameOfKeyFile;
            }
        }

        private void SaveResultBut_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                nameOfOutputFile = saveFileDialog1.FileName;
                try
                {
                    File.WriteAllBytes(nameOfOutputFile, resultOfAlgorithm);
                    progressLabel.Text = "     Result is saved!";
                }
                catch (System.ArgumentException)
                {
                    progressLabel.Text = " Empty file. Try again";
                }
            }
        }
    }
}

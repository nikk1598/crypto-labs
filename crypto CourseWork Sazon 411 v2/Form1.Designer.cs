namespace crypto_CourseWork_Sazon_411_v2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ECB = new System.Windows.Forms.RadioButton();
            this.CBC = new System.Windows.Forms.RadioButton();
            this.CFB = new System.Windows.Forms.RadioButton();
            this.OFB = new System.Windows.Forms.RadioButton();
            this.EncryptBut = new System.Windows.Forms.Button();
            this.DecryptBut = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.OpenTextFileBut = new System.Windows.Forms.Button();
            this.OpenKeyFileBut = new System.Windows.Forms.Button();
            this.TextFileNameLabel = new System.Windows.Forms.Label();
            this.KeyFileNameLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SaveResultBut = new System.Windows.Forms.Button();
            this.progressLabel = new System.Windows.Forms.Label();
            this.cancelBut = new System.Windows.Forms.Button();
            this.restartBut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ECB
            // 
            this.ECB.AutoSize = true;
            this.ECB.Location = new System.Drawing.Point(469, 140);
            this.ECB.Name = "ECB";
            this.ECB.Size = new System.Drawing.Size(56, 21);
            this.ECB.TabIndex = 0;
            this.ECB.TabStop = true;
            this.ECB.Text = "ECB";
            this.ECB.UseVisualStyleBackColor = true;
            this.ECB.CheckedChanged += new System.EventHandler(this.ECB_CheckedChanged);
            // 
            // CBC
            // 
            this.CBC.AutoSize = true;
            this.CBC.Location = new System.Drawing.Point(540, 140);
            this.CBC.Name = "CBC";
            this.CBC.Size = new System.Drawing.Size(56, 21);
            this.CBC.TabIndex = 1;
            this.CBC.TabStop = true;
            this.CBC.Text = "CBC";
            this.CBC.UseVisualStyleBackColor = true;
            this.CBC.CheckedChanged += new System.EventHandler(this.CBC_CheckedChanged);
            // 
            // CFB
            // 
            this.CFB.AutoSize = true;
            this.CFB.Location = new System.Drawing.Point(611, 140);
            this.CFB.Name = "CFB";
            this.CFB.Size = new System.Drawing.Size(55, 21);
            this.CFB.TabIndex = 2;
            this.CFB.TabStop = true;
            this.CFB.Text = "CFB";
            this.CFB.UseVisualStyleBackColor = true;
            this.CFB.CheckedChanged += new System.EventHandler(this.CFB_CheckedChanged);
            // 
            // OFB
            // 
            this.OFB.AutoSize = true;
            this.OFB.Location = new System.Drawing.Point(672, 140);
            this.OFB.Name = "OFB";
            this.OFB.Size = new System.Drawing.Size(57, 21);
            this.OFB.TabIndex = 3;
            this.OFB.TabStop = true;
            this.OFB.Text = "OFB";
            this.OFB.UseVisualStyleBackColor = true;
            this.OFB.CheckedChanged += new System.EventHandler(this.OFB_CheckedChanged);
            // 
            // EncryptBut
            // 
            this.EncryptBut.BackColor = System.Drawing.SystemColors.Info;
            this.EncryptBut.Location = new System.Drawing.Point(469, 167);
            this.EncryptBut.Name = "EncryptBut";
            this.EncryptBut.Size = new System.Drawing.Size(127, 41);
            this.EncryptBut.TabIndex = 4;
            this.EncryptBut.Text = "Encrypt";
            this.EncryptBut.UseVisualStyleBackColor = false;
            this.EncryptBut.Click += new System.EventHandler(this.Encrypt_Click);
            this.EncryptBut.Click += new System.EventHandler(this.Encrypt_Click);
            // 
            // DecryptBut
            // 
            this.DecryptBut.BackColor = System.Drawing.SystemColors.Info;
            this.DecryptBut.Location = new System.Drawing.Point(602, 167);
            this.DecryptBut.Name = "DecryptBut";
            this.DecryptBut.Size = new System.Drawing.Size(127, 41);
            this.DecryptBut.TabIndex = 5;
            this.DecryptBut.Text = "Decrypt";
            this.DecryptBut.UseVisualStyleBackColor = false;
            this.DecryptBut.Click += new System.EventHandler(this.Decrypt_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // OpenTextFileBut
            // 
            this.OpenTextFileBut.ForeColor = System.Drawing.Color.Black;
            this.OpenTextFileBut.Location = new System.Drawing.Point(12, 12);
            this.OpenTextFileBut.Name = "OpenTextFileBut";
            this.OpenTextFileBut.Size = new System.Drawing.Size(147, 26);
            this.OpenTextFileBut.TabIndex = 6;
            this.OpenTextFileBut.Text = "Open DataFile";
            this.OpenTextFileBut.UseVisualStyleBackColor = true;
            this.OpenTextFileBut.Click += new System.EventHandler(this.OpenTextFileBut_Click);
            // 
            // OpenKeyFileBut
            // 
            this.OpenKeyFileBut.Location = new System.Drawing.Point(12, 44);
            this.OpenKeyFileBut.Name = "OpenKeyFileBut";
            this.OpenKeyFileBut.Size = new System.Drawing.Size(147, 26);
            this.OpenKeyFileBut.TabIndex = 7;
            this.OpenKeyFileBut.Text = "Open KeyFile";
            this.OpenKeyFileBut.UseVisualStyleBackColor = true;
            this.OpenKeyFileBut.Click += new System.EventHandler(this.OpenKeyFileBut_Click);
            // 
            // TextFileNameLabel
            // 
            this.TextFileNameLabel.AutoSize = true;
            this.TextFileNameLabel.Location = new System.Drawing.Point(165, 21);
            this.TextFileNameLabel.Name = "TextFileNameLabel";
            this.TextFileNameLabel.Size = new System.Drawing.Size(51, 17);
            this.TextFileNameLabel.TabIndex = 8;
            this.TextFileNameLabel.Text = "Empty ";
            // 
            // KeyFileNameLabel
            // 
            this.KeyFileNameLabel.AutoSize = true;
            this.KeyFileNameLabel.Location = new System.Drawing.Point(165, 53);
            this.KeyFileNameLabel.Name = "KeyFileNameLabel";
            this.KeyFileNameLabel.Size = new System.Drawing.Size(51, 17);
            this.KeyFileNameLabel.TabIndex = 9;
            this.KeyFileNameLabel.Text = "Empty ";
            // 
            // progressBar1
            // 
            this.progressBar1.Cursor = System.Windows.Forms.Cursors.Default;
            this.progressBar1.Location = new System.Drawing.Point(487, 245);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(218, 30);
            this.progressBar1.TabIndex = 10;
            // 
            // SaveResultBut
            // 
            this.SaveResultBut.Location = new System.Drawing.Point(540, 331);
            this.SaveResultBut.Name = "SaveResultBut";
            this.SaveResultBut.Size = new System.Drawing.Size(117, 26);
            this.SaveResultBut.TabIndex = 12;
            this.SaveResultBut.Text = "Save result";
            this.SaveResultBut.UseVisualStyleBackColor = true;
            this.SaveResultBut.Click += new System.EventHandler(this.SaveResultBut_Click);
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(523, 278);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(141, 17);
            this.progressLabel.TabIndex = 13;
            this.progressLabel.Text = "  Progress of running";
            // 
            // cancelBut
            // 
            this.cancelBut.Location = new System.Drawing.Point(12, 76);
            this.cancelBut.Name = "cancelBut";
            this.cancelBut.Size = new System.Drawing.Size(73, 24);
            this.cancelBut.TabIndex = 14;
            this.cancelBut.Text = "Cancel";
            this.cancelBut.UseVisualStyleBackColor = true;
            this.cancelBut.Click += new System.EventHandler(this.cancelBut_Click);
            // 
            // restartBut
            // 
            this.restartBut.Location = new System.Drawing.Point(86, 76);
            this.restartBut.Name = "restartBut";
            this.restartBut.Size = new System.Drawing.Size(73, 24);
            this.restartBut.TabIndex = 15;
            this.restartBut.Text = "Restart";
            this.restartBut.UseVisualStyleBackColor = true;
            this.restartBut.Click += new System.EventHandler(this.restartBut_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1112, 503);
            this.Controls.Add(this.restartBut);
            this.Controls.Add(this.cancelBut);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.SaveResultBut);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.KeyFileNameLabel);
            this.Controls.Add(this.TextFileNameLabel);
            this.Controls.Add(this.OpenKeyFileBut);
            this.Controls.Add(this.OpenTextFileBut);
            this.Controls.Add(this.CFB);
            this.Controls.Add(this.CBC);
            this.Controls.Add(this.DecryptBut);
            this.Controls.Add(this.OFB);
            this.Controls.Add(this.EncryptBut);
            this.Controls.Add(this.ECB);
            this.MaximumSize = new System.Drawing.Size(1130, 550);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton ECB;
        private System.Windows.Forms.RadioButton CBC;
        private System.Windows.Forms.RadioButton CFB;
        private System.Windows.Forms.RadioButton OFB;
        private System.Windows.Forms.Button EncryptBut;
        private System.Windows.Forms.Button DecryptBut;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button OpenTextFileBut;
        private System.Windows.Forms.Button OpenKeyFileBut;
        private System.Windows.Forms.Label TextFileNameLabel;
        private System.Windows.Forms.Label KeyFileNameLabel;
        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.Label progressLabel;
        public System.Windows.Forms.Button SaveResultBut;
        private System.Windows.Forms.Button cancelBut;
        private System.Windows.Forms.Button restartBut;
    }
}


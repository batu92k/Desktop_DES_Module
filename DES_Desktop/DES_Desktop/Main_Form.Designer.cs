namespace DES_Desktop
{
    partial class Main_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.plainData1_Txb = new System.Windows.Forms.TextBox();
            this.plainData2_Txb = new System.Windows.Forms.TextBox();
            this.plainData3_Txb = new System.Windows.Forms.TextBox();
            this.plainDataHeader1_Lb = new System.Windows.Forms.Label();
            this.cipherDataHeader1_Lb = new System.Windows.Forms.Label();
            this.cipherData1_Lb = new System.Windows.Forms.Label();
            this.cipherData2_Lb = new System.Windows.Forms.Label();
            this.cipherData3_Lb = new System.Windows.Forms.Label();
            this.encode_Btn = new System.Windows.Forms.Button();
            this.decode_Btn = new System.Windows.Forms.Button();
            this.plainData3_Lb = new System.Windows.Forms.Label();
            this.plainData2_Lb = new System.Windows.Forms.Label();
            this.plainData1_Lb = new System.Windows.Forms.Label();
            this.plainDataHeader2_Lb = new System.Windows.Forms.Label();
            this.cipherDataHeader2_Lb = new System.Windows.Forms.Label();
            this.cipherData3_Txb = new System.Windows.Forms.TextBox();
            this.cipherData2_Txb = new System.Windows.Forms.TextBox();
            this.cipherData1_Txb = new System.Windows.Forms.TextBox();
            this.key_Txb = new System.Windows.Forms.TextBox();
            this.iv_Txb = new System.Windows.Forms.TextBox();
            this.key_Lb = new System.Windows.Forms.Label();
            this.iv_Lb = new System.Windows.Forms.Label();
            this.desMode_Cmb = new System.Windows.Forms.ComboBox();
            this.split1_Lb = new System.Windows.Forms.Label();
            this.mode_Lb = new System.Windows.Forms.Label();
            this.lock_PctBx = new System.Windows.Forms.PictureBox();
            this.split2_Lb = new System.Windows.Forms.Label();
            this.sign_Lb = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lock_PctBx)).BeginInit();
            this.SuspendLayout();
            // 
            // plainData1_Txb
            // 
            this.plainData1_Txb.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.plainData1_Txb.Location = new System.Drawing.Point(12, 41);
            this.plainData1_Txb.Name = "plainData1_Txb";
            this.plainData1_Txb.Size = new System.Drawing.Size(165, 22);
            this.plainData1_Txb.TabIndex = 0;
            this.plainData1_Txb.Text = "0x0123456789ABCDEF";
            // 
            // plainData2_Txb
            // 
            this.plainData2_Txb.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.plainData2_Txb.Location = new System.Drawing.Point(12, 74);
            this.plainData2_Txb.Name = "plainData2_Txb";
            this.plainData2_Txb.Size = new System.Drawing.Size(165, 22);
            this.plainData2_Txb.TabIndex = 1;
            this.plainData2_Txb.Text = "0x0123456789ABCDEF";
            // 
            // plainData3_Txb
            // 
            this.plainData3_Txb.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.plainData3_Txb.Location = new System.Drawing.Point(12, 107);
            this.plainData3_Txb.Name = "plainData3_Txb";
            this.plainData3_Txb.Size = new System.Drawing.Size(165, 22);
            this.plainData3_Txb.TabIndex = 2;
            this.plainData3_Txb.Text = "0x0123456789ABCDEF";
            // 
            // plainDataHeader1_Lb
            // 
            this.plainDataHeader1_Lb.AutoSize = true;
            this.plainDataHeader1_Lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.plainDataHeader1_Lb.Location = new System.Drawing.Point(12, 9);
            this.plainDataHeader1_Lb.Name = "plainDataHeader1_Lb";
            this.plainDataHeader1_Lb.Size = new System.Drawing.Size(144, 20);
            this.plainDataHeader1_Lb.TabIndex = 3;
            this.plainDataHeader1_Lb.Text = "Plain Data [hex]";
            // 
            // cipherDataHeader1_Lb
            // 
            this.cipherDataHeader1_Lb.AutoSize = true;
            this.cipherDataHeader1_Lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cipherDataHeader1_Lb.Location = new System.Drawing.Point(204, 9);
            this.cipherDataHeader1_Lb.Name = "cipherDataHeader1_Lb";
            this.cipherDataHeader1_Lb.Size = new System.Drawing.Size(157, 20);
            this.cipherDataHeader1_Lb.TabIndex = 4;
            this.cipherDataHeader1_Lb.Text = "Cipher Data [hex]";
            // 
            // cipherData1_Lb
            // 
            this.cipherData1_Lb.AutoSize = true;
            this.cipherData1_Lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cipherData1_Lb.Location = new System.Drawing.Point(200, 44);
            this.cipherData1_Lb.Name = "cipherData1_Lb";
            this.cipherData1_Lb.Size = new System.Drawing.Size(168, 17);
            this.cipherData1_Lb.TabIndex = 5;
            this.cipherData1_Lb.Text = "0x0000000000000000";
            // 
            // cipherData2_Lb
            // 
            this.cipherData2_Lb.AutoSize = true;
            this.cipherData2_Lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cipherData2_Lb.Location = new System.Drawing.Point(200, 77);
            this.cipherData2_Lb.Name = "cipherData2_Lb";
            this.cipherData2_Lb.Size = new System.Drawing.Size(168, 17);
            this.cipherData2_Lb.TabIndex = 6;
            this.cipherData2_Lb.Text = "0x0000000000000000";
            // 
            // cipherData3_Lb
            // 
            this.cipherData3_Lb.AutoSize = true;
            this.cipherData3_Lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cipherData3_Lb.Location = new System.Drawing.Point(200, 110);
            this.cipherData3_Lb.Name = "cipherData3_Lb";
            this.cipherData3_Lb.Size = new System.Drawing.Size(168, 17);
            this.cipherData3_Lb.TabIndex = 7;
            this.cipherData3_Lb.Text = "0x0000000000000000";
            // 
            // encode_Btn
            // 
            this.encode_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.encode_Btn.Location = new System.Drawing.Point(280, 144);
            this.encode_Btn.Name = "encode_Btn";
            this.encode_Btn.Size = new System.Drawing.Size(90, 30);
            this.encode_Btn.TabIndex = 8;
            this.encode_Btn.Text = "Encode";
            this.encode_Btn.UseVisualStyleBackColor = true;
            this.encode_Btn.Click += new System.EventHandler(this.encode_Btn_Click);
            // 
            // decode_Btn
            // 
            this.decode_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.decode_Btn.Location = new System.Drawing.Point(280, 324);
            this.decode_Btn.Name = "decode_Btn";
            this.decode_Btn.Size = new System.Drawing.Size(90, 30);
            this.decode_Btn.TabIndex = 17;
            this.decode_Btn.Text = "Decode";
            this.decode_Btn.UseVisualStyleBackColor = true;
            this.decode_Btn.Click += new System.EventHandler(this.decode_Btn_Click);
            // 
            // plainData3_Lb
            // 
            this.plainData3_Lb.AutoSize = true;
            this.plainData3_Lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.plainData3_Lb.Location = new System.Drawing.Point(200, 290);
            this.plainData3_Lb.Name = "plainData3_Lb";
            this.plainData3_Lb.Size = new System.Drawing.Size(168, 17);
            this.plainData3_Lb.TabIndex = 16;
            this.plainData3_Lb.Text = "0x0000000000000000";
            // 
            // plainData2_Lb
            // 
            this.plainData2_Lb.AutoSize = true;
            this.plainData2_Lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.plainData2_Lb.Location = new System.Drawing.Point(200, 257);
            this.plainData2_Lb.Name = "plainData2_Lb";
            this.plainData2_Lb.Size = new System.Drawing.Size(168, 17);
            this.plainData2_Lb.TabIndex = 15;
            this.plainData2_Lb.Text = "0x0000000000000000";
            // 
            // plainData1_Lb
            // 
            this.plainData1_Lb.AutoSize = true;
            this.plainData1_Lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.plainData1_Lb.Location = new System.Drawing.Point(200, 224);
            this.plainData1_Lb.Name = "plainData1_Lb";
            this.plainData1_Lb.Size = new System.Drawing.Size(168, 17);
            this.plainData1_Lb.TabIndex = 14;
            this.plainData1_Lb.Text = "0x0000000000000000";
            // 
            // plainDataHeader2_Lb
            // 
            this.plainDataHeader2_Lb.AutoSize = true;
            this.plainDataHeader2_Lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.plainDataHeader2_Lb.Location = new System.Drawing.Point(204, 189);
            this.plainDataHeader2_Lb.Name = "plainDataHeader2_Lb";
            this.plainDataHeader2_Lb.Size = new System.Drawing.Size(144, 20);
            this.plainDataHeader2_Lb.TabIndex = 13;
            this.plainDataHeader2_Lb.Text = "Plain Data [hex]";
            // 
            // cipherDataHeader2_Lb
            // 
            this.cipherDataHeader2_Lb.AutoSize = true;
            this.cipherDataHeader2_Lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cipherDataHeader2_Lb.Location = new System.Drawing.Point(20, 189);
            this.cipherDataHeader2_Lb.Name = "cipherDataHeader2_Lb";
            this.cipherDataHeader2_Lb.Size = new System.Drawing.Size(157, 20);
            this.cipherDataHeader2_Lb.TabIndex = 12;
            this.cipherDataHeader2_Lb.Text = "Cipher Data [hex]";
            // 
            // cipherData3_Txb
            // 
            this.cipherData3_Txb.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cipherData3_Txb.Location = new System.Drawing.Point(12, 287);
            this.cipherData3_Txb.Name = "cipherData3_Txb";
            this.cipherData3_Txb.Size = new System.Drawing.Size(165, 22);
            this.cipherData3_Txb.TabIndex = 11;
            this.cipherData3_Txb.Text = "0x0000000000000000";
            // 
            // cipherData2_Txb
            // 
            this.cipherData2_Txb.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cipherData2_Txb.Location = new System.Drawing.Point(12, 254);
            this.cipherData2_Txb.Name = "cipherData2_Txb";
            this.cipherData2_Txb.Size = new System.Drawing.Size(165, 22);
            this.cipherData2_Txb.TabIndex = 10;
            this.cipherData2_Txb.Text = "0x0000000000000000";
            // 
            // cipherData1_Txb
            // 
            this.cipherData1_Txb.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cipherData1_Txb.Location = new System.Drawing.Point(12, 221);
            this.cipherData1_Txb.Name = "cipherData1_Txb";
            this.cipherData1_Txb.Size = new System.Drawing.Size(165, 22);
            this.cipherData1_Txb.TabIndex = 9;
            this.cipherData1_Txb.Text = "0x0000000000000000";
            // 
            // key_Txb
            // 
            this.key_Txb.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.key_Txb.Location = new System.Drawing.Point(68, 386);
            this.key_Txb.Name = "key_Txb";
            this.key_Txb.Size = new System.Drawing.Size(165, 22);
            this.key_Txb.TabIndex = 18;
            this.key_Txb.Text = "0x133457799BBCDFF1";
            // 
            // iv_Txb
            // 
            this.iv_Txb.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.iv_Txb.Location = new System.Drawing.Point(68, 419);
            this.iv_Txb.Name = "iv_Txb";
            this.iv_Txb.Size = new System.Drawing.Size(165, 22);
            this.iv_Txb.TabIndex = 19;
            this.iv_Txb.Text = "0x133457799BBCDFF1";
            // 
            // key_Lb
            // 
            this.key_Lb.AutoSize = true;
            this.key_Lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.key_Lb.Location = new System.Drawing.Point(8, 386);
            this.key_Lb.Name = "key_Lb";
            this.key_Lb.Size = new System.Drawing.Size(44, 20);
            this.key_Lb.TabIndex = 20;
            this.key_Lb.Text = "KEY";
            // 
            // iv_Lb
            // 
            this.iv_Lb.AutoSize = true;
            this.iv_Lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.iv_Lb.Location = new System.Drawing.Point(8, 422);
            this.iv_Lb.Name = "iv_Lb";
            this.iv_Lb.Size = new System.Drawing.Size(26, 20);
            this.iv_Lb.TabIndex = 21;
            this.iv_Lb.Text = "IV";
            // 
            // desMode_Cmb
            // 
            this.desMode_Cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.desMode_Cmb.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.desMode_Cmb.FormattingEnabled = true;
            this.desMode_Cmb.Items.AddRange(new object[] {
            "ECB",
            "CBC"});
            this.desMode_Cmb.Location = new System.Drawing.Point(68, 452);
            this.desMode_Cmb.Name = "desMode_Cmb";
            this.desMode_Cmb.Size = new System.Drawing.Size(165, 24);
            this.desMode_Cmb.TabIndex = 22;
            // 
            // split1_Lb
            // 
            this.split1_Lb.AutoSize = true;
            this.split1_Lb.Location = new System.Drawing.Point(-9, 357);
            this.split1_Lb.Name = "split1_Lb";
            this.split1_Lb.Size = new System.Drawing.Size(392, 17);
            this.split1_Lb.TabIndex = 23;
            this.split1_Lb.Text = "________________________________________________";
            // 
            // mode_Lb
            // 
            this.mode_Lb.AutoSize = true;
            this.mode_Lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.mode_Lb.Location = new System.Drawing.Point(8, 455);
            this.mode_Lb.Name = "mode_Lb";
            this.mode_Lb.Size = new System.Drawing.Size(54, 20);
            this.mode_Lb.TabIndex = 24;
            this.mode_Lb.Text = "Mode";
            // 
            // lock_PctBx
            // 
            this.lock_PctBx.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lock_PctBx.BackgroundImage")));
            this.lock_PctBx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lock_PctBx.ErrorImage = null;
            this.lock_PctBx.InitialImage = null;
            this.lock_PctBx.Location = new System.Drawing.Point(261, 380);
            this.lock_PctBx.Name = "lock_PctBx";
            this.lock_PctBx.Size = new System.Drawing.Size(100, 100);
            this.lock_PctBx.TabIndex = 25;
            this.lock_PctBx.TabStop = false;
            // 
            // split2_Lb
            // 
            this.split2_Lb.AutoSize = true;
            this.split2_Lb.Location = new System.Drawing.Point(-9, 483);
            this.split2_Lb.Name = "split2_Lb";
            this.split2_Lb.Size = new System.Drawing.Size(392, 17);
            this.split2_Lb.TabIndex = 26;
            this.split2_Lb.Text = "________________________________________________";
            // 
            // sign_Lb
            // 
            this.sign_Lb.AutoSize = true;
            this.sign_Lb.Location = new System.Drawing.Point(55, 509);
            this.sign_Lb.Name = "sign_Lb";
            this.sign_Lb.Size = new System.Drawing.Size(260, 17);
            this.sign_Lb.TabIndex = 27;
            this.sign_Lb.Text = "@author Batuhan KINDAN - 14.12.2017";
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(382, 535);
            this.Controls.Add(this.sign_Lb);
            this.Controls.Add(this.split2_Lb);
            this.Controls.Add(this.lock_PctBx);
            this.Controls.Add(this.mode_Lb);
            this.Controls.Add(this.split1_Lb);
            this.Controls.Add(this.desMode_Cmb);
            this.Controls.Add(this.iv_Lb);
            this.Controls.Add(this.key_Lb);
            this.Controls.Add(this.iv_Txb);
            this.Controls.Add(this.key_Txb);
            this.Controls.Add(this.decode_Btn);
            this.Controls.Add(this.plainData3_Lb);
            this.Controls.Add(this.plainData2_Lb);
            this.Controls.Add(this.plainData1_Lb);
            this.Controls.Add(this.plainDataHeader2_Lb);
            this.Controls.Add(this.cipherDataHeader2_Lb);
            this.Controls.Add(this.cipherData3_Txb);
            this.Controls.Add(this.cipherData2_Txb);
            this.Controls.Add(this.cipherData1_Txb);
            this.Controls.Add(this.encode_Btn);
            this.Controls.Add(this.cipherData3_Lb);
            this.Controls.Add(this.cipherData2_Lb);
            this.Controls.Add(this.cipherData1_Lb);
            this.Controls.Add(this.cipherDataHeader1_Lb);
            this.Controls.Add(this.plainDataHeader1_Lb);
            this.Controls.Add(this.plainData3_Txb);
            this.Controls.Add(this.plainData2_Txb);
            this.Controls.Add(this.plainData1_Txb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main_Form";
            this.Text = "Data Encryption Standart - Test";
            ((System.ComponentModel.ISupportInitialize)(this.lock_PctBx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox plainData1_Txb;
        private System.Windows.Forms.TextBox plainData2_Txb;
        private System.Windows.Forms.TextBox plainData3_Txb;
        private System.Windows.Forms.Label plainDataHeader1_Lb;
        private System.Windows.Forms.Label cipherDataHeader1_Lb;
        private System.Windows.Forms.Label cipherData1_Lb;
        private System.Windows.Forms.Label cipherData2_Lb;
        private System.Windows.Forms.Label cipherData3_Lb;
        private System.Windows.Forms.Button encode_Btn;
        private System.Windows.Forms.Button decode_Btn;
        private System.Windows.Forms.Label plainData3_Lb;
        private System.Windows.Forms.Label plainData2_Lb;
        private System.Windows.Forms.Label plainData1_Lb;
        private System.Windows.Forms.Label plainDataHeader2_Lb;
        private System.Windows.Forms.Label cipherDataHeader2_Lb;
        private System.Windows.Forms.TextBox cipherData3_Txb;
        private System.Windows.Forms.TextBox cipherData2_Txb;
        private System.Windows.Forms.TextBox cipherData1_Txb;
        private System.Windows.Forms.TextBox key_Txb;
        private System.Windows.Forms.TextBox iv_Txb;
        private System.Windows.Forms.Label key_Lb;
        private System.Windows.Forms.Label iv_Lb;
        private System.Windows.Forms.ComboBox desMode_Cmb;
        private System.Windows.Forms.Label split1_Lb;
        private System.Windows.Forms.Label mode_Lb;
        private System.Windows.Forms.PictureBox lock_PctBx;
        private System.Windows.Forms.Label split2_Lb;
        private System.Windows.Forms.Label sign_Lb;
    }
}


/**
  ******************************************************************************
  * @file    Main_Form.cs
  * @author  Batuhan KINDAN
  * @version V1.0
  * @date    12 Aralik 2017
  * @brief   Program ana form dosyasi
  ******************************************************************************
  */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using DES_Module;

namespace DES_Desktop
{
    public partial class Main_Form : Form
    {

        /**
          * @brief  Form uygulamasi baslangic noktasi
          * @param  none
          * @retval none
          */
        public Main_Form()
        {
            InitializeComponent();
            desMode_Cmb.SelectedIndex = 0;
        }

        /**
          * @brief  Encode butonu tiklama olayinda isletilecek rutini tanimlayan fonksiyon
          * @param  sender
          * @param  e 
          * @retval none
          */
        private void encode_Btn_Click(object sender, EventArgs e)
        {
            /* click event fonksiyonunda kullanilacak degiskenler tanimlanip ilklendiriliyor */
            DES desTool = new DES();
            UInt64 bufferValue = 0;
            DES.DES_Mode_Enum cipherMode = DES.DES_Mode_Enum.Default;
            ulong[] plainData = new ulong[3];
            ulong[] cipherData = new ulong[3];
            string textBoxBuffer = "";

            /* plain data 1, 2 ve 3 uint64 tipine cevrilip diziye yerlestiriliyor */
            textBoxBuffer = plainData1_Txb.Text;
            textBoxBuffer = textBoxBuffer.Replace("0x", "");
            ulong.TryParse(textBoxBuffer, NumberStyles.HexNumber, null, out plainData[0]);

            textBoxBuffer = plainData2_Txb.Text;
            textBoxBuffer = textBoxBuffer.Replace("0x", "");
            ulong.TryParse(textBoxBuffer, NumberStyles.HexNumber, null, out plainData[1]);

            textBoxBuffer = plainData3_Txb.Text;
            textBoxBuffer = textBoxBuffer.Replace("0x", "");
            ulong.TryParse(textBoxBuffer, NumberStyles.HexNumber, null, out plainData[2]);

            /* DES anahtari ve baslangic vektoru (CBC modu icin) uint64'e cevrilip DES sinifina yukleniyor */
            textBoxBuffer = key_Txb.Text;
            textBoxBuffer = textBoxBuffer.Replace("0x", "");
            ulong.TryParse(textBoxBuffer, NumberStyles.HexNumber, null, out bufferValue);
            desTool.Set_Key(bufferValue);

            textBoxBuffer = iv_Txb.Text;
            textBoxBuffer = textBoxBuffer.Replace("0x", "");
            ulong.TryParse(textBoxBuffer, NumberStyles.HexNumber, null, out bufferValue);
            desTool.Set_IV(bufferValue);

            /* form penceresi uzerindeki combo box uzerinden DES sifreleme modu belirleniyor */
            if(desMode_Cmb.SelectedItem == "ECB")
            {
                cipherMode = DES.DES_Mode_Enum.ECB;
            }
            else if(desMode_Cmb.SelectedItem == "CBC")
            {
                cipherMode = DES.DES_Mode_Enum.CBC;
            }
            else
            {
                // bu satir bilerek bos birakildi
            }

            /* plain data sifrelenip cipherData dizisine yerlestiriliyor */
            cipherData = desTool.Encrypt_Data(plainData, cipherMode);

            /* sifrelenmis data form penceresindeki labellar ile gosteriliyor */
            cipherData1_Lb.Text = "0x" + cipherData[0].ToString("X16");
            cipherData2_Lb.Text = "0x" + cipherData[1].ToString("X16");
            cipherData3_Lb.Text = "0x" + cipherData[2].ToString("X16");

        }

        /**
          * @brief  Decode butonu tiklama olayinda isletilecek rutini tanimlayan fonksiyon
          * @param  sender
          * @param  e 
          * @retval none
          */
        private void decode_Btn_Click(object sender, EventArgs e)
        {

        }
    }
}

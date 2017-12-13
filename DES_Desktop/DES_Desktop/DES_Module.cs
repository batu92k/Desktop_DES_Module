/**
  ******************************************************************************
  * @file    DES_Module.cs
  * @author  Ali Batuhan KINDAN
  * @version V0.1
  * @date    12 Aralik 2017
  * @brief   Data Encryption Standart (DES) sinifinin global gedigkenleri, constructor,
  *          destructor ve kriptolama islem fonksiyonlari bu dosyada bulunur. 
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

namespace DES_Module
{

    public class DES
    {

        // DES - Permuted Choice 1 Matrix
        private byte[] PC_1 = {	57,   49,    41,   33,    25,    17,    9,
		                         1,   58,    50,   42,    34,    26,   18,
								10,    2,    59,   51,    43,    35,   27,
								19,   11,     3,   60,    52,    44,   36,
								63,   55,    47,   39,    31,    23,   15,
							     7,   62,    54,   46,    38,    30,   22,
								14,    6,    61,   53,    45,    37,   29,
								21,   13,     5,   28,    20,    12,    4	};

        // DES - Permuted Choice 2 Matrix
        private byte[] PC_2 = { 14,    17,   11,    24,     1,    5,
								 3,    28,   15,     6,    21,   10,
								23,    19,   12,     4,    26,    8,
								16,     7,   27,    20,    13,    2,
								41,    52,   31,    37,    47,   55,
								30,    40,   51,    45,    33,   48,
								44,    49,   39,    56,    34,   53,
								46,    42,   50,    36,    29,   32   };

        // DES - Initial Permutation Matrix
        private byte[] IP = {  58,    50,   42,   34,   26,   18,   10,   2,
							   60,    52,   44,   36,   28,   20,   12,   4,
							   62,    54,   46,   38,   30,   22,   14,   6,
							   64,    56,   48,   40,   32,   24,   16,   8,
							   57,    49,   41,   33,   25,   17,    9,   1,
							   59,    51,   43,   35,   27,   19,   11,   3,
							   61,    53,   45,   37,   29,   21,   13,   5,
							   63,    55,   47,   39,   31,   23,   15,   7  };

        // IP^-1 Permutation Matrix
        private byte[] IP_ = {  40,    8,   48,   16,   56,   24,   64,  32,
							    39,    7,   47,   15,   55,   23,   63,  31,
							    38,    6,   46,   14,   54,   22,   62,  30,
							    37,    5,   45,   13,   53,   21,   61,  29,
							    36,    4,   44,   12,   52,   20,   60,  28,
							    35,    3,   43,   11,   51,   19,   59,  27,
							    34,    2,   42,   10,   50,   18,   58,  26,
							    33,    1,   41,    9,   49,   17,   57,  25  };


        // DES - Calculated Keys 0-15 (Kn)
        private UInt64[] Sub_Keys;

        // 28 bits left part of subkeys
        private UInt32[] Cn;

        // 28 bits right part of subkeys
        private UInt32[] Dn;

        // DES - Bit Shift Table
        private byte[] Shift_Table = { 1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1 };

        // DES - E bit selection table
        private byte[] E_Bit_Selection_Table = { 32,     1,    2,     3,     4,    5,
											      4,     5,    6,     7,     8,    9,
												  8,     9,   10,    11,    12,   13,
											     12,    13,   14,    15,    16,   17,
											     16,    17,   18,    19,    20,   21,
											     20,    21,   22,    23,    24,   25,
											     24,    25,   26,    27,    28,   29,
											     28,    29,   30,    31,    32,    1 };

        // S-Box S-1 to S-8
        private byte[, ,] SBox =
        {
	        {
			        {  14,  4,  13,  1,   2, 15,  11,  8,   3,  10,   6,  12,  5,  9,  0,  7 },
			        {	0, 15,   7,  4,  14,  2,  13,  1,  10,   6,  12,  11,  9,  5,  3,  8 },
			        {	4,  1,  14,  8,  13,  6,   2, 11,  15,  12,   9,   7,  3, 10,  5,  0 },
			        {  15, 12,   8,  2,   4,  9,   1,  7,   5,  11,   3,  14, 10,  0,  6, 13 }
	        },

	        {
			        {  15,  1,   8, 14,   6, 11,   3,  4,   9,   7,   2,  13, 12,  0,  5, 10 },
			        {	3, 13,   4,  7,  15,  2,   8, 14,  12,   0,   1,  10,  6,  9, 11,  5 },
			        {	0, 14,   7, 11,  10,  4,  13,  1,   5,   8,  12,   6,  9,  3,  2, 15 },
			        {  13,  8,  10,  1,   3, 15,   4,  2,  11,   6,   7,  12,  0,  5, 14,  9 }
	        },

	        {
			        {  10,  0,   9, 14,   6,  3,  15,  5,   1,  13,  12,   7,  11,  4,  2,  8 },
			        {  13,  7,   0,  9,   3,  4,   6, 10,   2,   8,   5,  14,  12, 11, 15,  1 },
			        {  13,  6,   4,  9,   8, 15,   3,  0,  11,   1,   2,  12,   5, 10, 14,  7 },
			        {   1, 10,  13,  0,   6,  9,   8,  7,   4,  15,  14,   3,  11,  5,  2, 12 }

	        },

	        {
			        {   7, 13,  14,  3,   0,  6,   9, 10,   1,   2,   8,   5,  11, 12,  4, 15 },
			        {  13,  8,  11,  5,   6, 15,   0,  3,   4,   7,   2,  12,   1, 10, 14,  9 },
			        {  10,  6,   9,  0,  12, 11,   7, 13,  15,   1,   3,  14,   5,  2,  8,  4 },
			        {   3, 15,   0,  6,  10,  1,  13,  8,   9,   4,   5,  11,  12,  7,  2, 14 }
	        },

	        {
			        {   2, 12,   4,  1,   7, 10,  11,  6,   8,   5,   3,  15,  13,  0, 14,  9 },
			        {  14, 11,   2, 12,   4,  7,  13,  1,   5,   0,  15,  10,   3,  9,  8,  6 },
			        {   4,  2,   1, 11,  10, 13,   7,  8,  15,   9,  12,   5,   6,  3,  0, 14 },
			        {  11,  8,  12,  7,   1, 14,   2, 13,   6,  15,   0,   9,  10,  4,  5,  3 }
	        },

	        {
			        {  12,  1,  10, 15,   9,  2,   6,  8,   0,  13,   3,   4,  14,  7,  5, 11 },
			        {  10, 15,   4,  2,   7, 12,   9,  5,   6,   1,  13,  14,   0, 11,  3,  8 },
			        {   9, 14,  15,  5,   2,  8,  12,  3,   7,   0,   4,  10,   1, 13, 11,  6 },
			        {   4,  3,   2, 12,   9,  5,  15, 10,  11,  14,   1,   7,   6,  0,  8, 13 }
	        },

	        {
			        {   4, 11,   2, 14,  15,  0,   8, 13,   3,  12,   9,   7,   5, 10,  6,  1 },
			        {  13,  0,  11,  7,   4,  9,   1, 10,  14,   3,   5,  12,   2, 15,  8,  6 },
			        {   1,  4,  11, 13,  12,  3,   7, 14,  10,  15,   6,   8,   0,  5,  9,  2 },
			        {   6, 11,  13,  8,   1,  4,  10,  7,   9,   5,   0,  15,  14,  2,  3, 12 }
	        },

	        {
			        {   13,  2,   8,  4,   6, 15,  11,  1,  10,   9,   3,  14,   5,  0, 12,  7 },
			        {    1, 15,  13,  8,  10,  3,   7,  4,  12,   5,   6,  11,   0, 14,  9,  2 },
			        {    7, 11,   4,  1,   9, 12,  14,  2,   0,   6,  10,  13,  15,  3,  5,  8 },
			        {    2,  1,  14,  7,   4, 10,   8, 13,  15,  12,   9,   0,   3,  5,  6, 11 }
	        }

        };

        // The Permutation Matrix
        private byte[] P = {  16,   7,  20,  21,
							  29,  12,  28,  17,
							   1,  15,  23,  26,
							   5,  18,  31,  10,
							   2,   8,  24,  14,
							  32,  27,   3,   9,
							  19,  13,  30,   6,
							  22,  11,   4,  25  };

        /* DES sifreleme modlarini tanimlamak uzere enum degiskeni 
         * ECB - Electronic Code Book
         * CBC - Cipher Block Chaining */
        public enum DES_Mode_Enum { Default, ECB, CBC };

        /* DES sifreleme modu degiskeni */
        public DES_Mode_Enum cipherMode;

        // Initialization Vector
        private UInt64 IV;

        // DES cipher key
        private UInt64 KEY;

        /**
          * @brief  DES (Data Encryption Standart) sinif constructor fonksiyonu
          * @param  none
          * @retval none
          */
        public DES()
        {
            /* sinif global degiskenlerinin ilklendirilmesi */
            Sub_Keys = new UInt64[16];
            Cn = new UInt32[17];
            Dn = new UInt32[17];
            cipherMode = DES_Mode_Enum.Default;
            IV = 0x0000000000000000;
            KEY = 0x0000000000000000;
        }


        /**
          * @brief  DES (Data Encryption Standart) sinif destructor fonksiyonu
          * @param  none
          * @retval none
          */
        ~DES()
        {

        }

        /**
          * @brief  DES (Data Encryption Standart) anahtar degiskeni bu fonksiyon ile belirlenir
          * @param  value
          * @retval none
          */
        public void Set_Key(UInt64 value)
        {
            KEY = value;
        }

        /**
          * @brief  Bu fonkaiyon; DES (Data Encryption Standart) anahtar degiskenini geri dondurur
          * @param  none
          * @retval KEY
          */
        public UInt64 Get_Key()
        {
            return KEY;
        }

        /**
          * @brief  DES (Data Encryption Standart) IV (initialization vector) degiskeni bu fonksiyon ile belirlenir
          * @param  value
          * @retval none
          */
        public void Set_IV(UInt64 value)
        {
            IV = value;
        }

        /**
          * @brief  Bu fonkaiyon; DES (Data Encryption Standart) IV (initialization vector) degiskenini geri dondurur
          * @param  none
          * @retval IV
          */
        public UInt64 Get_IV()
        {
            return IV;
        }

        /**
          * @brief  Bu fonksiyon; parametre olarak verilen DES anahtarini kullanarak DES sifreleme ve sifre cozme
          *         isleminde kullanilacak alt anahtarlari uretir ve Sub_Keys global dizisine yerlestirir 
          * @param  key
          * @retval none
          */
        public void Get_Subkeys(UInt64 key = 0x0000000000000000)
        {
            UInt64 permutedKey = 0x0000000000000000;        // orjinal DES anahtarinin PC_1 permutasyonu K+
            UInt64 bitShift_Buffer = 0x0000000000000000;    // bit kaydirma degiskeni
            UInt64 cnBuffer = 0x0000000000000000;           // permute edilmis anahtarin (K+) sol kismi
            UInt64 dnBuffer = 0x0000000000000000;           // permute edilmis anahtarin (K+) sag kismi
            UInt64 preSubKey = 0x0000000000000000;          // permute edilmemis alt anahtar tutucusu
            byte i = 0;                                     // genel maksat sayac
            byte j = 0;                                     // genel maksat sayac

            /* alt anahtar dizisini temizle */
            for(i = 0; i < 16; i++)
            {
                Sub_Keys[i] = 0x0000000000000000;
            }

            /* DES anahtari K'nin PC_1 matrisi ile permute edilerek K+ permute edilmis anahtarin bulunmasi */
            for (i = 0; i < 56; i++)
            {
                /* PC_1 matrisinin anahtar uzerinde adresledigi bit degeri bulunarak sira ile permute 
                 * edilmis anahtar degiskenine ekleniyor */
                bitShift_Buffer = 0x8000000000000000;
                bitShift_Buffer = (bitShift_Buffer >> (PC_1[i] - 1));
                bitShift_Buffer = bitShift_Buffer & (key);
                bitShift_Buffer = (bitShift_Buffer << (PC_1[i] - 1));
                bitShift_Buffer = (bitShift_Buffer >> i);

                permutedKey = (permutedKey | bitShift_Buffer);																		
            }

            /* bit kaydirma islemi icin baslangic degerleri olan, alt anahtarlarin 0 numarali 
             * sol ve sag parcalarinin elde edilmesi */
            Cn[0] = (UInt32)((0xFFFFFFF000000000 & permutedKey) >> 32);
            Dn[0] = (UInt32)((0x0000000FFFFFFF00 & permutedKey) >> 4);

            /* permutasyon oncesi alt anahtar parcalarinin hesaplanmasi */
            for (i = 0; i < 16; i++)
            {
                /* her bir alt anahtar parcasi bir onceki parcanin bit kaydirma tablosuna gore
                   dairesel bit kaydirmasiyla hesaplaniyor */
                Cn[i + 1] = DES_Subkey_BitShifter(Cn[i], Shift_Table[i]);
                Dn[i + 1] = DES_Subkey_BitShifter(Dn[i], Shift_Table[i]);
            }

            /* 16 adet alt anahtar hesaplaniyor */
            for(i = 0; i < 16; i++)
            {
                cnBuffer = Cn[i + 1];
                cnBuffer = (cnBuffer << 32);
                dnBuffer = Dn[i + 1];
                dnBuffer = (dnBuffer << 4);
                preSubKey = (cnBuffer | dnBuffer);

                /* ilgili alt anahtar PC_2 matrisi ile permute edilerek son halini aliyor */
                for(j = 0; j < 48; j++)
                {
                    bitShift_Buffer = 0x8000000000000000;
                    bitShift_Buffer = (bitShift_Buffer >> (PC_2[j] - 1));
                    bitShift_Buffer = bitShift_Buffer & (preSubKey);
                    bitShift_Buffer = (bitShift_Buffer << (PC_2[j] - 1));
                    bitShift_Buffer = (bitShift_Buffer >> j);

                    Sub_Keys[i] = (Sub_Keys[i] | bitShift_Buffer);
                }

            }
																

        }

        /**
          * @brief  Bu fonksiyon; DES hesaplama rutini sirasinda kullanilan 
          *         dairesel sola kaydirma islemini gerceklestirir
          * @param  value
          * @param  shiftValue
          * @retval buffer
          */
        UInt32 DES_Subkey_BitShifter(UInt32 value, byte shiftValue)
        {
            UInt32 buffer = 0x00000000;

            buffer = (value << shiftValue) | ((value >> (32 - shiftValue)) << 4);

            return buffer;
        }

      /**
        * @brief  Bu fonksiyon 64 bitlik bir blok veriyi sifreler
        * @param  plainData
        * @retval encodedData
        */
        UInt64 Encode_BlockData(UInt64 plainData)
        {
            UInt64 encodedData = 0x0000000000000000;
            UInt64 bitShift_Buffer = 0x0000000000000000;
            UInt64 permutedData = 0x0000000000000000;
            UInt64 pre_PermutedData = 0x0000000000000000;
            UInt64 ln = 0x00000000;
            UInt64 ln_Old = 0x00000000;
            UInt64 rn = 0x00000000;
            UInt64 rn_Old = 0x00000000;
            byte i = 0;

            /* IP (Initial Permutation) matrisi ile mesaj (M) verisinin ilk permutasyon islemi yapililarak
             * permute edilmis mesaj (M+) elde ediliyor */
            for (i = 0; i < 64; i++)
            {
                bitShift_Buffer = 0x8000000000000000;
                bitShift_Buffer = (bitShift_Buffer >> (IP[i] - 1));
                bitShift_Buffer = bitShift_Buffer & (plainData);
                bitShift_Buffer = (bitShift_Buffer << (IP[i] - 1));
                bitShift_Buffer = (bitShift_Buffer >> i);

                encodedData = (encodedData | bitShift_Buffer);
            }

            /* permute edilmis mesajin 32 bitlik sag ve sol parcalara ayrilmasi */
            ln_Old = (0xFFFFFFFF00000000 & encodedData) >> 32;												
            rn_Old = (0x00000000FFFFFFFF & encodedData);

            /* permute edilmis ve parcalara ayrilmis mesaj verisinin 16 kez F fonksiyonu yardimi ile
             * yer degistirerek sifreleme rutini iterasyonunun yapilmasi */
            for (i = 0; i < 16; i++)
            {
                ln = rn_Old;
                //rn = ln_Old ^ F_Function

                rn_Old = rn;
                ln_Old = ln;
            }

            return encodedData;
        }


      /**
        * @brief  DES (Data Encryption Standart) F fonksiyonu rutini
        * @param  input
        * @param  iterationNumber
        * @retval result
        */
        UInt32 F_Function(UInt32 input, byte iterationNumber)
        {
            UInt32 result = 0x00000000;
            UInt32 resultBuffer = 0x00000000;
            UInt32 bitShift_Buffer32 = 0x00000000;
            UInt64 expandedInput = 0x0000000000000000;
            UInt64 inputBuffer = 0x0000000000000000;
            UInt64 bitShift_Buffer = 0x0000000000000000;
            UInt64 B_Buffer = 0x0000000000000000;
            byte i = 0;
            byte S_Row = 0;
            byte S_Column = 0;

            /* 32 bitlik giris verisinin E-bit secim tablosu yardimi ile 48 bite genisletilmesi */
            for (i = 0; i < 48; i++)
            {
                bitShift_Buffer = 0x8000000000000000;
                inputBuffer = input;
                inputBuffer = (inputBuffer << 32);
                bitShift_Buffer = (bitShift_Buffer >> (E_Bit_Selection_Table[i] - 1));
                bitShift_Buffer = (bitShift_Buffer & inputBuffer);
                bitShift_Buffer = (bitShift_Buffer << (E_Bit_Selection_Table[i] - 1));
                bitShift_Buffer = (bitShift_Buffer >> i);

                expandedInput = (expandedInput | bitShift_Buffer);
            } 

            /* genisletilen verinin iterasyon numarasina gore ilgili alt anahtar ile XOR'lanmasi */
            expandedInput = (expandedInput ^ Sub_Keys[iterationNumber]);


            return result;
        }


    }

}
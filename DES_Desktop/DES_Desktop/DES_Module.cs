/**
  ******************************************************************************
  * @file    DES_Module.cs
  * @author  Batuhan KINDAN
  * @version V1.0
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
          * @brief  Bu fonksiyon; istenilen bir DES (Data Encryption Standart) modunda, kendisine verilen
          *         veri dizisini sifreler ve sifrelenmis dizi olarak geri dondurur.  
          * @param  plainData
          * @param  cipherMode
          * @retval cipherData
          */
        public UInt64[] Encrypt_Data(UInt64[] plainData, DES_Mode_Enum cipherMode)
        {
            UInt64[] cipherData = new UInt64[plainData.Length];
            UInt64 chainBuffer = 0x0000000000000000;
            UInt16 i = 0;

            switch(cipherMode)
            {

                    /* DES - CBC (Cipher Block Chaining) sifreleme rutini */
                case DES_Mode_Enum.CBC:

			        Get_Subkeys();

                    /* acik verinin ilk elemani IV (Initialization Vector) ile XOR'landiktan sonra sifreleniyor */
			        chainBuffer = (IV ^ plainData[0]);
			        cipherData[0] = Encode_BlockData(chainBuffer);

                    /* IV ile ilk veri elemaninin sifrelenmesinin ardindan her bir sifrelenmis veri bir sonraki
                     * verinin sifrelenmesinde rol oynuyor. Boylece sifre blok zinciri olusturulmus oluyor */
                    for (i = 1; i < plainData.Length; i++)
			        {
				        chainBuffer = (cipherData[i-1] ^ plainData[i]);

				        cipherData[i] = Encode_BlockData(chainBuffer);
			        }

                    break;

                    /* DES - ECB (Electronic Code Book) sifreleme rutini */
                case DES_Mode_Enum.ECB:
     
                    Get_Subkeys();

                    /* acik veri tek tek sifrelenerek sifrelenmis veri dizisine aktariliyor */
                    for (i = 0; i < plainData.Length; i++)
                    {
                        cipherData[i] = Encode_BlockData(plainData[i]);
                    }

                    break;

                default:
                        // bu satir bilerek bos birakildi
                    break;
            }

            return cipherData;
        }

        /**
          * @brief  Bu fonksiyon; istenilen bir DES (Data Encryption Standart) modunda, kendisine verilen
          *         sifrelenmis veriyi cozerek geri dondurur. 
          * @param  cipherData
          * @param  cipherMode
          * @retval plainData
          */
        public UInt64[] Decrypt_Data(UInt64[] cipherData, DES_Mode_Enum cipherMode)
        {
            UInt64[] plainData = new UInt64[cipherData.Length];
            UInt64 chainBuffer = 0x0000000000000000;
            UInt16 i = 0;

            switch(cipherMode)
            {
                    /* DES - CBC (Cipher Block Chaining) sifre cozme rutini */
                case DES_Mode_Enum.CBC:

                    Get_Subkeys();

                    /* sifreli verinin ilk elemaninin sifresi cozulup IV (Initialization Vector) ile XOR'laniyor */
                    chainBuffer = Decode_BlockData(cipherData[0]);
                    plainData[0] = (chainBuffer ^ IV);

                    /* her bir datanin sirayla sifresi cozulup bir onceki veri ile XOR islemine tabi tutuluyor */
                    for (i = 1; i < cipherData.Length; i++)
                    {
                        chainBuffer = Decode_BlockData(cipherData[i]);

                        plainData[i] = (chainBuffer ^ cipherData[i - 1]);
                    }

                    break;

                    /* DES - ECB (Electronic Code Book) sifre cozme rutini */
                case DES_Mode_Enum.ECB:

                    Get_Subkeys();

                    /* sifrelenmis veri tek tek cozulerek acik veri dizisine aktariliyor */
                    for (i = 0; i < cipherData.Length; i++)
                    {
                        plainData[i] = Decode_BlockData(cipherData[i]);
                    }

                    break;

                default:

                    break;

            }

            return plainData;
        }

        /**
          * @brief  Bu fonksiyon; parametre olarak verilen DES anahtarini kullanarak DES sifreleme ve sifre cozme
          *         isleminde kullanilacak alt anahtarlari uretir ve Sub_Keys global dizisine yerlestirir 
          * @param  none
          * @retval none
          */
        private void Get_Subkeys()
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
                bitShift_Buffer = bitShift_Buffer & (KEY);
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
        private UInt32 DES_Subkey_BitShifter(UInt32 value, byte shiftValue)
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
        private UInt64 Encode_BlockData(UInt64 plainData)
        {
            UInt64 encodedData = 0x0000000000000000;            // geri dondurulecek sifre blok metin degiskeni
            UInt64 bitShift_Buffer = 0x0000000000000000;        // bit kaydirma islemi icin tutucu degisken
            UInt64 permutedData = 0x0000000000000000;           // permutasyon islemine tabi tutulacak veri icin tutucu degisken
            UInt64 pre_PermutedData = 0x0000000000000000;       // permutasyon oncesi islemler icin veri tutucu degiskeni
            UInt32 ln = 0x00000000;                             // mesajin ilgili iterasyona air 32 bitlik sol parcasi
            UInt32 ln_Old = 0x00000000;                         // mesajin ilgili iterasyondan bir onceki duruma ait 32 bitlik sol parcasi
            UInt32 rn = 0x00000000;                             // mesajin ilgili iterasyona air 32 bitlik sag parcasi
            UInt32 rn_Old = 0x00000000;                         // mesajin ilgili iterasyondan bir onceki duruma ait 32 bitlik sag parcasi
            byte i = 0;                                         // genel maksat sayac

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
            ln_Old = (UInt32)((0xFFFFFFFF00000000 & encodedData) >> 32);												
            rn_Old = (UInt32)(0x00000000FFFFFFFF & encodedData);

            /* permute edilmis ve parcalara ayrilmis mesaj verisinin 16 kez F fonksiyonu yardimi ile
             * yer degistirerek sifreleme rutini iterasyonunun yapilmasi */
            for (i = 0; i < 16; i++)
            {
                ln = rn_Old;
                rn = ln_Old ^ F_Function(rn_Old, i);

                rn_Old = rn;
                ln_Old = ln;
            }

            /* R16 ve L16 parcalari birlestirilerek permutasyon oncesi sifrelenmis data elde ediliyor */
            pre_PermutedData = rn_Old;
            pre_PermutedData = (pre_PermutedData << 32);
            pre_PermutedData = (pre_PermutedData | ln_Old);

            /* IP^-1 matrisi ile sifrelenecek dataya son permutasyon islemi de uygulaniyor */
            for (i = 0; i < 64; i++)
            {
                bitShift_Buffer = 0x8000000000000000;
                bitShift_Buffer = (bitShift_Buffer >> (IP_[i] - 1));
                bitShift_Buffer = bitShift_Buffer & (pre_PermutedData);
                bitShift_Buffer = (bitShift_Buffer << (IP_[i] - 1));
                bitShift_Buffer = (bitShift_Buffer >> i);

                permutedData = (permutedData | bitShift_Buffer);
            }

            encodedData = permutedData;	

            return encodedData;
        }


        /**
          * @brief  Bu fonksiyon 64 bitlik sifrelenmis bir blok datanin sifresini cozer
          * @param  cipherData
          * @retval decodedData
          */
        private UInt64 Decode_BlockData(UInt64 cipherData)
        {
            UInt64 decodedData = 0x0000000000000000;            // geri dondurulecek sifre blok metin degiskeni
            UInt64 bitShift_Buffer = 0x0000000000000000;        // bit kaydirma islemi icin tutucu degisken
            UInt64 permutedData = 0x0000000000000000;           // permutasyon islemine tabi tutulacak veri icin tutucu degisken
            UInt64 pre_PermutedData = 0x0000000000000000;       // permutasyon oncesi islemler icin veri tutucu degiskeni
            UInt32 ln = 0x00000000;                             // mesajin ilgili iterasyona air 32 bitlik sol parcasi
            UInt32 ln_Old = 0x00000000;                         // mesajin ilgili iterasyondan bir onceki duruma ait 32 bitlik sol parcasi
            UInt32 rn = 0x00000000;                             // mesajin ilgili iterasyona air 32 bitlik sag parcasi
            UInt32 rn_Old = 0x00000000;                         // mesajin ilgili iterasyondan bir onceki duruma ait 32 bitlik sag parcasi
            byte i = 0;                                         // genel maksat sayac


            /* IP (Initial Permutation) matrisi ile mesaj (M) verisinin ilk permutasyon islemi yapililarak
             * permute edilmis mesaj (M+) elde ediliyor */
            for (i = 0; i < 64; i++)
            {
                bitShift_Buffer = 0x8000000000000000;
                bitShift_Buffer = (bitShift_Buffer >> (IP[i] - 1));
                bitShift_Buffer = bitShift_Buffer & (cipherData);
                bitShift_Buffer = (bitShift_Buffer << (IP[i] - 1));
                bitShift_Buffer = (bitShift_Buffer >> i);

                decodedData = (decodedData | bitShift_Buffer);
            }


            /* permute edilmis mesajin 32 bitlik sag ve sol parcalara ayrilmasi */
            ln_Old = (UInt32)((0xFFFFFFFF00000000 & decodedData) >> 32);
            rn_Old = (UInt32)(0x00000000FFFFFFFF & decodedData);

            /* permute edilmis ve parcalara ayrilmis mesaj verisinin 16 kez F fonksiyonu yardimi ile
             * yer degistirerek sifreleme rutininin aynisi olan sifre cozme iterasyonunun yapilmasi */
            for (i = 0; i < 16; i++)
            {
                ln = rn_Old;
                rn = ln_Old ^ F_Function(rn_Old, (byte)(15 - i));

                rn_Old = rn;
                ln_Old = ln;
            }

            /* R16 ve L16 parcalari birlestirilerek permutasyon oncesi data elde ediliyor */
            pre_PermutedData = rn_Old;
            pre_PermutedData = (pre_PermutedData << 32);
            pre_PermutedData = (pre_PermutedData | ln_Old);

            /* IP^-1 matrisi ile sifresi cozulecek dataya son permutasyon islemi de uygulaniyor */
            for (i = 0; i < 64; i++)
            {
                bitShift_Buffer = 0x8000000000000000;
                bitShift_Buffer = (bitShift_Buffer >> (IP_[i] - 1));
                bitShift_Buffer = bitShift_Buffer & (pre_PermutedData);
                bitShift_Buffer = (bitShift_Buffer << (IP_[i] - 1));
                bitShift_Buffer = (bitShift_Buffer >> i);

                permutedData = (permutedData | bitShift_Buffer);
            }

            decodedData = permutedData;

            return decodedData;
        }


      /**
        * @brief  DES (Data Encryption Standart) F fonksiyonu rutini
        * @param  input
        * @param  iterationNumber
        * @retval result
        */
        private UInt32 F_Function(UInt32 input, byte iterationNumber)
        {
            UInt32 result = 0x00000000;                         // geri dondurulecek fonksiyon cikis degeri
            UInt32 resultBuffer = 0x00000000;                   // cikis degeri ustunde yapilacak islemler icin tutucu degisken
            UInt32 bitShift_Buffer32 = 0x00000000;              // 32 bitlik datalar icin bit kaydirma tutucu degiskeni
            UInt64 expandedInput = 0x0000000000000000;          // 48 bite genisletilmis veri icin tutucu degisken
            UInt64 inputBuffer = 0x0000000000000000;            // giris verisi uzerindeki islemler icin tutucu degisken
            UInt64 bitShift_Buffer = 0x0000000000000000;        // bit kaydirma icin tutucu degisken
            UInt64 B_Buffer = 0x0000000000000000;               // 6 bitlik B verisi icin tutucu degisken

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

	        /* 48 bitlik genisletilmis veriden 8 adet 6 bitlik B degeri elde edilmesi ve bu B verileri ile
             * S-Box'lar kullanilarak 8 adet 6 bitlik verinin 4 bite dusurulup 8x4 = 32 bitlik
             * permutasyon oncesi F fonksiyon ciktisinin elde edilmesi */
            for (i = 0; i < 8; i++)
            {
                B_Buffer = 0xFC;    // 0b11111100
                B_Buffer = (B_Buffer << 56);
                B_Buffer = (B_Buffer >> (i * 6));
                B_Buffer = ((expandedInput & B_Buffer) >> (56 - (i * 6)));

                /* S-Box sutun adresi 6 bitlik B verisinin ilk ve son bitine bakilarak
                 * adresleniyor */
                switch (B_Buffer & 0x84) // 0b10000100
                {
                    case 0x00: // 0b00000000
                        S_Row = 0;
                        break;

                    case 0x04: // 0b00000100
                        S_Row = 1;
                        break;

                    case 0x80: // 0b10000000
                        S_Row = 2;
                        break;

                    case 0x84: // 0b10000100
                        S_Row = 3;
                        break;

                    default:
                        // bu hat bilerek bos birakildi
                        break;
                }

                /* ilgili 6 bitlik B datasinin ortadaki 4 biti ile de S-Box dizisinin
                 * kolon adresi elde ediliyor */
                S_Column = (byte)((B_Buffer & 0x78) >> 3); // 0b01111000

                /* ilgili dongu iterasyonuna ait S kutusunda adreslenen veri bulunarak 32 bitlik cikis
                 * tutucu degiskeni uzerinde ilgili noktaya kaydiriliyor ve cikis verisine ekleniyor*/
                resultBuffer = SBox[i,S_Row,S_Column];
                resultBuffer = (resultBuffer << (28 - (4 * i)));

                result = (result | resultBuffer);
            }

            /* cikis verisinin permute edilmek uzere tutucu degiskene atilmasi */
            resultBuffer = result;
            result = 0x00000000;

            /* P matrisi ile yapilan son permutasyon isleminin ardindan F fonksiyon ciktisinin elde edilmesi */
            for (i = 0; i < 32; i++)
            {
                bitShift_Buffer32 = 0x80000000;
                bitShift_Buffer32 = (bitShift_Buffer32 >> (P[i] - 1));
                bitShift_Buffer32 = (bitShift_Buffer32 & resultBuffer);
                bitShift_Buffer32 = (bitShift_Buffer32 << (P[i] - 1));
                bitShift_Buffer32 = (bitShift_Buffer32 >> i);

                result = (result | bitShift_Buffer32);
            }

            return result;
        }


    }

}
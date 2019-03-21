using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICM_Drawer.Drawing
{
    public class BufferProcessing
    {
        static byte[] bmpHeader = new byte[62]{
  0x42,0x4D,0x3E,0x08,0x00,0x00,0x00,0x00,0x00,0x00,0x3E,0x00,0x00,0x00,0x28,0x00,
  0x00,0x00,0x00,0x01,0x00,0x00,0x40,0x00,0x00,0x00,0x01,0x00,0x01,0x00,0x00,0x00,
  0x00,0x00,0x00,0x08,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0xFF,0xFF,0x00
};

        const int bmpHeaderOffset = 61;
        public void insertLetterLegacy(int insCol, int insRow, byte[] lett,ref byte[]data)
        {
            int row = 0;
            int pixel = 0;
            for (int i = data.Length - 1; i > bmpHeaderOffset; i--)
            {
                //byte currentb = data[i];
                for (int j = 0; j < 8; j++) //8 bits in a byte
                {
                    int pixelX = pixel % 256; //So we get X position by modulating the pixel count with 256 (256px wide)
                    pixelX = (256 - (pixelX + 1));

                    if ((row >= insRow && row <= (insRow + 5)) && (pixelX >= insCol && pixelX <= (insCol + 7))) //At least the starting position
                    {
                        Set(ref data[i], j, Get(lett[row - insRow], 7-(pixelX - insCol)));

                    }

                    pixel++;
                    if (pixel % 256 == 0)
                    {
                        //move to next row
                        row++;
                    }
                }
            }
        }

        public void insertLetter(int insCol, int insRow, byte[] lett, ref byte[] data)
        {
            int pos = 0;
            int byteIndex = 0;
            int bitIndex = 0;
            for (int i = 0; i < lett.Length; i++) //Each row in the letter, should use lett.lenght later on
            {
                for (int j = 0; j < 8; j++) //8 bits in a byte
                {
                    pos = (((64 - ((insRow + i)) +1) * 256) + (((insCol) - j) -1));
                    byteIndex = ((int)(pos / 8f));
                    bitIndex = (pos - (byteIndex * 8));
                    if (j > 0 || bitIndex > 0)
                        bitIndex = 7 - bitIndex;
                    Set(ref data[byteIndex], bitIndex, Get(lett[i], j));
                }

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="insCol">Column postion for top left corner</param>
        /// <param name="insRow">Row position for top left corner</param>
        /// <param name="width">Pixel width</param>
        /// <param name="height">Pixel height</param>
        /// <param name="input">Buffer to write</param>
        /// <param name="data">Buffer to write it to</param>
        public void insertBuffer(int insCol, int insRow, int width, int height, byte[] input, ref byte[] data) {
            int pos = 0;
            int byteIndex = 0;
            int bitIndex = 0;
            int increments = ((width -1) / 8) + 1;
            for (int i = input.Length -1 ; i > 0; i-= increments) //Each row in the letter, should use lett.lenght later on
            {
                int byteOffset = 0;
                for (int j = 0; j < width; j++) //8 bits in a byte
                {
                    if (j % 8 == 0)
                        byteOffset = j / 8;

                    pos = (((64 - ((insRow + (i / increments))) + 1) * 256) + (((insCol + (width - 8)) - j) - 1));
                    byteIndex = ((int)(pos / 8f));
                    int InaccPos = byteIndex * 8;
                    bitIndex = (pos - InaccPos);
                    if (j > 0 || bitIndex > 0)
                        bitIndex = 7 - bitIndex;

                    int readBit = j - (byteOffset * 8);
                    Set(ref data[byteIndex], bitIndex, Get(input[i - byteOffset], readBit));
                }

            }
        }

        public static byte[] signalDataBuild(byte[] newDataIsr)
        {
            const int PIXEL_DATA_SIZE_2048 = 2048;
            const int PIXEL_DATA_SIZE_2096 = 2096;
            const int COLUMN_SIZE_8 = 8;
            const int COLUMNS = 256;
            const int ROWS = 64;
            byte[] bmpData = new byte[PIXEL_DATA_SIZE_2096];
            int i = 0;
            int j = 0;

            int byteIndex = 0;
            int bitIndex = 0;
            if (bmpData.Length > 2048)
            {
                reverseOldIcm(ref newDataIsr);
            } 

            int rowOffset = 0;
            for (i = 0; i < PIXEL_DATA_SIZE_2048; i++)
            {
                int thisCol = (i % COLUMNS);

                for (j = 0; j < COLUMN_SIZE_8; j++)
                {
                    int thisRow = ((ROWS -1) - rowOffset) - j;
                    int pixel = ((COLUMNS * thisRow) + thisCol); //Basically..
                    byteIndex = ((int)(pixel / (float)COLUMN_SIZE_8));
                    bitIndex = (pixel - (byteIndex * COLUMN_SIZE_8));
                    bitIndex = 7 - bitIndex;
                    //byte calByte = (byte)(newDataIsr[byteIndex] & (0x80 >> bitIndex));
                    Set(ref bmpData[i], j, Get(newDataIsr[byteIndex], bitIndex));
                    //bmpData[i] |= calByte;
     
                }
                if (thisCol == 0 && i > 0)
                    rowOffset += 8;
            }




            if (bmpData.Length > 2048)
            {
                for (i = PIXEL_DATA_SIZE_2096 - 1; i > -1; i--)
                {
                    if ((i % 128) == 0)
                    {
                        for (j = (PIXEL_DATA_SIZE_2096 - i - 3) - 1; j > -1; j--)
                        {
                            bmpData[i + j + 3] = bmpData[i + j];
                        }
                    }
                }
            }

            return bmpData;
        }

        public static byte[] bmpDataBuild(byte[] newDataIsr)
        {

            const int PIXEL_DATA_SIZE_2048 = 2048;
            const int PIXEL_DATA_SIZE_2096 = 2096;

            const int NB_COLUMNS_32 = 32;
            const int COLUMN_SIZE_8 = 8;
            byte[] bmpData = new byte[PIXEL_DATA_SIZE_2048];
            int i = 0;
            int j = 0;
            int k = 0;
            int pixelStart = 0;
            int pixelXOffset = 0;
            int pixelYOffset = 0;
            byte tmp = 0x00;

            for (i = 0; i < PIXEL_DATA_SIZE_2048; i++)
            {
                bmpData[i] = 0;
            }

            if (newDataIsr.Length > 2048)
            {
                for (i = 0; i < PIXEL_DATA_SIZE_2096; i++)
                {
                    if ((i % 128) == 0)
                    {
                        for (j = 0; j < (PIXEL_DATA_SIZE_2096 - i -3); j++)
                        {
                            newDataIsr[i + j] = newDataIsr[i + j + 3];
                        }
                    }
                }
            }

            pixelStart += (PIXEL_DATA_SIZE_2048 - (NB_COLUMNS_32 * COLUMN_SIZE_8));
            for (i = 0; i < PIXEL_DATA_SIZE_2048; i++)
            {
                for (j = 0; j < COLUMN_SIZE_8; j++)
                {
                    byte calByte = newDataIsr[pixelStart + pixelXOffset];
                    
                    if (calByte != 0x00)
                        j = j; //Just for breaking points

                    calByte = (byte)(calByte & (0x80 >> pixelYOffset));

                    calByte = (byte)(calByte >> ((COLUMN_SIZE_8 - 1) - pixelYOffset));

                    calByte = (byte)(calByte << ((COLUMN_SIZE_8 - 1) - j));

                    bmpData[i] |= calByte;

                    //bmpData[i] |= (byte)(((newDataIsr[pixelStart + pixelXOffset] & (0x80 >> pixelYOffset)) >> ((COLUMN_SIZE_8 - 1) - pixelYOffset)) << ((COLUMN_SIZE_8 - 1) - j));

                    pixelXOffset++;
                    if (pixelXOffset >= (NB_COLUMNS_32 * COLUMN_SIZE_8))
                    {
                        pixelXOffset = 0;
                        pixelYOffset++;
                        if (pixelYOffset >= COLUMN_SIZE_8)
                        {
                            pixelYOffset = 0;
                            pixelStart -= (NB_COLUMNS_32 * COLUMN_SIZE_8);
                        }
                    }
                }
            }

            if (newDataIsr.Length > 2048)
            {
                fixOldIcm(ref bmpData);
            }
            //reverseOldIcm(ref bmpData);//Works!!
            return bmpData;

        }

        public static byte[] addBmpHeader(byte[] bmpData)
        {
            const int BMP_FILE_SIZE_2110 = 2110;
            const int BMP_HEADER_SIZE_62 = 62;
            byte[] bmpFile = new byte[2110];
            for (int i = 0; i < BMP_HEADER_SIZE_62; i++)
            {
                bmpFile[i] = bmpHeader[i];
            }
            //2 - Then pixel data, bottom to top aligned
            for (int i = BMP_HEADER_SIZE_62; i < BMP_FILE_SIZE_2110; i++)
            {
                bmpFile[i] = bmpData[i - BMP_HEADER_SIZE_62];
            }

            return bmpFile;
        }


        private static void fixOldIcm(ref byte[] bmpData)
        {
            //Display is split into smaler section that has been moved out of position.
            //Here we move them back.
            int i = 0;
            int j = 0;
            int k = 0;
            byte tmp = 0x00;

            //1st pass
            j = ((32 * 32) + 16);
            for (k = 0; k < 32; k++)
            {
                for (i = (32 * k); i < (32 * k) + 16; i++)
                {
                    tmp = bmpData[i + j];
                    bmpData[i + j] = bmpData[i];
                    bmpData[i] = tmp;
                }
            }

            //2nd pass
            j = 32 * 32;
            for (k = 0; k < 8; k++)
            {
                for (i = (32 * k); i < (32 * k) + 32; i++)
                {
                    tmp = bmpData[i + j];
                    bmpData[i + j] = bmpData[i + (32 * 8)];
                    bmpData[i + (32 * 8)] = tmp;
                }
            }

            //3rd pass
            j = 32 * 32;
            for (k = 0; k < 8; k++)
            {
                for (i = (32 * k); i < (32 * k) + 32; i++)
                {
                    tmp = bmpData[i + j];
                    bmpData[i + j] = bmpData[i + (32 * 16)];
                    bmpData[i + (32 * 16)] = tmp;
                }
            }

            //4th pass
            j = 32 * 40;
            for (k = 0; k < 8; k++)
            {
                for (i = (32 * k); i < (32 * k) + 32; i++)
                {
                    tmp = bmpData[i + j];
                    bmpData[i + j] = bmpData[i + (32 * 24)];
                    bmpData[i + (32 * 24)] = tmp;
                }
            }

            //5th pass
            j = 32 * 48;
            for (k = 0; k < 8; k++)
            {
                for (i = (32 * k); i < (32 * k) + 32; i++)
                {
                    tmp = bmpData[i + j];
                    bmpData[i + j] = bmpData[i + (32 * 40)];
                    bmpData[i + (32 * 40)] = tmp;
                }
            }
        }


        private static void reverseOldIcm(ref byte[] bmpData)
        {
            //Undo the changes that fixOldIcm does
            int i = 0;
            int j = 0;
            int k = 0;
            byte tmp = 0x00;

            //5th pass
            j = 32 * 48;
            for (k = 0; k < 8; k++)
            {
                for (i = (32 * k); i < (32 * k) + 32; i++)
                {
                    tmp = bmpData[i + j];
                    bmpData[i + j] = bmpData[i + (32 * 40)];
                    bmpData[i + (32 * 40)] = tmp;
                }
            }


            //4th pass
            j = 32 * 40;
            for (k = 0; k < 8; k++)
            {
                for (i = (32 * k); i < (32 * k) + 32; i++)
                {
                    tmp = bmpData[i + j];
                    bmpData[i + j] = bmpData[i + (32 * 24)];
                    bmpData[i + (32 * 24)] = tmp;
                }
            }


            //3rd pass
            j = 32 * 32;
            for (k = 0; k < 8; k++)
            {
                for (i = (32 * k); i < (32 * k) + 32; i++)
                {
                    tmp = bmpData[i + j];
                    bmpData[i + j] = bmpData[i + (32 * 16)];
                    bmpData[i + (32 * 16)] = tmp;
                }
            }


            //2nd pass
            j = 32 * 32;
            for (k = 0; k < 8; k++)
            {
                for (i = (32 * k); i < (32 * k) + 32; i++)
                {
                    tmp = bmpData[i + j];
                    bmpData[i + j] = bmpData[i + (32 * 8)];
                    bmpData[i + (32 * 8)] = tmp;
                }
            }

            //1st pass
            j = ((32 * 32) + 16);
            for (k = 0; k < 32; k++)
            {
                for (i = (32 * k); i < (32 * k) + 16; i++)
                {
                    tmp = bmpData[i + j];
                    bmpData[i + j] = bmpData[i];
                    bmpData[i] = tmp;
                }
            }

        }

        public static void Set(ref byte aByte, int pos, bool value)
        {
            if (value)
            {
                //left-shift 1, then bitwise OR
                aByte = (byte)(aByte | (1 << pos));
            }
            else
            {
                //left-shift 1, then take complement, then bitwise AND
                aByte = (byte)(aByte & ~(1 << pos));
            }
        }

        public static bool Get(byte aByte, int pos)
        {
            //left-shift 1, then bitwise AND, then check for non-zero
            return ((aByte & (1 << pos)) != 0);
        }

    }
}

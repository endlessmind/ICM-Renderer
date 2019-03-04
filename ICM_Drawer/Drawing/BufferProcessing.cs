using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICM_Drawer.Drawing
{
    public class BufferProcessing
    {
        const int bmpHeaderOffset = 61;
        public void insertLetter(int insCol, int insRow, byte[] lett,ref byte[]data)
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

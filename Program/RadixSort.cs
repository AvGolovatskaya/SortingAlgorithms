using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    class RadixSort:ISort
    {
        public void Sort(uint[] UnsortedArray, int Length)
        {
            int m = 256;
            uint[] buffer = new uint[Length];
            for (int j = 0; j < 4; j++)
            {
                uint[] count = new uint[m + 1];
                int i = 0;
                for (i = 0; i < Length; i++)
                {
                    byte temp = (byte)((UnsortedArray[i] >> 8 * j) & 255);
                    ++count[temp + 1];
                }
                for (i = 1; i < m + 1; i++)
                    count[i] += count[i - 1];
                for (i = 0; i < Length; i++)
                {
                    byte temp = (byte)((UnsortedArray[i] >> 8 * j) & 255);
                    buffer[count[temp]++] = UnsortedArray[i];
                }
                for (i = 0; i < Length; i++)
                    UnsortedArray[i] = buffer[i];
            }
        }
    }
}

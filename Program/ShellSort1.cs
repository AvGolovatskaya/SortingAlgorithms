using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    class ShellSort1:ISort
    {
        public void Sort(uint[] UnsortedArray, int Length)
        {
            int h = 0;
            for (h = 1; h <= Length / 9; h = 3 * h + 1)
                ;
            for (; h > 0; h /= 3)
            {
                for (int i = h; i < Length; i++)
                {
                    int j = i;
                    uint tmp = UnsortedArray[i];
                    while (j >= h && tmp < UnsortedArray[j - h])
                    {
                        UnsortedArray[j] = UnsortedArray[j - h];
                        j -= h;
                    }
                    UnsortedArray[j] = tmp;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    class InsertionSort:ISort
    {
        public void Sort(uint[] UnsortedArray, int Length)
        {
            for (int i = 1; i < Length; i++)
            {
                uint temp = UnsortedArray[i];
                int j = i - 1;
                while (j >= 0 && UnsortedArray[j] > temp)
                {
                    UnsortedArray[j + 1] = UnsortedArray[j];
                    j--;
                }
                UnsortedArray[j + 1] = temp;
            }
        }
    }
}

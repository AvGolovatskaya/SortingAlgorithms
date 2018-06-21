using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    class SelectionSort:ISort
    {
        public void Sort(uint[] UnsortedArray, int Length)
        {
            for (int i = 0; i < Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < Length; j++)
                {
                    if (UnsortedArray[j] < UnsortedArray[min])
                    {
                        min = j;
                    }
                }
                uint temp = UnsortedArray[i];
                UnsortedArray[i] = UnsortedArray[min];
                UnsortedArray[min] = temp;
                //if (min != i)
                //{
                //    uint temp = UnsortedArray[i];
                //    UnsortedArray[i] = UnsortedArray[min];
                //    UnsortedArray[min] = temp;
                //}
            }
        }
    }
}

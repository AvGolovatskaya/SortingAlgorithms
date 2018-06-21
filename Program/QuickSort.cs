using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    class QuickSort:ISort
    {
        public void Sort(uint[] UnsortedArray, int Length)
        {
            Quick_Sort(UnsortedArray, 0, Length - 1);
        }
        public static void Quick_Sort(uint[] UnsortedArray, int left, int right)
        {
            if (left >= right) return;
            else
            {
                int index = Partition(UnsortedArray, left, right);
                Quick_Sort(UnsortedArray, left, index - 1);
                Quick_Sort(UnsortedArray, index + 1, right);
            }
        }
        public static int Partition(uint[] UnsortedArray, int left, int right)
        {
            Random rnd = new Random();
            int p = rnd.Next(left, right + 1);
            uint pivot = UnsortedArray[p];
            int i = left;
            int j = right;
            while (true)
            {
                while (UnsortedArray[i] < pivot) i++;
                while (UnsortedArray[j] > pivot) j--;
                if (i < j)
                {
                    if (UnsortedArray[i] == UnsortedArray[j]) return j;
                    uint temp = UnsortedArray[i];
                    UnsortedArray[i] = UnsortedArray[j];
                    UnsortedArray[j] = temp;
                }
                else return j;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    class MergeSort:ISort
    {
        public void Sort(uint[] UnsortedArray, int Length)
        {
            if (Length <= 1)
                return;
            else
            {
                int mid = Length / 2;
                uint[] left = new uint[mid];
                uint[] right = new uint[Length - mid];
                Array.Copy(UnsortedArray, left, mid);
                Array.Copy(UnsortedArray, mid, right, 0, Length - mid);
                Sort(left, mid);
                Sort(right, Length - mid);
                uint[] buffer = Merge(left, mid, right, Length - mid);
                for (int i = 0; i < Length; i++)
                {
                    UnsortedArray[i] = buffer[i];
                }
            }
        }
        //Слияние.
        public static uint[] Merge(uint[] array1, int len1, uint[] array2, int len2)
        {
            uint[] mergedRes = new uint[len1 + len2];
            int i = 0;
            int j = 0;
            for (; i < len1 && j < len2;)
            {
                if (array1[i] < array2[j]) mergedRes[i + j] = array1[i++];
                else mergedRes[i + j] = array2[j++];
            }
            if (i == len1)
            {
                for (; j < len2; j++) mergedRes[i + j] = array2[j];
            }
            else
            {
                for (; i < len1; i++) mergedRes[i + j] = array1[i];
            }
            return mergedRes;
        }
    }
}

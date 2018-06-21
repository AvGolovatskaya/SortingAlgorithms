using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    class ShellSort2:ISort
    {
        public void Sort(uint[] UnsortedArray, int Length)
        {
            int[] hArray = new int[10];
            int step = 0;
            hArray[step] = 1;
            int h = 0;
            while (true)
            {
                hArray[step + 1] = (int)(Math.Pow(4, step + 1) + 3 * Math.Pow(2, step) + 1);
                if (3 * hArray[step + 1] > Length)
                {
                    break;
                }
                step++;
            }
            for (; step >= 0; step--)
            {
                h = hArray[step];
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

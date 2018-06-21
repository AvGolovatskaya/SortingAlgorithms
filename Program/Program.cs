using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public interface ISort
    {
        void Sort(uint[] UnsortedArray, int Length);
    }
    class Program
    {
        static void Main(string[] args)
        {
            //int[] lengths = { 100000 };
            int[] lengths = { 100, 500, 1000, 5000, 10000, 50000, 100000 };
            uint[] ExperimentArray = null;
            Stopwatch timer = new Stopwatch();
            long ExecutionTime;
            int qty = 15;
            long[] times = new long[qty];
            long sumt;
            TestArray.SortCases CurrentCase;
            TestArray.SortNames CurrentAlgorithm;
            for (CurrentAlgorithm = TestArray.SortNames.SelectionSort; CurrentAlgorithm <= TestArray.SortNames.RadixSort; CurrentAlgorithm++)
            {
                foreach (int len in lengths)
                {
                    for (CurrentCase = TestArray.SortCases.Best; CurrentCase <= TestArray.SortCases.Worst; CurrentCase++)
                    {
                        ExperimentArray = TestArray.GenerateArray(len, CurrentCase, CurrentAlgorithm);
                        uint[] copy = null;
                        for (int count = 0; count < qty; count++)
                        {
                            copy = TestArray.CopyArray(ExperimentArray, len);
                            for (int i = 0; i < len; i++)
                            {
                                if (copy[i] != ExperimentArray[i])
                                {
                                    Console.WriteLine("Array changed");
                                    break;
                                }
                            }
                            timer.Start();
                            TestArray.Sort(copy, len, CurrentAlgorithm);
                            timer.Stop();
                            ExecutionTime = timer.ElapsedMilliseconds;
                            times[count] = ExecutionTime;
                            timer.Reset();
                        }
                        sumt = 0;
                        foreach (long t in times)
                        {
                            sumt += t;
                        }
                        string FName = CurrentAlgorithm + "_" + CurrentCase + "_" + len + ".txt";
                        string FLine = "Количество элементов - " + len + ", алгоритм сортировки - " + CurrentAlgorithm +
                                       ", случай - " + CurrentCase + ", время работы - " + sumt / qty;
                        Console.WriteLine(FLine);
                        TestArray.CheckSort(copy, len);
                        TestArray.SaveResults(copy, len, FName, FLine);
                    }
                }
            }
            Console.ReadKey();
        }
    }
}

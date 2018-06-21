using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    class TestArray
    {
        public enum SortCases { Best, Ordinary, Worst }
        public enum SortNames { SelectionSort, InsertionSort, ShellSort1, ShellSort2, QuickSort, MergeSort, RadixSort}
        public static uint[] GenerateArray(int Length, SortCases Case, SortNames Name)
        {
            uint[] garr = new uint[Length];
            switch (Case)
            {
                case SortCases.Best:
                    switch (Name)
                    {
                        case (SortNames.RadixSort):
                            int ind = 0;
                            while (ind < Length)
                            {
                                for (uint m = 0; m <= 255; m++)
                                {
                                    for (uint k = 0; k <= 255; k++)
                                    {
                                        for (uint l = 0; l <= 255; l++)
                                        {
                                            for (uint j = 0; j <= 255; j++)
                                            {
                                                garr[ind] = (uint)(1000000000*m + 1000000*k + 1000*l + j);
                                                ind++;
                                                if (ind >= Length) break;
                                            }
                                            if (ind >= Length) break;
                                        }
                                        if (ind >= Length) break;
                                    }
                                    if (ind >= Length) break;
                                }
                            }
                            break;
                        default:
                            for (int i = 0; i < Length; i++)
                            {
                                garr[i] = (uint)i;
                            }
                            break;
                    }
                    break;
                case SortCases.Ordinary:
                    Random rnd = new Random();
                    for (int i = 0; i < Length; i++)
                    {
                        garr[i] = (uint)(rnd.NextDouble() * 3000000);
                    }
                    break;
                case SortCases.Worst:
                    switch(Name)
                    {
                        case (SortNames.SelectionSort):
                            int mid = Length / 2;
                            for (int i = 0; i < mid; i++)
                            {
                                garr[i] = (uint)(Length - i - 1);
                            }
                            for (int i = mid; i < Length; i++)
                            {
                                garr[i] = (uint)(i - mid);
                            }
                            break;
                        case (SortNames.RadixSort):
                            int ind = 0;
                            while(ind<Length)
                            {
                                for (uint m = 255; m>=0; m--)
                                {
                                    m = m << 24;
                                    for (uint k = 255; k>=0; k--)
                                    {
                                        k = k << 16;
                                        for (uint l = 255; l>=0; l--)
                                        {
                                            l = l << 8;
                                            for (uint j = 255; j>=0; j--)
                                            {
                                                garr[ind] = (uint)(m + k + l + j);
                                                ind++;
                                                if (ind >= Length) break;
                                            }
                                            if (ind >= Length) break;
                                        }
                                        if (ind >= Length) break;
                                    }
                                    if (ind >= Length) break;
                                }
                            }
                            break;
                        default:
                            for (int i = 0; i < Length; i++)
                            {
                                garr[i] = (uint)(Length - i - 1);
                            }
                            //for (int i = 0; i < Length; i++)
                            //{
                            //    garr[i] = 1000;
                            //}
                            break;
                    }

                    //for (int i = 0; i < Length; i++)
                    //{
                    //    garr[i] = 1000;
                    //}
                    break;
                default:
                    Console.WriteLine("Указан неизвестный вариант генерации массива.");
                    break;
            }
            return garr;
        }
        public static uint[] CopyArray(uint[] GeneratedArray, int Length)
        {
            uint[] buffer = new uint[Length];
            for (int i = 0; i < Length; i++)
            {
                buffer[i] = GeneratedArray[i];
            }
            return buffer;
        }
        public static void SaveResults(uint[] SortedArray, int Length, string FileName, string FirstLine)
        {
            FileStream FileResults;
            StreamWriter StreamResults;
            try
            {
                FileResults = new FileStream(FileName, FileMode.Create);
                StreamResults = new StreamWriter(FileResults);
                StreamResults.WriteLine(FirstLine);
                for (int i = 0; i < Length; i++)
                {
                    StreamResults.WriteLine(SortedArray[i]);
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Ошибка при работе с файлом " + FileName);
                return;
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Нет разрешения на доступ к файлу " + FileName);
                return;
            }
            StreamResults.Close();
        }
        public static void Sort(uint[] UnsortedArray, int Length, SortNames AlgorithmName)
        {
            ISort Algorithm = null;
            switch (AlgorithmName)
            {
                case (SortNames.SelectionSort):
                    Algorithm = new SelectionSort();
                    break;
                case (SortNames.InsertionSort):
                    Algorithm = new InsertionSort();
                    break;
                case (SortNames.ShellSort1):
                    Algorithm = new ShellSort1();
                    break;
                case (SortNames.ShellSort2):
                    Algorithm = new ShellSort2();
                    break;
                case (SortNames.QuickSort):
                    Algorithm = new QuickSort();
                    break;
                case (SortNames.MergeSort):
                    Algorithm = new MergeSort();
                    break;
                case (SortNames.RadixSort):
                    Algorithm = new RadixSort();
                    break;
            }
            Algorithm.Sort(UnsortedArray, Length);
        }
        public static void CheckSort(uint[] SortedArray, int Length)
        {
            for (int i = 1; i == Length; i++)
            {
                if (SortedArray[i] < SortedArray[i - 1]) Console.WriteLine("Unsorted");
            }
        }
    }
}

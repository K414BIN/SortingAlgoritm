using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_8
{
    class Program
    {
        public const int sizeArr = 20000;
        static void Main(string[] args)
        {
            int[] input_ar = new int[] { 10, 24, 22, 62, 1, 50, 100, 75, 2, 3 };
            Console.WriteLine("Массив целых чисел");
            prin(input_ar);
            Console.WriteLine("Блочная сортировка этого массива");
            bucket_sort(input_ar);
            prin(bucket_sort(input_ar));
            Console.ReadLine();
        }
        static int[] bucket_sort(int[] arr)
        {
            int r = 10;
            int bigDigit = 10000000;
            int n = arr.Length;
            int[] vector = arr;
            // вспомогательный массив
            int[,] s = new int[n, n];
            // Обнуление вспомогательного массива
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    s[i, j] = 0;
            for (int digit = 1; digit <= bigDigit; digit *= r)
            {
                for (int i = 0; i < n; i++)
                {
                    int temp = vector[i] / digit;
                    int ostatok = temp % 10;
                    s[ostatok, i] = vector[i];
                }
                int t = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                        if (s[i, j] != 0)
                        {
                            vector[t] = s[i, j];
                            t++;
                            s[i, j] = 0;
                        }
                }

            }
            return vector;
        }
        // Печать на экран массива
        static void prin(int[] arr)
        {
            for (int f = 0; f < arr.Length; f++)
            {
                Console.Write(arr[f]);
                Console.Write(' ');

            }
            Console.WriteLine();
        }
    }
}


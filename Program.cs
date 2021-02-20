using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int len = rand.Next(102) + 12;
            int[] input_ar = new int[len];
            for (var value=0; value <len;value++)
            {
              input_ar[value] = rand.Next(10020) + 12;
            }
            Console.WriteLine("Массив целых чисел.");
            prin(input_ar);
            Console.WriteLine("Блочная сортировка этого массива.");
            int[] b = bucket_sort(input_ar) ;
            prin(b);
            Console.WriteLine("Массив целых чисел, загруженный из файла.");
            prin(loadArr());
            Console.WriteLine("Блочная сортировка этого масива.");
            b = bucket_sort(loadArr());
            prin(b);
            Console.ReadLine();
        }
        static int[] bucket_sort(int[] arr)
        {
            int r = 10;
            //Самое большое число
            int bigDigit = 10000000;
            int n = arr.Length;
            // Массив-клон
            int[] vector = arr;
            // вспомогательный массив
            int[,] s = new int[n, n];
            // Обнуление вспомогательного массива
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    s[i, j] = 0;
            for (int digit = 1; digit <= bigDigit; digit *= r)
            {
                // раскладываем на блоки
                for (int i = 0; i < n; i++)
                {
                    int temp = vector[i] / digit;
                    int ostatok = temp % r;
                    s[ostatok, i] = vector[i];
                }
                // счетчик
                int t = 0;
                // засовываем обратно 
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                        // если элемент не ноль
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
        static int[] loadArr()
        {
            string fileName = "ByteFile.txt";
            string text;
            if (!File.Exists(fileName))
            {
                do
                {
                    Console.WriteLine("Введите через пробел целые положительные цифры: ");
                    text = Console.ReadLine();
                } while (text.Length < 12);// нужно еще больше цифр
                File.AppendAllText(fileName, Environment.NewLine);
                File.AppendAllText(fileName, text);
            };
            int[] arr = new int[] { };
            text = File.ReadAllText(fileName);
            // считываем все цифры в массив
            arr = text.Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            return arr;
        }
    }
}


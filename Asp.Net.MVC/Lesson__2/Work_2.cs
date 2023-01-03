using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.MVC.Lesson__2
{
    internal class Work_2
    {
        public static char[,] pole;
        public static int y;
        public static int x;

        public static void Run()
        {
            Console.WriteLine("Введите (4-4) (2-2)");
            Console.Write("Укажите размер поля по оси X: ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Укажите размер поля по оси Y: ");
            y = Convert.ToInt32(Console.ReadLine());
            pole = new char[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {

                    pole[i, j] = ' ';
                    Console.Write($"{pole[i, j]} \t");
                }
                Console.WriteLine();
            }
            Thread.Sleep(1000);
            ThreadPool.QueueUserWorkItem(new WaitCallback(sad1));
            ThreadPool.QueueUserWorkItem(new WaitCallback(sad2));

            Console.WriteLine("\n");


            Console.ReadLine();
        }
        public static void sad1(object o)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (pole[i, j] == ' ')
                        pole[i, j] = 'X';
                    Thread.Sleep(10);

                    Console.Write($"{pole[i, j]} {Thread.CurrentThread.ManagedThreadId} \t");

                }
                Console.WriteLine();
            }
        }
        public static void sad2(object o)
        {
            for (int i = x - 1; i >= 0; i--)
            {
                for (int j = y - 1; j >= 0; j--)
                {
                    if (pole[j, i] == ' ')
                        pole[j, i] = 'Y';
                    Thread.Sleep(10);
                    Console.Write($"{pole[i, j]} {Thread.CurrentThread.ManagedThreadId} \t");

                }
                Console.WriteLine();
            }
        }
    }
}

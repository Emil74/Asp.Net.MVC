using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.MVC.Lesson_1
{
    public class Work1
    {
        public static void Task2()
        {
            AutoResetEvent[] waitHandlers = new AutoResetEvent[2];

            for (int i = 0; i < waitHandlers.Length; i++)
            {
                waitHandlers[i] = new AutoResetEvent(false);
            }

            float[] arr = new float[100_000_000];
            float[] arr2 = new float[100_000_000];
            for (int i = 0; i < 100_000_000; i++)
            {
                arr[i] = 1;
            }
            float mid = (arr.Length + 1) / 2;
            float[] firsArray = arr.Take((int)mid).ToArray();
            float[] secondArray = arr.Skip((int)mid).ToArray();

            DateTime start = DateTime.Now;
            Thread thread1 = new Thread((o) =>
            {
                for (int i = 0; i < firsArray.Length; i++)
                {
                    firsArray[i] = (float)(firsArray[i] * Math.Sin(0.2f + i / 5) * Math.Cos(0.2f + i / 5) * Math.Cos(0.4f + i / 2));

                }
                ((AutoResetEvent)o).Set();
            });
            thread1.Start(waitHandlers[0]);

            Thread thread2 = new Thread((o) =>
            {
                for (int i = 0; i < secondArray.Length; i++)
                {
                    secondArray[i] = (float)(secondArray[i] * Math.Sin(0.2f + i / 5) * Math.Cos(0.2f + i / 5) * Math.Cos(0.4f + i / 2));

                }
                ((AutoResetEvent)o).Set();
            });
            thread2.Start(waitHandlers[1]);


            WaitHandle.WaitAll(waitHandlers);

            Array.Copy(firsArray, 0, arr2, 0, firsArray.Length);

            Array.Copy(secondArray, 0, arr2, secondArray.Length, secondArray.Length);

            DateTime finish = DateTime.Now;

            Console.WriteLine($"Инициализация массива заняла у нас (TAsK2):  {finish - start} сек.");

        }

        public static void Task1()
        {
            float[] arr = new float[100_000_000];
            for (int i = 0; i < 100_000_000; i++)
            {
                arr[i] = 1;
            }


            DateTime start = DateTime.Now;

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = (float)(arr[i] * Math.Sin(0.2f + i / 5) * Math.Cos(0.2f + i / 5) * Math.Cos(0.4f + i / 2));

            }

            DateTime finish = DateTime.Now;


            Console.WriteLine($"Инициализация массива заняла у нас (TAsK1):  {finish - start} сек.");
        }
    }
}

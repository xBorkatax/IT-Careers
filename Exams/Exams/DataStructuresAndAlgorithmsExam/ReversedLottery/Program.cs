using System;

namespace ReversedLottery
{
    internal class Program
    {
        static void printArray(int[] array)
        {
            Console.Write(array[0]);

            for (int i = 1; i < array.Length; i++)
            {
                Console.Write("." + array[i]);
            }

            Console.WriteLine();

            return;
        }

        static bool isArrayCompleted(int[] array, int N)
        {
            bool isArrayNotCompleted = true;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != N)
                {
                    isArrayNotCompleted = false;
                }
            }

            return !isArrayNotCompleted;
        }

        static void Main(string[] args)
        {
            int K = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());

            int[] numbers = new int[K];

            for (int i = 0; i < K; i++)
            {
                numbers[i] = 1;
            }

            printArray(numbers);

            while (isArrayCompleted(numbers, N))
            {
                numbers[numbers.Length - 1]++;

                for (int i = K - 1; i > 0 && numbers[i] > N ; i--)
                {
                    numbers[i] -= N;
                    numbers[i - 1]++;
                }

                printArray(numbers);
            }
        }
    }
}

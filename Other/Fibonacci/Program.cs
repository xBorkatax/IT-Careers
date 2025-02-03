namespace Fibonacci
{
    internal class Program
    {
        static int count = 0;
        static void Main(string[] args)
        {
            int fibonacci = GetFibonacciNumber(4);
            Console.WriteLine($"{fibonacci} - {count}");
        }

        private static int GetFibonacciNumber(int number)
        {
            if (number <= 0) 
            {
                return 1;
            }
            count++;
            return GetFibonacciNumber(number - 1) + GetFibonacciNumber(number - 2);
        }
    }
}
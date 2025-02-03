namespace Fibonacci_Iterativ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fibonacciNumber = 8;

            if (fibonacciNumber <= 0)
            {
                Console.WriteLine(1);
            }

            int prev = 1;
            int prevPrev = 1;

            for (int i = 2; i <= fibonacciNumber; i++)
            {
                int result = prev + prevPrev;
                Console.WriteLine($"Fib({i}) = {result}");

                prevPrev = prev;
                prev = result;
            }
        }
    }
}
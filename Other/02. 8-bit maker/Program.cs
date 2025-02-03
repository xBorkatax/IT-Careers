namespace _02._8_bit_maker
{
    internal class Program
    {
        public static void Generate(int index, int limit, int[] vector) 
        {
            if(index >= limit)
            {
                Console.WriteLine(string.Join(" ", vector));
                return;
            }

            for (int i = 0; i < 2; i++) 
            {
                vector[index] = i;
                Generate(index + 1, limit, vector);
            }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Generate(0, n, new int[n]);
        }
    }
}
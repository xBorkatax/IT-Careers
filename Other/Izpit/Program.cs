namespace Izpit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            Permute(0, k, n ,new int[k]);
        }

        public static void Permute(int index,  int k, int n, int[] permutation)
        {
            if (index >= k)
            {
                Console.WriteLine(string.Join(".", permutation.Select(x => x.ToString()).ToArray()));
                return;
            }
            for (int i = 1; i <= n; i++) 
            {
                permutation[index] = i;
                Permute(index + 1, k, n, permutation);
            }
        }
    }
}
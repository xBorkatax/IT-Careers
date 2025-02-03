namespace Combinatorics
{
    internal class Program
    {
        static int countOfOperations = 1;
        public static void Permute(int index, string[] permutation, bool[] used, string[] elements) 
        {
            if (index >= permutation.Length)
            {
                Console.WriteLine(string.Join(" ",permutation));
            }
            else
            { 
                for (int i = 0; i < permutation.Length; i++) 
                {
                    countOfOperations++;
                    if (!used[i])
                    {
                        used[i] = true;
                        permutation[index] = elements[i];
                        Permute(index +1, permutation, used, elements);
                        used[i] = false;
                    }                
                }
            }
            
        }
        public static void Swap(int originIndex, int destinatonIndex, string[] permutation ) 
        { 
            string temp = permutation[destinatonIndex];
            permutation[destinatonIndex] = permutation[originIndex];
            permutation[originIndex] = temp;
        }
        public static void PermuteSwap(int index, string[] elements)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
            }
            else
            {
                PermuteSwap(index + 1, elements);
                for (int i = index + 1; i < elements.Length; i++)
                {
                    countOfOperations++;
                    Swap(index, i, elements);
                    PermuteSwap(index + 1, elements);
                    Swap(index, i, elements);
                }
            }

        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] elements =
                Enumerable.Range(0, n)
                .Select(i => ((char)(i + 65)).ToString())
                .ToArray();

            Permute(0, new string[n], new bool[n], elements);
            //PermuteSwap(0, elements);
            //Console.WriteLine("Count of operations:" + countOfOperations);

        }
    }
}
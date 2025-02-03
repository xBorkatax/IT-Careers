using System;

namespace _03._Iterative_Permutations_without_Repetitions
{
    class Program
    {
        static long count = 0;

        public static void SwapPermute(
            int index,
            string[] set)
        {
            if (index >= set.Length)
            {
                Console.WriteLine(string.Join(" ", set));
            }
            else
            {
                SwapPermute(index + 1, set);

                for (int i = index + 1; i < set.Length; i++)
                {
                    Swap(set, index, i);
                    SwapPermute(index + 1, set);
                    Swap(set, index, i);
                }
            }
        }

        public static void Permute(
            int index,
            string[] set,
            bool[] used,
            string[] currentPermutation)
        {
            if (index >= currentPermutation.Length)
            {
                count++;
                //Console.WriteLine(string.Join(" ", currentPermutation));
            }
            else
            {
                for (int i = 0; i < set.Length; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        currentPermutation[index] = set[i];
                        Permute(index + 1, set, used, currentPermutation);
                        used[i] = false;
                    }
                }
            }
        }

        private static void Swap(string[] set, int first, int second)
        {
            string temp = set[first];
            set[first] = set[second];
            set[second] = temp;
        }

        private static void IterativeVariate(string[] set, int[] currentVariation)
        {
            while (true)
            {
                count++;

                int index = currentVariation.Length - 1;

                while (index >= 0 && currentVariation[index] == set.Length - 1)
                {
                    index--;
                }

                if (index < 0)
                {
                    break;
                }

                currentVariation[index]++;

                for (int i = index + 1; i < currentVariation.Length; i++)
                {
                    currentVariation[i] = 0;
                }
            }
        }

        public static void Combine(int index, int currentElement, string[] set,string[] currentCombo)
        {
            if (index >= currentCombo.Length)
            {
                Console.WriteLine(string.Join(" ", currentCombo));
            }
            else
            {
                for (int i = currentElement; i < set.Length; i++)
                {
                    currentCombo[index] = set[i];
                    Combine(index + 1, i + 1, set, currentCombo);
                }
            }
        }

        public static void Main(string[] args)
        {
            //string[] set = { "A", "B", "C", "D" };

            string[] set = Enumerable.Range(0, 4).Select(x => ((char)(x + 65)).ToString()).ToArray();

            Combine(0, 0, set, new string[2]);
        }
    }
}
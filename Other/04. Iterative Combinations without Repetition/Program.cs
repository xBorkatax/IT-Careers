namespace _04._Iterative_Combinations_without_Repetition
{
    internal class Program
    {
        public static void Permute(int index, string[] permutation, bool[] used, bool[] permaUser, string[] elements)
        {
            int proba = 0;
            
            if (index >= permutation.Length)
            {
                Console.WriteLine(string.Join(" ", permutation));
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {

                    if (!permaUser[i])
                    {
                        if (!used[i])
                        {
                            used[i] = true;
                            permutation[index] = elements[i];
                            //used[i] = false;
                            Permute(index + 1, permutation, used, permaUser, elements);
                            used[i] = false;
                            permaUser[proba] = true;
                            if (index == 0) 
                            { 
                                proba++; 
                            }
                        }   
                    }
                }
            }
        }
        static void Main(string[] args)
        {

            string stringElements = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            string[] elements = new string[] {" "};
            elements = stringElements.Split(" ");
            int elementsCount = elements.Count();


            //Console.WriteLine(elements[1]);
            Permute(0, new string[n], new bool[elementsCount], new bool[elementsCount], elements);

        }
    }
}
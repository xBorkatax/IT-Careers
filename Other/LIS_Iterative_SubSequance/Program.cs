namespace LIS_Iterative_SubSequance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputSequance = { 3, 14, 5, 12, 15, 7, 8, 9, 11, 10, 1 };
            int[] lenghts = new int[inputSequance.Length];
            List<List<int>> finalSubSequances = new List<List<int>>();

            List<int> subsequance = new List<int>() { inputSequance[0] };
            int lenght = 1;
            lenghts[0] = lenght;

            finalSubSequances.Add(new List<int>(subsequance));

            for (int i = 0; i < inputSequance.Length; i++)
            {
                int currentNum = inputSequance[i];
                int prevNum = inputSequance[i - 1];

                if (currentNum > prevNum) 
                { 
                    subsequance.Add(currentNum);
                    lenght++;
                    finalSubSequances.Add(new List<int>(subsequance));
                }
                else
                {
                    while (currentNum <= prevNum) 
                    {
                        subsequance.Remove(subsequance.Last());
                        lenght--;
                        if (lenght == 0) 
                        {
                            break;
                        }
                        prevNum = subsequance.Last();
                    }
                    subsequance.Add(currentNum);
                    lenght++;
                    finalSubSequances.Add(new List<int>(subsequance));
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, finalSubSequances.Select(subseq => string.Join("->", subseq))));
        }
    }
}
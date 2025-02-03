namespace _01._Test
{
    internal class Program
    {
        public static void PrintForms(int count)
        {
            if (count == 0) 
            {
                return;            
            }
            Console.WriteLine(new string('*', count));
            PrintForms(count - 1);
            Console.WriteLine(new string('#', count)); // Backtracking
        }
        static void Main(string[] args)
        {
            PrintForms(5);
        }
    }
}
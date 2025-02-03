namespace Recursion_Example
{
    internal class Program
    {
        public static void TraverseArray(int index, int[] array)
        {
            if (index >= array.Length)
            {
                return;
            }

            Console.WriteLine(array[index]);
            TraverseArray(index + 1, array);
        }
        public static void TraverseArray1(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3 };

            TraverseArray(0, array);
            TraverseArray1(array);

            //for (int i = 0; i < array.Length; i++)
            //{
            //    Console.WriteLine(array[i]);
            //}
        }
    }
}
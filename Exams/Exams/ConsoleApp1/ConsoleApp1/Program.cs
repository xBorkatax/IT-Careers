namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 18, 188 };
            Console.WriteLine(BinarySearch(nums, 18));
        }

        // returns -1 if not found
        public static int BinarySearch(int[] array, int target)
        {
            // <= target
            int left = 0;
            // > target
            int right = array.Length;
            int mid = (left + right) / 2;
            while(left != mid)
            {
                if (array[mid] == target) 
                {
                    return mid;
                }
                mid = (left + right) / 2;
                if (array[mid] <= target)
                {
                    left = mid;
                }
                if (array[mid] > target)
                {
                    right = mid;
                }
            }
            return -1;
        }
    }
}

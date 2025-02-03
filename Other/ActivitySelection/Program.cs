namespace ActivitySelection
{
    internal class Program
    {
        static List<int> activityStarts = new List<int> { 1, 3, 0, 5, 3, 5, 6, 8, 8, 2, 12 };
        static List<int> activityEnds = new List<int> { 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
        static List<int> selectedActivityIndexes = new List<int> { };
        static List<int> validActivityIndexes = new List<int> { };
        public static void SelectActivity()
        {
            int earliestActivityEndTime = int.MaxValue;
            int selectedIndex = -1;

            for (int i = 0; i < activityEnds.Count; i++) 
            {
                int currentEndTime = activityEnds[i];

                if (earliestActivityEndTime > currentEndTime && validActivityIndexes.Contains(i))
                {
                    earliestActivityEndTime = currentEndTime;
                    selectedIndex = i;
                }
            }
            selectedActivityIndexes.Add(selectedIndex);
            validActivityIndexes.Remove(selectedIndex);
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < activityStarts.Count; i++)
            {
                validActivityIndexes.Add(i);
            }
            while (validActivityIndexes.Count > 0) 
            {
                SelectActivity();
                RemoveInvalidActivities();
            }
            Console.WriteLine(string.Join(" ", selectedActivityIndexes.Select(x =>$"{activityStarts[x]} - {activityEnds[x]}")));
        }

        private static void RemoveInvalidActivities()
        {
            int lastSelectedActivityIndex = selectedActivityIndexes.Last();
            int lastSelectedActivityEndTime = activityEnds[lastSelectedActivityIndex];
            for (int i = 0; i < activityStarts.Count; i++)
            {
                int activityStartTime = activityStarts[i];

                if (activityStartTime < lastSelectedActivityEndTime)
                {
                    validActivityIndexes.Remove(i);
                }
            }
        }
    }
}
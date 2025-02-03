int pages = int.Parse(Console.ReadLine());
int pagesForHour = int.Parse(Console.ReadLine());
int daysNeeded = int.Parse(Console.ReadLine());
int hoursNeeded = pages / pagesForHour;
int hoursNeededForDay = hoursNeeded / daysNeeded;
Console.WriteLine(hoursNeededForDay);

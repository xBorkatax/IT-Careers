string name = Console.ReadLine();
int countOfProjects = int.Parse(Console.ReadLine());
if (countOfProjects > 100 || countOfProjects < 0)
{
    Console.WriteLine("Your Projects must be between 0 and 100!");
}
int timeForProject = 3;
int allTime = timeForProject * countOfProjects;
Console.WriteLine($"The architect {name} will need {allTime} hours to complete {countOfProjects} project/s.");

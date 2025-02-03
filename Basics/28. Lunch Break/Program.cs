string name = Console.ReadLine();
int filmLenght = int.Parse(Console.ReadLine());
int time = int.Parse(Console.ReadLine());

double lunch = time * 1 / 8; 
double relax = time * 1 / 4;
double rest = time - lunch - relax;
if (rest >= filmLenght)
{
    double a = rest - filmLenght;
    Console.WriteLine($"You have enough time to watch {name} and left with {a} minutes free time.");
}
else
{
    Console.WriteLine($"You don't have enough time to watch {name}, you need {filmLenght - rest} more minutes.");
}
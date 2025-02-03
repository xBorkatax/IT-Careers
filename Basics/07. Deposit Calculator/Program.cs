double money = double.Parse(Console.ReadLine());
int time = int.Parse(Console.ReadLine());
double interest = double.Parse(Console.ReadLine());
double neededInterest = interest / 100;
Console.WriteLine(money + time * ((money * neededInterest) / 12));
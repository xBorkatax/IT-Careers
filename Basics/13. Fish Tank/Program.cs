double lenght = int.Parse(Console.ReadLine());
double width = int.Parse(Console.ReadLine());
double height = int.Parse(Console.ReadLine());
double percentage = int.Parse(Console.ReadLine());

double liters = 0.001;
double percentageLast = 1 - (percentage / 100);

double volume = lenght * width * height;
double volumeLiters = volume * liters;
double result = volumeLiters * percentageLast;
Console.WriteLine(result);
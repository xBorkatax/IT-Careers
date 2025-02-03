int buget = int.Parse(Console.ReadLine());
string season = Console.ReadLine();
int fishers = int.Parse(Console.ReadLine());

double price = 0;
double discount =0;
switch (season)
{
	case "Spring":
		price = 3000; 
		break;
	case "Summer":
	case "Antumn":
		price = 4200;
		break;
	case "Winter":
		price = 2600;
		break;
}

if (fishers <= 6)
{
	discount = price * 0.1;
}
else if (fishers <= 11)
{
	discount = price * 0.15;
}
else
{
	discount = price * 0.25;
}

price = price - discount;

if (fishers % 2 == 0 && season != "Antumn")
{
	price = price * 0.95;
}

if (buget > price)
{
    Console.WriteLine($"Yes! You have {buget-price:F2} leva left.");
}
else
{
    Console.WriteLine($"Not enough money! You need {price - buget:F2} leva.");
}
string name = Console.ReadLine();
int number = int.Parse(Console.ReadLine());
int buget = int.Parse(Console.ReadLine());

double price = 0;
switch (name)
{
	case "Roses":
		price = 5;
		break;
	case "Dahlias":
		price = 3.8;
		break;
	case "Tulips":
		price = 2.8;
        break;
	case "Narcissus":
		price = 3;
        break;
	case "Gladiolus":
		price = 2.5;
		break;
}
price = price * number;
double discount = 0;
if (number > 80 && name == "Roses")
{
     discount = price * 0.1;
}
else if (number > 90 && name == "Dahlias")
{
    discount = price * 0.15;
}
else if (number > 80 && name == "Tulips")
{
    discount = price * 0.15;
}
else if (number < 120 && name == "Narcissus")
{
    discount = price * 0.15;
}
else if (number < 80 && name == "Gladiolus")
{
    discount = price * 0.20;
}

price = price - discount;
if (price < buget)
{
    Console.WriteLine($"Hey, you have a great garden with {number} {name} and {buget-price:F2} leva left.");
}
else
{
    Console.WriteLine($"Not enough money, you need {price - buget:F2} leva more.");
}


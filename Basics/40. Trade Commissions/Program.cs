string town = Console.ReadLine();
double price = double.Parse(Console.ReadLine());

if (0 <= price && price <= 500)
{
	switch (town)
	{
		case "Sofia":
            Console.WriteLine($"{price * 0.05:F2}");
            break;
        case "Varna":
            Console.WriteLine($"{price * 0.045:F2}");
            break;
        case "Plovdiv":
            Console.WriteLine($"{price * 0.055:F2}");
            break;
        default:
            Console.WriteLine("error");
            break;
	}
}
else if(500 < price && price <= 1000)
{
    switch (town)
    {
        case "Sofia":
            Console.WriteLine($"{price * 0.07:F2}");
            break;
        case "Varna":
            Console.WriteLine($"{price * 0.075:F2}");
            break;
        case "Plovdiv":
            Console.WriteLine($"{price * 0.08:F2}");
            break;
        default:
            Console.WriteLine("error");
            break;
    }
}
else if (1000 < price && price <= 10000)
{
    switch (town)
    {
        case "Sofia":
            Console.WriteLine($"{price * 0.08:F2}");
            break;
        case "Varna":
            Console.WriteLine($"{price * 0.1:F2}");
            break;
        case "Plovdiv":
            Console.WriteLine($"{price * 0.12:F2}");
            break;
        default:
            Console.WriteLine("error");
            break;
    }
}
else 
{
    switch (town)
    {
        case "Sofia":
            Console.WriteLine($"{price * 0.12:F2}");
            break;
        case "Varna":
            Console.WriteLine($"{price * 0.13:F2}");
            break;
        case "Plovdiv":
            Console.WriteLine($"{price * 0.145:F2}");
            break;
        default:
            Console.WriteLine("error");
            break;
    }
}
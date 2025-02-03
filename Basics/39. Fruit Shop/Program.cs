string fruit = Console.ReadLine();
string day = Console.ReadLine();
int amount = int.Parse(Console.ReadLine());

if (day == "Sunday" || day == "Saturday")
{
	switch (fruit)
	{
		case "banana":
            Console.WriteLine($"{amount * 2.7:F2}");
			break;
        case "apple":
            Console.WriteLine($"{amount * 1.25:F2}");
            break;
        case "orange":
            Console.WriteLine($"{amount * 0.90:F2}");
            break;
        case "grapefruit":
            Console.WriteLine($"{amount * 1.60:F2}"     );
            break;
        case "kiwi":
            Console.WriteLine($"{amount * 3:F2}");
            break;
        case "pineapple":
            Console.WriteLine($"{amount * 5.6:F2}");
            break;
        case "grapes":
            Console.WriteLine($"{amount * 4.20:F2}");
            break;
        default:
            Console.WriteLine("error"); 
			break;
	}
}
else if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
{
    switch (fruit)
    {
        case "banana":
            Console.WriteLine($"{amount * 2.5:F2}");
            break;
        case "apple":
            Console.WriteLine($"{amount * 1.2:F2}");
            break;
        case "orange":
            Console.WriteLine($"{amount * 0.85:F2}");
            break;
        case "grapefruit":
            Console.WriteLine($"{amount * 1.45:F2}");
            break;
        case "kiwi":
            Console.WriteLine(  $"{amount * 2.7:F2}");
            break;
        case "pineapple":
            Console.WriteLine($"{amount * 5.5:F2}");
            break;
        case "grapes":
            Console.WriteLine($"{amount * 3.85:F2}");
            break;
        default:
            Console.WriteLine("error");
            break;
    }
}
else
{
    Console.WriteLine("error");
}
string day = Console.ReadLine();

switch (day)
{
    case "Monday":
        Console.WriteLine(12);
        break;
    case "Tuesday":
        Console.WriteLine(12);
        break;
    case "Wednesday":
        Console.WriteLine(14);
        break;
    case "Thurday":
        Console.WriteLine(14);
        break;
    case "Friday":
        Console.WriteLine(12);
        break;
    case "Saturday":
        Console.WriteLine(16);
        break;
    case "Sunday":
        Console.WriteLine(16);
        break;
    default:
        Console.WriteLine("error");
        break;
}
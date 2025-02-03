int days = int.Parse(Console.ReadLine());
string type = Console.ReadLine();
string note = Console.ReadLine();

days -= 1;
double roomForOnePerson = 18;
double apartament = 25;
double presodentApartament = 35;
double total = 0;
switch (type)
{
	case "room for one person":
		total = roomForOnePerson * days; 
		break;
	case "apartament":
		total = apartament * days;
		break;
	case "president apartament":
		total = presodentApartament * days;
		break;
}

if (days < 10)
{
	switch (type)
	{
        case "apartament":
			total *= 0.7;
            break;
        case "president apartament":
            total *= 0.9;
            break;
    }
}
else if (days < 15)
{
    switch (type)
    {
        case "apartament":
            total *= 0.65;
            break;
        case "president apartament":
            total *= 0.85;
            break;
    }
}
else
{
    switch (type)
    {
        case "apartament":
            total *= 0.5;
            break;
        case "president apartament":
            total *= 0.8;
            break;
    }
}

switch (note)
{
    case "positive":
        total *= 1.25;
        break;
    case "negative":
        total *= 0.9;
        break;
}

Console.WriteLine($"{total:F2}");
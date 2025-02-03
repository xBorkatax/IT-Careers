double buget = double.Parse(Console.ReadLine());
string season = Console.ReadLine();

double price = 0;
string where = "";
string art = "";
if (buget <= 100)
{
	switch (season)
	{
		case "summer":
			price = buget * 0.3;
            art = "Camp";
            break;
		case "winter":
			price = buget * 0.7;
            art = "Hotel";
            break;
	}
    where = "Bulgaria";
}
else if (buget <= 1000)
{
    switch (season)
    {
        case "summer":
            price = buget * 0.4;
            art = "Camp";
            break;
        case "winter":
            price = buget * 0.8;
            art = "Hotel";
            break;
    }
    where = "Balkans";
}
else
{  
    price = buget * 0.9;
    where = "Europe";
    art = "Hotel";
}
Console.WriteLine($"Somewhere in {where}");
Console.WriteLine($"{art} - {price:F2}");
string name = Console.ReadLine();
string town = Console.ReadLine();
int amount = int.Parse(Console.ReadLine());

if (town == "Sofia")
{
	switch (name)
	{
		case "coffee":
            Console.WriteLine(amount * 0.50);
            break;
        case "water":
            Console.WriteLine(amount * 0.80);
            break;
        case "beer":
            Console.WriteLine(amount * 1.20);
            break;
        case "sweets":
            Console.WriteLine(amount * 1.45);
            break;
        case "peanuts":
            Console.WriteLine(amount * 1.60);
            break;
    }
}
else if (town == "Plovdiv")
{
    switch (name)
    {
        case "coffee":
            Console.WriteLine(amount * 0.40);
            break;
        case "water":
            Console.WriteLine(amount * 0.70);
            break;
        case "beer":
            Console.WriteLine(amount * 1.15);
            break;
        case "sweets":
            Console.WriteLine(amount * 1.30);
            break;
        case "peanuts":
            Console.WriteLine(amount * 1.50);
            break;
    }
}
else if (town == "Varna")
{
    switch (name)
    {
        case "coffee":
            Console.WriteLine(amount * 0.45);
            break;
        case "water":
            Console.WriteLine(amount * 0.70);
            break;
        case "beer":
            Console.WriteLine(amount * 1.10);
            break;
        case "sweets":
            Console.WriteLine(amount * 1.35);
            break;
        case "peanuts":
            Console.WriteLine(amount * 1.55);
            break;
    }
}

double budget = double.Parse(Console.ReadLine());
int extras = int.Parse(Console.ReadLine());
double clothing = double.Parse(Console.ReadLine());

double decoration = 0.1;

double priceDecoration = budget * decoration;
double clothingPrice = extras * clothing;
if (extras > 150)
{
    double discount = 0.9;
    double total = clothingPrice * discount + priceDecoration;
    if (total < budget)
    {
        Console.WriteLine("Action!");
        Console.WriteLine($"Wingard starts filming with {budget - total:F2} leva left.");
    }
    else 
    {
        Console.WriteLine("Not enough money!");
        Console.WriteLine($"Wingard needs {total - budget:F2} leva more.");

    }
}
else
{
    double total = clothingPrice  + priceDecoration;
    if (total < budget)
    {
        Console.WriteLine("Action!");
        Console.WriteLine($"Wingard starts filming with {budget - total:F2} leva left.");
    }
    else
    {
        Console.WriteLine("Not enough money!");
        Console.WriteLine($"Wingard needs {total - budget:F2} leva more.");

    }
}
double degrees = double.Parse(Console.ReadLine());
string timeOfDay = Console.ReadLine();

string outfit = "";
string shoes = "";
if (degrees >= 10 && degrees <= 18)
{
    if (timeOfDay == "Morning")
    {
        outfit = "Sweatschift";
        shoes = "Sneakers";
    }
    else if (timeOfDay == "Afternoon" || timeOfDay == "Evening")
    {
        outfit = "Shirt";
        shoes = "Moccasins";
    }
}
Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
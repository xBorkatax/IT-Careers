string figure = Console.ReadLine();

if (figure == "square")
{
    double a = double.Parse(Console.ReadLine());
    double area = a * a;
    Console.WriteLine($"{area:F3}");
}
else if(figure == "rectangle")
{
    double a = double.Parse(Console.ReadLine());
    double b = double.Parse(Console.ReadLine());
    double area = a * b;
    Console.WriteLine($"{area:F3}");
}
else if (figure == "circle")
{
    double a = double.Parse(Console.ReadLine());
    double area = Math.PI * a * a;
    Console.WriteLine($"{area:F3}");
}
else if (figure == "triangle")
{
    double a = double.Parse(Console.ReadLine());
    double b = double.Parse(Console.ReadLine());
    double area = a * b / 2;
    Console.WriteLine($"{area:F3}");
}
else
{
    Console.WriteLine("Error!");
}
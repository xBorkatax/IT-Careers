double time = double.Parse(Console.ReadLine());
string day = Console.ReadLine();

if (day == "Sunday")
{
    Console.WriteLine("closed");
}
else if (time < 10  || time > 18)
{
    Console.WriteLine("closed");
}
else
{
    Console.WriteLine("open");
}
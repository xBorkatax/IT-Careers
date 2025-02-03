double time = double.Parse(Console.ReadLine());
double lenght  = double.Parse(Console.ReadLine());
double speed  = double.Parse(Console.ReadLine());


double timeToMakeIt = lenght * speed;
double delay = (lenght / 15) * 12.5;
double timeTotal = timeToMakeIt +  delay;
if (time < timeTotal)
{
    double needed = timeTotal - time;
    Console.WriteLine($"No, he failed! He was {needed:F2} seconds slower.");
}
else 
{
    Console.WriteLine($" Yes, he succeeded! The new world record is {timeTotal:F2} seconds.");
}
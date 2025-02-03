int points = int.Parse(Console.ReadLine());
if (points <= 100)
{
    if (points % 2  == 0)
    {
        int a = 1;
        Console.WriteLine(5 + a);
        Console.WriteLine(a + points + 5);
    }
    else if (points % 5 == 0)
    {
        int a = 2;
        Console.WriteLine(5 + a);
        Console.WriteLine(a + points + 5);
    }
    else
    {
        Console.WriteLine(5);
        Console.WriteLine(points + 5);
    }
    
}
else if (points <= 1000)
{
    if (points % 2 == 0)
    {
        int a = 1;
        double bonus = points * 0.2;
        Console.WriteLine(bonus + a);
        Console.WriteLine(a + points + bonus);
    }
    else if (points % 5 == 0)
    {
        int a = 2;
        double bonus = points * 0.2;
        Console.WriteLine(bonus + a);
        Console.WriteLine(a + points + bonus);
    }
    else
    {
        double bonuS = points * 0.2;
        Console.WriteLine(bonuS);
        Console.WriteLine(points + bonuS);
    }
    
}
else
{
    if (points % 2 == 0)
    {
        int a = 1;
        double bonus = points * 0.1;
        Console.WriteLine(bonus + a);
        Console.WriteLine(a + points + bonus);
    }
    else if (points % 5 == 0)
    {
        int a = 2;
        double bonus = points * 0.1;
        Console.WriteLine(bonus + a);
        Console.WriteLine(a + points + bonus);
    }
    else
    {
        double bonuS = points * 0.1;
        Console.WriteLine(bonuS);
        Console.WriteLine(points + bonuS);
    }
    
}
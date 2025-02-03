int n = int.Parse(Console.ReadLine());

int maxNumber = int.MinValue;
int minNumber = int.MaxValue;
for (int i = 0; i < n; i++) 
{
    int Number = int.Parse(Console.ReadLine());
    if (Number < minNumber)
    {
        minNumber = Number;
    }
    else if (Number > maxNumber)
    {
        maxNumber = Number;
    }
}
Console.WriteLine(minNumber);
Console.WriteLine(maxNumber);
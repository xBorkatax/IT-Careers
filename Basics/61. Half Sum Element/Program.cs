int n = int.Parse(Console.ReadLine());

int sum = 0;
int max = int.MinValue;
for (int i = 0; i < n; i++)
{
    int b = int.Parse(Console.ReadLine());
    sum += b;

    if (b > max)
    {
        max = b; 
    } 
}

int result = sum - max;

if (max == result)
{
    Console.WriteLine("Yes, sum " + max);
}
else
{
    Console.WriteLine($"No, diff {Math.Abs(max - result)}");
}
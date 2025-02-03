int n = int.Parse(Console.ReadLine());

int odd = 0;
int even = 0;

for (int i = 0; i < n; i++)
{
    int b = int.Parse(Console.ReadLine());
    if (i % 2 == 1)
    {
        odd += b;
    }
    else
    {
        even += b;
    }
}

if (odd == even)
{
    Console.WriteLine($"Yes, sum = {odd}");
}
else
{
    Console.WriteLine("No");
}
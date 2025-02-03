int n = int.Parse(Console.ReadLine());

int left = 0;
int right = 0;

for (int i = 0; i < n; i++)
{
    int b = int.Parse(Console.ReadLine());
    left = +b;
}

for (int i = 0; i < n; i++)
{
    int b = int.Parse(Console.ReadLine());
    right = +b;
}

if (left == right)
{
    Console.WriteLine($"Yes, sum = {right}");
}
else
{
    Console.WriteLine($"No, diff = {Math.Abs(left-right)}");
}
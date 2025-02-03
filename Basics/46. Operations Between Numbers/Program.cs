double n1 = double.Parse(Console.ReadLine());
double n2 = double.Parse(Console.ReadLine());
string operation = Console.ReadLine();

double exit = 0;

switch (operation)
{
	case "+":
		exit = n1 + n2;
		break;
	case "-":
		exit = n1 - n2;
		break;
	case "*":
		exit = n1 * n2;
        break;
	case "/":
		exit = n1 / n2;
        break;
	case "%":
		exit = n1 % n2;
		break;
}

if (n2 == 0)
{
    Console.WriteLine($"Cannot divide {n1} by zero");
}
else
{
    Console.WriteLine($"{n1} {operation} {n2} = {exit:F2}");
}
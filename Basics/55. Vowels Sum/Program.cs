string text = Console.ReadLine();

int result = 0;

for (int i = 0; i < text.Length; i++)
{
    char c = text[i];
	switch (c)
	{
		case 'a':
			result += 1; 
			break;
		case 'e':
			result += 2;
			break;
		case 'i':
			result += 3;
			break;
		case 'o':
			result += 4;
			break;
		case 'u':
			result += 5;
			break;
	}
}
Console.WriteLine(result);
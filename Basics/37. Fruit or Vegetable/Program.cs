string name = Console.ReadLine();

switch (name)
{
    case "banana":
    case "apple":
    case "kiwi":
    case "cherry":
    case "lemon":
    case "grapes":
        Console.WriteLine("friut");
        break;
    case "tomato":
    case "cucumber":
    case "pepper":
    case "carrot":
        Console.WriteLine("vegetable");
        break;
    default:
        Console.WriteLine("unknown");
        break;
}
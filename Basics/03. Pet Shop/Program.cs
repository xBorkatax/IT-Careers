int foodPackForDog = int.Parse(Console.ReadLine());
int foodPackForCat = int.Parse(Console.ReadLine());
double priceDog = 2.5;
double priceCat = 4;
double price = foodPackForDog * priceDog + priceCat * foodPackForCat;
Console.WriteLine($"{price} lv.");
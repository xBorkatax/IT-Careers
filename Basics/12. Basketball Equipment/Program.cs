int price = int.Parse(Console.ReadLine());

double sneakers = 0.60;
double team = 0.80;
double ball = 0.25;
double accessories = 0.20;

double sneakersPrice = price * sneakers;
double teamPrice = sneakersPrice * team;
double ballPrice = teamPrice * ball;
double accessoriesPrice = ballPrice * accessories;

double total = price + sneakersPrice + teamPrice + ballPrice + accessoriesPrice;
Console.WriteLine(total);

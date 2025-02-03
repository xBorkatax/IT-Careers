double chickenPrice = 10.35;
double fishPrice = 12.40;
double veganPrice = 8.15;

int chiken = int.Parse(Console.ReadLine());
int fish = int.Parse(Console.ReadLine());
int vegan = int.Parse(Console.ReadLine());

double sweet = 0.2;
double delivery = 2.50;

double chickenTotal = chickenPrice * chiken;
double fishTotal = fishPrice * fish;
double veganTotal = veganPrice * vegan;
double alltotal = chickenTotal + fishTotal + veganTotal;
double sweetPrice = alltotal * sweet;
double total = sweetPrice + delivery + alltotal;
Console.WriteLine(total);
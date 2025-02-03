double penPrice = 5.80;
double markerPrice = 7.20;
double preparationPrice = 1.20;

int pens = int.Parse(Console.ReadLine());
int markers = int.Parse(Console.ReadLine());
int preparation = int.Parse(Console.ReadLine());
int discount = int.Parse(Console.ReadLine());

double finalPenPrice = pens * penPrice;
double finalMarkerPrice = markers * markerPrice;
double finalPreparationPrice = preparation * preparationPrice;
double all = finalMarkerPrice + finalPenPrice + finalPreparationPrice;

double finalDiscount = all * discount / 100;
double price = all - finalDiscount;
Console.WriteLine(price);
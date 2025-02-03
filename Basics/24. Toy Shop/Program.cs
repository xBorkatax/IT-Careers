double priceVacation = double.Parse(Console.ReadLine());
int puzzles = int.Parse(Console.ReadLine());
int dolls = int.Parse(Console.ReadLine());
int bears = int.Parse(Console.ReadLine());
int minions = int.Parse(Console.ReadLine());
int trucks = int.Parse(Console.ReadLine());

double puzzlesPrice = 2.60;
int dollsPrice = 3;
double bearsPrice = 4.10;
double minionsPrice = 8.20;
int trucksPrice = 2;

int totalToys = puzzles + dolls + bears + minions + trucks;
double totalPrice = puzzles * puzzlesPrice + dolls * dollsPrice + bears * bearsPrice +minions * minionsPrice + trucks *  trucksPrice;

if (totalToys >= 50)
{
    double dis = 0.75;
    double rent = 0.9;
    double discount = totalPrice * dis;
    double total = discount * rent;
    if (total > priceVacation)
    {
        Console.WriteLine($"Yes! {total - priceVacation:F2} lv left.");
    }
    else
    {
        Console.WriteLine($"Not enough money! {priceVacation - total:F2} lv needed.");
    }
}
else
{
    double rent = 0.9;
    double total = totalPrice * rent;
    if (total > priceVacation)
    {
        Console.WriteLine($"Yes! {total - priceVacation:F2} lv left.");
    }
    else
    {
        Console.WriteLine($"Not enough money! {priceVacation - total:F2} lv needed.");
    }
}
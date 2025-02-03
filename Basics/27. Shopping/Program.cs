double buget = double.Parse(Console.ReadLine());
int videocards = int.Parse(Console.ReadLine());
int processors = int.Parse(Console.ReadLine());
int ramstick = int.Parse(Console.ReadLine());

int videocardPrice = 250;
double videocardsTotalPrice = videocardPrice * videocards;

double processorsPrice = videocardsTotalPrice * 0.35 * processors;
double ramsicksPrice = videocardsTotalPrice * 0.10 * ramstick;

double totalPrice = videocardsTotalPrice + ramsicksPrice + processorsPrice;
if (buget >= totalPrice)
{
    double rest = buget - totalPrice;
    Console.WriteLine($"You have {rest} leva left!");
}
else
{
    double needed = totalPrice - buget;
    Console.WriteLine($"Not enough money! You need {needed} leva more!");
}
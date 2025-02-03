string month = Console.ReadLine();
int days = int.Parse(Console.ReadLine());

double apartament = 0;
double studio = 0;

if (month == "May" || month == "October")
{
    studio = 50;
    apartament = 65;
    if (days > 7 && days < 14)
    {
        studio = studio * 0.95;    
    }
    else if (days > 14)
    {
        studio = studio * 0.70;
        apartament = apartament * 0.9;
    }
}
else if (month == "June" || month == "September")
{
    studio = 75.20;
    apartament = 68.70;
    if (days > 14)
    {
        studio = studio * 0.80;
        apartament = apartament * 0.9;
    }
}
else
{
    studio = 76;
    apartament = 77;
    if (days > 14)
    {
        apartament = apartament * 0.9;
    }
}

studio *= days;
apartament *= days;

Console.WriteLine($"Apartment: {apartament:F2}lv.");
Console.WriteLine($"Studio: {studio:F2}lv.");
int hourExam = int.Parse(Console.ReadLine());
int minuteExam = int.Parse(Console.ReadLine());
int hourArrival = int.Parse(Console.ReadLine());
int minuteArrival = int.Parse(Console.ReadLine());

double n = hourExam * 60;
double n2 = hourArrival * 60;
double totalMinutesExam = n + minuteExam;
double totalMinuteArivval = n2 + minuteExam;

if (totalMinutesExam > totalMinuteArivval)
{
    Console.WriteLine("On time");
}
else
{
    Console.WriteLine("Late");
}
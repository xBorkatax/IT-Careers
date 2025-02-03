using System.Xml;

double area = double.Parse(Console.ReadLine());
double priceForArea = 7.61;
double persentDiscount = 0.18;
double price = area * priceForArea;
double discount = price * persentDiscount;
double finalPrice = price - discount;
Console.WriteLine($"The final price is: {finalPrice} lv.");
Console.WriteLine($"The discount is: {discount} lv.");
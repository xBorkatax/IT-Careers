double nylonPrice = 1.5;
double paintPrice = 14.50;
double diluentPaintPrice = 5;

int nylon = int.Parse(Console.ReadLine());
int paint = int.Parse(Console.ReadLine());
int diluent = int.Parse(Console.ReadLine());
int time = int.Parse(Console.ReadLine());

double worker = 0.30;
double bagPrice = 0.40;
double aditionNylon = 2;
double aditionPaint = 0.10;

double priceAllNylon = (nylon + aditionNylon) * nylonPrice;
double priceAllPaint = (paint + (paint * aditionPaint)) * paintPrice;
double priceAllDiluentPaint = diluent * diluentPaintPrice;
double price = priceAllDiluentPaint + priceAllNylon + priceAllPaint + bagPrice;
double priceForWorkers = price * worker * time;
double total = price + priceForWorkers;
Console.WriteLine(total);
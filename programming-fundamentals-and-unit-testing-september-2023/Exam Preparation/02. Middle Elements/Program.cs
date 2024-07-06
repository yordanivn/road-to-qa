List <string> input=Console.ReadLine().Split(" ").ToList();
int middleIndexLeft=input.Count/2-1;
int middleIndexRight = input.Count / 2;

string middleLeftElement = input[middleIndexLeft];
string middleRightElement = input[middleIndexRight];

double num1=double.Parse(middleLeftElement);
double num2 = double.Parse(middleRightElement);
double average = (num1 + num2)/ 2.00;
Console.WriteLine($"{average:f2}");

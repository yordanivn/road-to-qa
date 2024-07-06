List <int> input=Console.ReadLine().Split(" ").Select(int.Parse).ToList();

int separator=int.Parse(Console.ReadLine());
double sum = 0;

for(int i=input.Count-1; i >= input.Count - separator; i--)
{
    sum += input[i];
}
double average = sum / separator;
Console.WriteLine($"{average:f2}");
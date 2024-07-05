int[] numbers=Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
//int[] numbers=Console.ReadLine().Split(" ").

int sum = 0;
for(int i = 0; i <=numbers.Length-1; i++)
{
    sum += numbers[i];
}
Console.WriteLine(sum);
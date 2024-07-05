List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

int rotation=int.Parse(Console.ReadLine());
for(int i=0;i<rotation;i++)
{
    numbers.Add(numbers[0]);
    numbers.RemoveAt(0);
}
Console.WriteLine(string.Join(" ",numbers));
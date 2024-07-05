List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

for (int i = 0; i < numbers.Count-1; i++)
{
    if (numbers[i] == numbers[i+1])
    {
        int sum = numbers[i] + numbers[i+1];
        numbers[i] = sum;
        numbers.RemoveAt(i+1);
        i = -1;
    }
}
Console.WriteLine(string.Join(" ", numbers));
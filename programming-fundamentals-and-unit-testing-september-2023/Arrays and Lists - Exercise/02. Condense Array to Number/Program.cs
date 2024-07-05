List <int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();


while(numbers.Count > 1)
{
    List<int> output = new List<int>();
    for (int i = 0; i < numbers.Count - 1; i++)
    {
        int num1 = numbers[i];
        int num2 = numbers[i + 1];
        int sum = num1 + num2;
        output.Add(sum);
    }
    numbers=output;
}

Console.WriteLine(string.Join(" ", numbers[0]));
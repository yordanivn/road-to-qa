string[] input = Console.ReadLine().Split(" ");

SortedDictionary<string, int> numberFreq = new();

foreach (string number in input)
{
    if(numberFreq.ContainsKey(number))
    {
        numberFreq[number]++;
    }
    else
    {
        numberFreq.Add(number, 1);
    }
}

foreach(var pair in numberFreq)
{
    Console.WriteLine($"{pair.Key} -> {pair.Value}");
}
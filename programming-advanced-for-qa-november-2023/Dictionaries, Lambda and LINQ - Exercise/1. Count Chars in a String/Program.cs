Dictionary<char, int> charecters = new();

string input = Console.ReadLine();

foreach (char ch in input)
{
    if(ch==' ')
    {
        continue;
    }
    if(charecters.ContainsKey(ch))
    {
        charecters[ch]++;
    }
    else
    {
        charecters.Add(ch, 1);
    }
}

foreach(KeyValuePair<char,int> pair in charecters)
{
    Console.WriteLine($"{pair.Key} -> {pair.Value}");
}
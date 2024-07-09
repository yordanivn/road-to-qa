string[] words = Console.ReadLine().Split(" ").Select(x=>x.ToLower()).ToArray();

Dictionary<string, int> output = new Dictionary<string, int>();

foreach (string word in words)
{
    if(output.ContainsKey(word))
    {
        output[word]++;
    }
    else
    {
        output.Add(word, 1);
    }
}

string[] result=output.Where(x=>x.Value %2 != 0).Select(x=>x.Key).ToArray();

Console.WriteLine(string.Join(" ",result));
Dictionary<string, int> resourcesDictionary = new();

string resource = Console.ReadLine();

while(resource!="stop")
{
    int quantity=int.Parse(Console.ReadLine());
    if(resourcesDictionary.ContainsKey(resource))
    {
        resourcesDictionary[resource] += quantity;
    }
    else
    {
        resourcesDictionary.Add(resource, quantity);
    }
    resource = Console.ReadLine();
}

foreach(KeyValuePair<string, int> pair in resourcesDictionary)
{
    Console.WriteLine($"{pair.Key} -> {pair.Value}");
}
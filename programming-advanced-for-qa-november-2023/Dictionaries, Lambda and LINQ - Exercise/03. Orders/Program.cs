Dictionary<string, List<decimal>> products = new();

string input = Console.ReadLine();

while(input!="buy")
{
    string[] inputArray = input.Split();
    string productName = inputArray[0];
    decimal price = decimal.Parse(inputArray[1]);
    decimal quantity = decimal.Parse(inputArray[2]);

    if (products.ContainsKey(productName))
    {
        products[productName][0] = price;
        products[productName][1] += quantity;
    }
    else
    {
        products.Add(productName, new() { price, quantity });
    }
    input = Console.ReadLine();
}
foreach(KeyValuePair<string,List<decimal>> pair in products)
{
    Console.WriteLine($"{pair.Key} ->" 
        + $"{(pair.Value[0] * pair.Value[1]):f2}");
}
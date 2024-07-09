Dictionary<string, List<decimal>> products = new();

string input = Console.ReadLine();

while(input != "buy")
{
    string[] intputArr = input.Split();
    string productName = intputArr[0];
    decimal price = decimal.Parse(intputArr[1]);
    decimal quantity = decimal.Parse(intputArr[2]);

    if(products.ContainsKey(productName))
    {
        products[productName][0] = price;
        products[productName][1]+=quantity;
    }
    else
    {
        products.Add(productName, new() { price, quantity});
    }
    input = Console.ReadLine();
}

foreach(KeyValuePair<string, List<decimal>> currentItem in products)
{
    Console.WriteLine($"{currentItem.Key} -> " + 
        $"{(currentItem.Value[0] * currentItem.Value[1]):f2}");
}
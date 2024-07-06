using System;
using System.Collections.Generic;

int numberOfProducts=int.Parse(Console.ReadLine());
List <string> products = new List<string> ();
for (int i=0; i<numberOfProducts; i++)
{
    string product = Console.ReadLine();
    products.Add(product);
}
products.Sort();

int count = 1;
foreach (string product in products)
{
    Console.WriteLine(count + "." + product);
    count++;
}

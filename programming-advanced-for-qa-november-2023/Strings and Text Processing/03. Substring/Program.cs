string removeWord = Console.ReadLine();
string input=Console.ReadLine();

while(input.Contains(removeWord))
{
    input = input.Replace(removeWord, "");
}
Console.WriteLine(input);
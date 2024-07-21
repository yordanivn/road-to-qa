using System.Text;

string input = Console.ReadLine();
StringBuilder digits = new();
StringBuilder letters = new();
StringBuilder others = new();

foreach(char symbol in input)
{
    if(char.IsDigit(symbol))
    {
        digits.Append(symbol);
    }
    else if (char.IsLetter(symbol)) 
    {
        letters.Append(symbol);
    }
    else 
    { 
        others.Append(symbol); 
    }
}
Console.WriteLine(digits);
Console.WriteLine(letters);
Console.WriteLine(others);
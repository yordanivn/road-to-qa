List <string> numbers=Console.ReadLine().Split(" ").ToList();
int sum = 0;
foreach (string element in numbers)
{
    try
    {
        int input = int.Parse(element);
        sum += input;
        
       // throw new FormatException();
        //throw new OverflowException();
    }
    catch(FormatException)
    {
        Console.WriteLine($"The element '{element}' is in wrong format!");
    }
    catch(OverflowException)
    {
        Console.WriteLine($"The element '{element}' is out of range!");
    }
   finally
    {
        Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
    }
}
Console.WriteLine($"The total sum of all integers is: {sum}");

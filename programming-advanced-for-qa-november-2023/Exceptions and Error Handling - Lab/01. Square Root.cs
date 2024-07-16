try
{
    int n = int.Parse(Console.ReadLine());
    if (n < 0)
    {
        throw new ArgumentException();
    }

    double result = Math.Sqrt(n);
    Console.WriteLine(result);
}
catch(ArgumentException)
{
    Console.WriteLine("Invalid number.");
}
Console.WriteLine("Goodbye.");
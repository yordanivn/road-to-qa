namespace _04._Food_or_Drink
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String product=Console.ReadLine();
            if (product == "curry" || product== "noodles" || product== "sushi" || product== "spaghetti" || product=="bread") Console.WriteLine("food");
            else if (product =="tea" || product=="water" || product=="coffee" || product=="juice") Console.WriteLine("drink");
            else Console.WriteLine("unknown");
        }
    }
}
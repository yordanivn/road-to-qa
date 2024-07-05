namespace _01._Market_Place
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String productName=Console.ReadLine();
            string day=Console.ReadLine();
            if(productName=="Bannana")
            {
                if(day=="Weekday")
                    Console.WriteLine("2.50");
                else if (day=="Weekend")
                    Console.WriteLine("2.70");
            }
            else if(productName=="Apple")
            {
                if(day=="Weekday")
                    Console.WriteLine("1.30");
                else if (day == "Weekend")
                    Console.WriteLine("1.60");
            }
            else if (productName == "Kiwi")
            {
                if (day=="Weekday")
                    Console.WriteLine("2.20");
                else if (day == "Weekend")
                    Console.WriteLine("3.00");
            }
                

        }
    }
}
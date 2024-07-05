namespace _08._Account_Balance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double balance = 0;
            while (true)
            {
                String input=Console.ReadLine();
                if (input == "End")
                {
                    Console.WriteLine($"Balance: {balance:f2}");
                    break;
                }
                double number=double.Parse(input);
                if (number > 0)
                {
                    Console.WriteLine($"Increase: {number:f2}");
                    balance += number;
                }
                else
                {
                    Console.WriteLine($"Decrease: {-number:f2}");
                    balance += number;
                }
            }
            
        }
    }
}
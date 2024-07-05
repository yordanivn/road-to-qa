namespace _05._Vacation_Expenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String Season=Console.ReadLine();
            String accType=Console.ReadLine();
            int days=int.Parse(Console.ReadLine());
            double totalPrice = 0;
            switch(Season)
            {
                case "Spring":
                    if(accType=="Hotel")
                    {
                        totalPrice = (30 * days) * 0.80;
                    }
                    else if(accType=="Camping")
                    {
                        totalPrice = (10 * days) * 0.80;
                    }
                    break;
                case "Summer":
                    if (accType == "Hotel")
                    {
                        totalPrice = (50 * days);
                    }
                    else if (accType == "Camping")
                    {
                        totalPrice = (30 * days);
                    }
                    break;
                case "Autumn":
                    if (accType == "Hotel")
                    {
                        totalPrice = (20 * days) * 0.70;
                    }
                    else if (accType == "Camping")
                    {
                        totalPrice = (15 * days) * 0.70;
                    }
                    break;
                case "Winter":
                    if (accType == "Hotel")
                    {
                        totalPrice = (40.00 * days) * 0.90;
                    }
                    else if (accType == "Camping")
                    {
                        totalPrice = (10 * days) * 0.90;
                    }
                    break;

            }
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
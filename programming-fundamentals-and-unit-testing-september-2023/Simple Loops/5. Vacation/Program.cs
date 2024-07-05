namespace _5._Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int neededMoney = int.Parse(Console.ReadLine());
            int ownedMoney = int.Parse(Console.ReadLine());
            int consDays = 0;
            int totalDays = 0;
            bool isMoneyEnough = false;
            while (ownedMoney < neededMoney)
            {
                String actionType = Console.ReadLine();
                int amount = int.Parse(Console.ReadLine());
                totalDays++;
                if (actionType == "spend")
                {
                    ownedMoney = ownedMoney - amount;
                    if (ownedMoney < 0) ownedMoney = 0;
                    consDays++;
                    if (consDays == 5)
                    {
                        Console.WriteLine("You can't save the money.");
                        Console.WriteLine(totalDays);
                        break;
                    }

                }
                else if (actionType == "save")
                {
                    ownedMoney = ownedMoney + amount;
                    consDays = 0;

                }
                // if (neededMoney <= availableMoney) isMoneyEnough = true;
                // }

                //  if(isMoneyEnough)

            }
            
            
            if (ownedMoney >= neededMoney)
                Console.WriteLine($"You saved the money for {totalDays} days.");
        }
    }
}

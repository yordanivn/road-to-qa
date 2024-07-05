namespace _7._Coins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double oneLev = 1.00;
            double lev = 0;
            double changeAmount = double.Parse(Console.ReadLine());
            int integerPart = (int)changeAmount;
            double decimalPart = changeAmount - Math.Floor(changeAmount);
            double roundedDecimalPart = Math.Round(decimalPart, 2);
            int numberOfCoins = 0;
            while ()
            {
                if (integerPart == 1) numberOfCoins++;
                else if (integerPart == 2) numberOfCoins++;
            }
        }
    }
}
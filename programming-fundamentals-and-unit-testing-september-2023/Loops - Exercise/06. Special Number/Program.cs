namespace _06._Special_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int number=int.Parse(Console.ReadLine());
            int startingNUmber = number;
            bool isSpecial = true;

            while (number>0)
            {
                int lastDigit = number % 10;
                if (startingNUmber % lastDigit != 0)
                {
                    isSpecial = false;
                    break;
                }
                number = number / 10;
            }
            if(isSpecial==true) 
            { Console.WriteLine($"{startingNUmber} is special"); }

            else { Console.WriteLine($"{startingNUmber} is not special"); }
        }
    }
}
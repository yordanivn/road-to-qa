namespace _03._Biggest_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int amountOfNumber=int.Parse(Console.ReadLine());
            int maxValue = int.MinValue;
            for (int i = 0; i < amountOfNumber; i++)
            {
                int number=int.Parse((Console.ReadLine()));
                if(number > maxValue)
                {
                    maxValue= number;
                }

            }
            Console.WriteLine(maxValue);
        }
    }
}
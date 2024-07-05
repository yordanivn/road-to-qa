namespace _06._Special_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int stopNumber = int.Parse(Console.ReadLine());
            double lastNumber = 0;
            double previousNumber = 0.0;
            while (true)
            {
                int value = int.Parse(Console.ReadLine());
                if (value == stopNumber)
                {
                    lastNumber = previousNumber * 1.2;
                    break;
                }
                previousNumber = value;
            }
            Console.WriteLine(lastNumber);
        }
    }
}
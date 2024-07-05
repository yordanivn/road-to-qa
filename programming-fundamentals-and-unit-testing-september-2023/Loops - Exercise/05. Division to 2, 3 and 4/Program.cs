namespace _05._Division_to_2__3_and_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int amountOfNumber=int.Parse(Console.ReadLine());
            int count2 = 0;
            int count3 = 0;
            int count4 = 0;
            for (int i = 1; i <= amountOfNumber; i++)
            {
                int value = int.Parse(Console.ReadLine());
                if(value %2==0) count2++;
                if(value %3==0) count3++;
                if(value %4==0) count4++;
            }
            double percentage2 = count2*1.0/amountOfNumber*100;
            double percentage3 = count3*1.0 / amountOfNumber * 100;
            double percentage4 = count4*1.0 / amountOfNumber * 100;
            Console.WriteLine($"{percentage2:f2}%");
            Console.WriteLine($"{percentage3:f2}%");
            Console.WriteLine($"{percentage4:f2}%");
        }
    }
}
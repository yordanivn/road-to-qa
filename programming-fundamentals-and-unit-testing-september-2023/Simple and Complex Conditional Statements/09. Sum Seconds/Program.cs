namespace _09._Sum_Seconds
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int num1=int.Parse(Console.ReadLine());
           int num2=int.Parse(Console.ReadLine());
           int num3=int.Parse(Console.ReadLine());
            int sumTime = num1 + num2 + num3;
            int minutes=sumTime/60;
            int seconds=sumTime%60;
            String leadingZero = "";
            if(seconds<10)
                leadingZero = "0";
            Console.WriteLine($"{minutes}:{leadingZero}{seconds}");
        }
    }
}
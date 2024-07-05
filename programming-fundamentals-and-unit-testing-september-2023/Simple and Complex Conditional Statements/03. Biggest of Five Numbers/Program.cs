namespace _03._Biggest_of_Five_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1=int.Parse(Console.ReadLine());
            int num2=int.Parse(Console.ReadLine());
            int num3=int.Parse(Console.ReadLine());
            int num4=int.Parse(Console.ReadLine());
            int num5=int.Parse(Console.ReadLine());
            int biggest = num1; ;
            for(int i = 0; i < 5;i++)
            {
                if(biggest<num2) biggest = num2;
                if(biggest<num3) biggest = num3;
                if(biggest<num4) biggest = num4;
                if(biggest<num5) biggest = num5;
            }
            Console.WriteLine(biggest);
        }
    }
}
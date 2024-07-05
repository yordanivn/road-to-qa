namespace _04._Number_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1=int.Parse(Console.ReadLine());
            int num2=int.Parse(Console.ReadLine());
            String mathOperator=Console.ReadLine();
            if(mathOperator =="+") Console.WriteLine($"{num1} {mathOperator} {num2} = {(num1+num2):f2}");
            if(mathOperator =="-") Console.WriteLine($"{num1} {mathOperator} {num2} = {(num1-num2):f2}");
            if(mathOperator =="*") Console.WriteLine($"{num1} {mathOperator} {num2} = {(num1*num2):f2}");
            if(mathOperator =="/") Console.WriteLine($"{num1} {mathOperator} {num2} = {(num1/num2):f2}");
        }
    }
}
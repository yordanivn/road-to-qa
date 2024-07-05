namespace _02._Largest_Number_Out_Of_Three
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber=int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            if (firstNumber > secondNumber) 
            {
                if(firstNumber>thirdNumber) Console.WriteLine(firstNumber);
                else Console.WriteLine(thirdNumber);
            }
            else 
                if (secondNumber> thirdNumber)
                    {
                        Console.WriteLine(secondNumber);
                    }
            else Console.WriteLine(thirdNumber);
        }
    }
}
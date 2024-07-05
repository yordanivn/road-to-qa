namespace _08._Invalid_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number=int.Parse(Console.ReadLine());
            bool isValid = false;
            if(number == 0)
            {
                isValid = true;
            }
            else if(number<100 || number>200) Console.WriteLine("invalid");
        }
    }
}
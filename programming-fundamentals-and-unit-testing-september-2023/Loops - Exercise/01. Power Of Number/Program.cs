namespace _01._Power_Of_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int n=int.Parse(Console.ReadLine());
           int p=int.Parse(Console.ReadLine());
            int result = 1;
            for(int i=1; i<=p; i++)
            {
                result = result * n;
                
            }
            Console.WriteLine(result);
        }
    }
}
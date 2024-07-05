namespace _04._Numbers_Ending_in_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());
            int sum = 7;
            for (int i = 7; i <= n; i=i+10)
            {
                
               Console.WriteLine(sum);
               sum += 10;
            }
        }
    }
}
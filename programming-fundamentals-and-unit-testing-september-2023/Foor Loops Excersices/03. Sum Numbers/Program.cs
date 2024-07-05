namespace _03._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count=int.Parse(Console.ReadLine());
            double sum = 0;
            for(int i = 1; i <= count; i++)
            {
                double n = double.Parse(Console.ReadLine());
                sum += n;
            }
            Console.WriteLine(sum);
        }
    }
}
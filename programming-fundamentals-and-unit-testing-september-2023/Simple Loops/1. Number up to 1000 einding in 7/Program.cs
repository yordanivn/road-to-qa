namespace _1._Number_up_to_1000_einding_in_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for(int i=7;i<=997;i++)
            {
                if (i % 10 == 7) Console.WriteLine(i);
            }
        }
    }
}
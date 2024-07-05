namespace _2._2_Half_Sum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int max = int.MinValue;
            for(int i=0; i < n;i++)
            {
                int number=int.Parse(Console.ReadLine());
                sum += number;
                if(number>max) max = number;
            }
            int sumWithOutMax = sum - max;
            if(max==sumWithOutMax) 
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {max}");
            }
            else
            {
                int diff = Math.Abs(max - sumWithOutMax);
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {diff}");
            }
        }
    }
}
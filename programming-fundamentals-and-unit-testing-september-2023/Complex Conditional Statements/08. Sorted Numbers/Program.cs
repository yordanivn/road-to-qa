namespace _08._Sorted_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int first=int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());
            if (first > second && second>third) 
            {
                Console.WriteLine("Descending");
                
            } 
           else if(first<second && second < third)
            {
                Console.WriteLine("Ascending");
            }
            else Console.WriteLine("Not sorted");
        }
    }
}
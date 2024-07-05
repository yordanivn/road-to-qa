namespace _3._3_Old_Books
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String favBook=Console.ReadLine();
            int count = 0;
            bool isFind = false;
            String nextBook=Console.ReadLine();
            while(nextBook!= "No More Books")
            {
                if(favBook==nextBook)
                {
                    isFind= true;
                    break;
                }
                count++;
                nextBook = Console.ReadLine();
            }
            if(isFind) 
            {
                Console.WriteLine($"You checked {count} books and found it.");
            }
            else
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {count} books.");
            }
        }
    }
}
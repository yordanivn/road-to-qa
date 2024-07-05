using static System.Reflection.Metadata.BlobBuilder;

namespace _3._Old_Books
{
    internal class Program
    {
        static void Main(string[] args)
        {
           String favBook=Console.ReadLine();
           int count = 0;
           bool isBookFind = false;
           String nextBookName = Console.ReadLine();
           while(nextBookName != "No More Books") 
            {
                if(nextBookName==favBook)
                {
                    isBookFind = true;
                    break;
                }
                count++;
                nextBookName=Console.ReadLine();
            }
            if (isBookFind)
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
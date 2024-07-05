namespace _04._Vowel_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfCharecters=int.Parse(Console.ReadLine());
            int results = 0;
            for (int i = 0; i < countOfCharecters; i++)
            {
                String vowel=Console.ReadLine();
                if (vowel == "a") results += 1;
                else if(vowel == "e") results += 2;
                else if(vowel == "i") results += 3;
                else if(vowel == "o") results += 4;
                else if(vowel == "u") results += 5;
            }
            Console.WriteLine(results);
        }
    }
}
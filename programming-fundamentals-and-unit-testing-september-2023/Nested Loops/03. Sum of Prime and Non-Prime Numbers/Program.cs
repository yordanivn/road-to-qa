namespace _03._Sum_of_Prime_and_Non_Prime_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sumOfPrime = 0;
            int sumOfNonPrime = 0;
            while(true)
            {
                String input=Console.ReadLine();
                if (input == "stop") break;
                int number=int.Parse(input);
                if(number <0) 
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }
                int devisors = 0;
                for(int i = 1;i<=number;i++) 
                {
                    if(number%i == 0)
                    {
                        devisors++;
                    }
                }
                if (devisors == 2) sumOfPrime += number;
                else sumOfNonPrime += number;
            }
            Console.WriteLine($"Sum of all prime numbers is: {sumOfPrime}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumOfNonPrime}"
);

        }
    }
}
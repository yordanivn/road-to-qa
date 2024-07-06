using System;

class Program
{
    static void Main()
    {
        
        int count = int.Parse(Console.ReadLine());

        int primeSum = 0;

        for (int i = 1; i <= count; i++)
        {
            
            int number = int.Parse(Console.ReadLine());

            if (IsPrime(number))
            {
                primeSum += number;
            }
        }

        Console.WriteLine($"{primeSum}");
    }

    static bool IsPrime(int n)
    {
        if (n <= 1)
        {
            return false;
        }

        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
            {
                // If n is divisible by any number between 2 and the square root of n, it's not a prime number.
                return false;
            }
        }

        // If no divisors were found, the number is a prime number.
        return true;
    }
}

int number = int.Parse(Console.ReadLine());
int startingNumber = number;
int lastDigit = 0;
int sum = 0;
while (true)
{
    lastDigit = number % 10;
    number = number / 10;
    if(lastDigit%2==0)
    {
        int factorial = 1;
                for (int i = 1; i <= lastDigit; i++)
                {
                    factorial *= i;
                }
        sum += factorial;
    }
    if (number <= 0) break;
}
Console.WriteLine(sum);

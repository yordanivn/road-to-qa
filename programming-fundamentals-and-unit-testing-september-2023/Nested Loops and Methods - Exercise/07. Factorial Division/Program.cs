static int FirstFactorialDevidedToSecondFactorial(int firstNumber,int secondNumber)
{
    int firstFact = FirstFactorial(firstNumber);
    int secondFact = SecondFactorial(secondNumber);
    int output = firstFact / secondFact;
    return output;
}

static int FirstFactorial(int number)
{
    int factorial = 1;
    for(int i=number;i>0;i--)
    {
        factorial *= i;
    }
    return factorial;
}static int SecondFactorial(int number)
{
    int factorial = 1;
    for(int i=number;i>0;i--)
    {
        factorial *= i;
    }
    return factorial;
}

int firstNumber=int.Parse(Console.ReadLine());
int secondNumber=int.Parse(Console.ReadLine());
int result = FirstFactorialDevidedToSecondFactorial(firstNumber,secondNumber);
Console.WriteLine(result);
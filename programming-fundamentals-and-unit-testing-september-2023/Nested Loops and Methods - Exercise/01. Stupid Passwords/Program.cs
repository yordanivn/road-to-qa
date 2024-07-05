int number=int.Parse(Console.ReadLine());
for(int firstNumber=2;firstNumber<=number;firstNumber+=2)
{
    for(int secondNumber=1;secondNumber<=number;secondNumber+=2)
    {
        Console.Write($"{firstNumber}{secondNumber}{firstNumber*secondNumber} ");
    }
}
int n=int.Parse(Console.ReadLine());

//digit1 [1-9]
//digit2 [0-9]
//digit3 [0-9]
for(int firstDigit=1; firstDigit<=9; firstDigit++)
{
    for(int secondDigit=0; secondDigit<=9; secondDigit++)
    {
        for(int thirdDigit=0; thirdDigit<=9; thirdDigit++)
        {
            if(firstDigit*secondDigit*thirdDigit==n)
            {
                Console.Write($"{firstDigit}{secondDigit}{thirdDigit} ");
            }
        }
    }    
}
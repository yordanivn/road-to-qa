int max1=int.Parse(Console.ReadLine());
int max2=int.Parse(Console.ReadLine());
int max3=int.Parse(Console.ReadLine());
//digit1 [1-9]
//digit2 [0-9]
//digit3 [0-9] 2,3,5,7
for (int firstDigit = 2; firstDigit <= max1; firstDigit+=2)
{
    for (int secondDigit = 1; secondDigit <= max2; secondDigit++)
    {
        for (int thirdDigit = 2; thirdDigit <= max3; thirdDigit+=2)
        {
            if(secondDigit==2 || secondDigit ==3 || secondDigit ==5 || secondDigit ==7)
            {
                Console.WriteLine($"{firstDigit}{secondDigit}{thirdDigit}");
            }
        }
    }
}
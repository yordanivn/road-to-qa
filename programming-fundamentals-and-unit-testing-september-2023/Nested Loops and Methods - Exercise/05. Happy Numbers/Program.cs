int number=int.Parse(Console.ReadLine());

for(int digit1=1; digit1<9; digit1++)
{
    for(int digit2=0; digit2<9; digit2++)
    {
        for (int digit3 = 0; digit3 < 9; digit3++)
        {
            for(int digit4 = 0;digit4 < 9; digit4++)
            {
                if(digit1+digit2==number && digit3+digit4==number)
                {
                    Console.Write($"{digit1}{digit2}{digit3}{digit4} ");
                }
            }
        }
    }
}
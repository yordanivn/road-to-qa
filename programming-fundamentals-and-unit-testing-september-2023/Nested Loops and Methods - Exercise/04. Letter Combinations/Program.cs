char startLetter=char.Parse(Console.ReadLine());
char endLetter=char.Parse(Console.ReadLine());
char exclLetter=char.Parse(Console.ReadLine());
int count = 0;

for (int letter1 = startLetter; letter1 <= endLetter; letter1++)
{
    for(int letter2 = startLetter; letter2 <= endLetter; letter2++)
    {
        for(int letter3 = startLetter; letter3 <= endLetter; letter3++)
        {
            if (letter1 != exclLetter && letter2 != exclLetter && letter3!=exclLetter)
            {
                Console.Write($"{(char)letter1}{(char)letter2}{(char)letter3} ");
                count++;
            }
        }
    }
}
Console.WriteLine();
Console.WriteLine(count);
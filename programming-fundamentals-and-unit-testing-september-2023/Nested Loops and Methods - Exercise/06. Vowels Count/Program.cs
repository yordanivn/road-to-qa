static void CountOfVowels(String input)
{
    int count = 0;
    for(int i=0;i<input.Length;i++)
    {
        char symbol = char.ToLower(input[i]);
        switch(symbol)
        {
            case 'a': 
            case 'A': 
            case 'e': 
            case 'E':
            case 'i':
            case 'I':
            case 'o':
            case 'O':
            case 'u':
            case 'U':
            count++; 
            break;
        }
    }
    Console.WriteLine(count);
}

String input=Console.ReadLine();
CountOfVowels(input);

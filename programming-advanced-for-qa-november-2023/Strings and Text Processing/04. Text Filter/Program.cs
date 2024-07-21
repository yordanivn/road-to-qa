string[] bannedWords = Console.ReadLine().Split(", ");
string text=Console.ReadLine();

foreach(string bannedWord in bannedWords)
{
    string censoredWord = new string('*', bannedWord.Length);

    while(text.Contains(bannedWord))
    {
        text = text.Replace(bannedWord, censoredWord);
    }
}
Console.WriteLine(text);

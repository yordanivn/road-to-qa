string word = Console.ReadLine();

while(word!="end")
{
    char[] wordArray = word.ToCharArray();
    Array.Reverse(wordArray);
    string revesedWord=new string(wordArray);
    Console.WriteLine($"{word} = {revesedWord}");
    word = Console.ReadLine();
}
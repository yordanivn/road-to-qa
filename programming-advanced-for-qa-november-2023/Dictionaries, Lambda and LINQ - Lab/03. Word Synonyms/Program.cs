using System.Net.Http.Headers;

int countOfWords = int.Parse(Console.ReadLine());
//List <string> synonyms = new List<string>();

Dictionary<string, List<string>> synonyms = new Dictionary<string, List<string>>();


for (int i=0; i<countOfWords; i++)
{
    string word=Console.ReadLine();
    string synonym = Console.ReadLine();

    if (synonyms.ContainsKey(word))
    {
        synonyms[word].Add(synonym);
    }
    else
    {
        synonyms.Add(word, new List<string> { synonym });
    }
}
foreach(var pair in synonyms)
{
    Console.WriteLine($"{pair.Key} - {string.Join(", ",pair.Value)}");
}

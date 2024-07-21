using System.Text;

string[] input = Console.ReadLine().Split(" ");
StringBuilder output=new StringBuilder();
for(int i=0;i<input.Length;i++)
{
    string currentWord = input[i];
    for(int j=0;j<currentWord.Length;j++)
    {
        output.Append(currentWord);
    }    
}
Console.WriteLine(output);
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Linq;

namespace _02._Articles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            int commandNumber=int.Parse(Console.ReadLine());
            string inputTitle = input[0];
            string inputContent = input[1];
            string inputAuthor = input[2];
            Article currentArticle = new(inputTitle, inputContent, inputAuthor);

            for (int i = 0; i < commandNumber; i++)
            {
                string command=Console.ReadLine();
                string[] commandParts = command.Split(": ");
                string commandName = commandParts[0];
                string commandParameter = commandParts[1];
                
                switch (commandName)
                {
                    case "Edit":
                        currentArticle.Edit(commandParameter);
                        break;

                    case "ChangeAuthor":
                        currentArticle.ChangeAuthor(commandParameter);
                        break;
                    case "Rename":
                        currentArticle.Rename(commandParameter);
                        break;
                }
            }
            Console.WriteLine($"{currentArticle.Title} - {currentArticle.Content}: {currentArticle.Author}");

        }
    }
}

class Article
{
    public Article()

    {

    }
    public Article(string title,string content,string author)
    {
        Title=title;
        Content=content;
        Author=author;
    }
    public void Edit(string newContent)
    {
        Content= newContent;
    }

    public void ChangeAuthor(string newAuthor)
    {
        Author= newAuthor;
    }
    public void Rename(string newTitle)
    {
        Title= newTitle;
    }
    //string title;
    //string content;
    //string author;
    public string Title { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }
    //public string PrintToString()
    //{
    //    return $"{this.Title} - {this.Content}: {this.Author}";
    //}

}
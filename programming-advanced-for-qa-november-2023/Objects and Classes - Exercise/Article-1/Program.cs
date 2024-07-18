namespace Article_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] inputArr = input.Split(", ");
                string title = inputArr[0];
                string content= inputArr[1];
                string author= inputArr[2];

                string command = Console.ReadLine();
                string[] commandArr = command.Split(": ");
                string commandFunction = commandArr[0];
                string commandData= commandArr[1];

                Articles currentArticle =new Articles(title,content,author);
                switch(commandFunction)
                {
                    case "Edit":
                        currentArticle.Edit(commandData);
                        break;
                    case "ChangeAuthor":
                        currentArticle.ChangeAuthor(commandData);
                        break;
                    case "Rename":
                        currentArticle.Rename(commandData);
                        break;
                }
                Console.WriteLine($"{currentArticle.Title}, {currentArticle.Content}, {currentArticle.Author}");
            }
        }
    }
}

class Articles
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }

    public Articles(string title,string content,string author)
    {
        Title = title;
        Content = content;
        Author = author;
    }
    public void Edit (string newContent)
    {
        Content=newContent;
    }
    public void ChangeAuthor(string newAuthor)
    {
        Author = newAuthor;
    }
    public void Rename(string newTitle)
    {
        Title = newTitle;
    }
}
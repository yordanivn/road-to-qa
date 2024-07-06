List <int> listNumbers=Console.ReadLine().Split(" ").Select(int.Parse).ToList();

string command=Console.ReadLine();

while(command != "end")
{
    if(command.StartsWith("Add"))
    {
        int numberToAdd=int.Parse(command.Split(" ")[1]);
        listNumbers.Add(numberToAdd);
    }
    else if (command.StartsWith("RemoveAt"))
    {
        int numberToRemoveAt = int.Parse(command.Split(" ")[1]);
        listNumbers.RemoveAt(numberToRemoveAt);
    }
    else if(command.StartsWith("Remove"))
    {
        int numberToRemove = int.Parse(command.Split(" ")[1]);
        listNumbers.Remove(numberToRemove);
    }
    
    else if(command.StartsWith("Insert"))
    {
        int numberToInsert = int.Parse(command.Split(" ")[1]);
        int indexNumberToInsert = int.Parse(command.Split(" ")[2]);
        listNumbers.Insert(indexNumberToInsert, numberToInsert);
    }
    command= Console.ReadLine();
}
Console.WriteLine(string.Join(" ",listNumbers));
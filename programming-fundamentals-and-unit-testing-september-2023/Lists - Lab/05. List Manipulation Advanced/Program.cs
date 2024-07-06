List<int> numbersList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

List<int> evenNumbers = new List <int>();
List<int> oddNumbers = new List <int>();

string command = Console.ReadLine();
foreach (int number in numbersList)
{
    if(number %2==0)
        evenNumbers.Add(number);
    else 
        oddNumbers.Add(number);
}
int sum = 0;
foreach (int number in numbersList)
{
    sum += number;
}
while(command!="end")
{
    
    //int evenNumbers = numbersList.RemoveAll(number => number % 2 == 0);

    if(command.StartsWith("Contains"))
    {
        int numberToContain = int.Parse(command.Split(" ")[1]);
        if(numbersList.Contains(numberToContain)==true)
        {
            Console.WriteLine("Yes");
            
        }
        else
        {
            Console.WriteLine("No such number");
            
        }
    }
    else if(command.StartsWith("PrintEven"))
    {   

        Console.WriteLine(string.Join(" ",evenNumbers));
    }
    else if (command.StartsWith("PrintOdd"))
    {
        Console.WriteLine(string.Join(" ", oddNumbers));
    }
    else if (command.StartsWith("GetSum"))
    {
        Console.WriteLine(sum);
    }
    else if (command.StartsWith("Filter"))
    {
        string condition=command.Split(" ")[1];
        int numberToFilter = int.Parse(command.Split(" ")[2]);
        if(condition=="<")
        {
            numbersList.RemoveAll(number=>number>=numberToFilter);
        }
        else if(condition==">")
        {
            numbersList.RemoveAll(number => number <= numberToFilter);
        }
        else if (condition == ">=")
        {
            numbersList.RemoveAll(number => number <numberToFilter);
        }
        else if (condition == "<=")
        {
            numbersList.RemoveAll(number => number > numberToFilter);
        }

    }
    command = Console.ReadLine();
}
Console.WriteLine(string.Join(" ",numbersList));
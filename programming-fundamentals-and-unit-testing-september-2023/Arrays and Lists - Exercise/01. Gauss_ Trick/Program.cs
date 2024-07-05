List <int> numbers=Console.ReadLine().Split(" ").Select(int.Parse).ToList();

int counter = 1;
List<int> updatedList = new List<int>();
for (int i=0; i<=numbers.Count-1; i++)
{
    {
        updatedList.Add(numbers[0] + numbers[numbers.Count - 1]);
        numbers.RemoveAt(0);
        numbers.RemoveAt((int)numbers.Count-1);
    }
   
}
if(numbers.Count > 0)
{
    Console.WriteLine(string.Join(" ", updatedList) + " " + numbers[0]);
}
else
{
    Console.WriteLine(string.Join(" ", updatedList));
}


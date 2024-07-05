List<int> firstList = new List<int>();
List<int> secondList = new List<int>();

int count = int.Parse(Console.ReadLine());
for (int i = 0; i < count; i++)
{
    List<int> input = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
    if(i%2==0)
    {
        firstList.Add(input[0]);
        secondList.Add(input[1]);
    }
    else
    {
        secondList.Add(input[0]);
        firstList.Add(input[1]);
    }
}
Console.WriteLine(string.Join(" ", firstList));
Console.WriteLine(string.Join(" ", secondList));
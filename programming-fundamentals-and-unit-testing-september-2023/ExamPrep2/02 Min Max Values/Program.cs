int[]input= Console.ReadLine().Split().Select(int.Parse).ToArray();
int indexToRemove = int.Parse(Console.ReadLine());
int min = int.MaxValue;
int max = int.MinValue;
for (int i = 0; i < indexToRemove; i++)
{
    if (max < input[i])
    {
        max = input[i];
    }
    if(min> input[i])
    {
        min = input[i];
    }
}

Console.WriteLine(max);
Console.WriteLine(min);

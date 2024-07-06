List <int> numbers=Console.ReadLine().Split(" ").Select(int.Parse).ToList();
numbers.RemoveAll(number => number < 0);
numbers.Reverse();
if(numbers.Count > 0)
{
    Console.WriteLine(string.Join(" ",numbers));
}
else
{
    Console.WriteLine("empty");
}
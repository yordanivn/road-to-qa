List  <int> input=Console.ReadLine().Split(" ").Select(int.Parse).ToList();

int compareNumber=int.Parse(Console.ReadLine());
var biggerNumbers = input.Where(n => n > compareNumber);
foreach(var bigger in biggerNumbers)
{
    Console.Write(bigger+" ");
}



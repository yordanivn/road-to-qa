using System.Security.Cryptography.X509Certificates;

List<int> firstInput = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
List<int> secondInput = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

List <int> output = new List<int>();
int longerList=Math.Max(firstInput.Count, secondInput.Count);

for(int i=0;i<longerList; i++)
{
    if (i < firstInput.Count)
    {
        int num1 = firstInput[i];
        output.Add(num1);
    }
    if(i< secondInput.Count)
    {
        int num2 = secondInput[i];
        output.Add(num2);
    }
    
}
Console.WriteLine(string.Join(" ",output));
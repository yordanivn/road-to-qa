List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

List <int> output= new List<int>();

for(int i=0; i<numbers.Count-1; i++)
{
    if (numbers[i] == numbers[i+1])
    {
        for(int j=i; j<numbers.Count-1; j++)
        {
           
           if( numbers[i] == numbers[j+1])
            {
                output.Add(numbers[i]);
                
            }
        }
    }
}
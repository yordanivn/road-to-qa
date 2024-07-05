int[] array1=Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
int[] array2=Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
bool isIdentical = true;

for(int index=0;index<=array1.Length-1;index++)
{
        if (array1[index] != array2[index])
        {
            isIdentical = false;
            Console.WriteLine("Arrays are not identical.");
            break;
        }

}
if(isIdentical)
{
    Console.WriteLine("Arrays are identical.");
}

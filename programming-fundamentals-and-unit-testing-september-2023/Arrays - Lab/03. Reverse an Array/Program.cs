int lenghth=int.Parse(Console.ReadLine());
int[] numbers=new int[lenghth];
for(int index=0;index<= lenghth-1; index++)
{
    int input = int.Parse(Console.ReadLine());
    numbers[index]= input;
}
for (int index = lenghth - 1; index >= 0; index--)
{
    Console.Write(numbers[index]+ " ");
}
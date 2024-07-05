namespace _6._Walking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int goal = 10000;
            int sum = 0;
            int inputNumber = 0;
            int diff = 0;
            int stepToHomeNumber = 0;
            bool goalReached=false;
            while(sum<goal)
            {
                String input=Console.ReadLine();
                if(input=="Going home")
                {
                    String stepToHome=Console.ReadLine();
                    stepToHomeNumber=int.Parse(stepToHome);
                    sum += stepToHomeNumber; 
                    //Console.WriteLine($"{diff} more steps to reach goal.");
                    break;
                }
                else
                {
                    inputNumber = int.Parse(input);
                    sum = sum + inputNumber;
                }
                diff = goal - sum;
            }
            if (sum < goal)
            {
                Console.WriteLine($"{diff- stepToHomeNumber} more steps to reach goal.");
            }
            else
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{sum - goal} steps over the goal!");
            }
        }
    }
}
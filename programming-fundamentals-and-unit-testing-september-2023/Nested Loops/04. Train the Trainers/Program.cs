namespace _04._Train_the_Trainers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double juryMembers=int.Parse(Console.ReadLine());
            double totalGrade = 0;
            double presentationCount = 0;
            while (true)
            {
                String presentationName=Console.ReadLine();
                
                if (presentationName == "Finish")
                {
                    break;
                   
                }
                presentationCount++;
                double presentationGrade = 0;
                for (int i=1; i <= juryMembers; i++)
                {
                    double grade=double.Parse(Console.ReadLine());
                    presentationGrade += grade;
                    totalGrade +=grade; 
                }  
                Console.WriteLine($"{presentationName} - {(presentationGrade/juryMembers):f2}.");
            }
            Console.WriteLine($"Student's final assessment is {totalGrade / (presentationCount*juryMembers):f2}.");
        }
    }
}
namespace _4._Exam_Preparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPoorGrades=int.Parse(Console.ReadLine());
            //String problemName = Console.ReadLine();
            double countOfProblems = 0;
            int countOfGrades = 0;
            int sumOfGrades = 0;
            String lastProblem = "";
            bool isFailed=true;
            while(countOfGrades<numberOfPoorGrades)
            {
                String problemName = Console.ReadLine();
                if(problemName =="Enough")
                {
                    isFailed = false;
                    break;
                }
                int grade=int.Parse(Console.ReadLine());
                if(grade<=4)
                {
                    countOfGrades++;     
                }
                sumOfGrades += grade;
                countOfProblems++;
                lastProblem= problemName;
               // problemName =Console.ReadLine();
            }
            double avg = sumOfGrades / countOfProblems;
            if (isFailed)
            {
                Console.WriteLine($"You need a break, {countOfGrades} poor grades.");
            }
            else
            {
                Console.WriteLine($"Average score: {avg:f2}");
                Console.WriteLine($"Number of problems: {countOfProblems}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
        }
    }
}
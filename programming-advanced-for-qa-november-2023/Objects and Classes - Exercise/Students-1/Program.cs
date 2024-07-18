namespace Students_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfStudents=int.Parse(Console.ReadLine());
            List<Students> allStudents = new List<Students>();
            for(int i = 0; i < countOfStudents; i++)
            {
               string input=Console.ReadLine();
               string[] studentInfo =input.Split(" ");
               string firstName = studentInfo[0];
               string lastName = studentInfo[1];
               double grade = double.Parse(studentInfo[2]);
               
                Students currenStudent = new Students()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Grade = grade,
                };
                allStudents.Add(currenStudent);
            }
            foreach(Students student in allStudents.OrderByDescending(x => x.Grade))
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }
        }
    }
}

public class Students
{
    string firstName;
    string lastName;
    double grade;

    public string FirstName { get { return firstName; } set { firstName = value; } }
    public string LastName { get { return lastName; } set { lastName = value; } }
    public double Grade { get { return grade; } set { grade = value; } }

}

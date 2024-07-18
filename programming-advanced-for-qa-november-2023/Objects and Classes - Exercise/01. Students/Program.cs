namespace _01._Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfStudents = int.Parse(Console.ReadLine());
            List<Students> students = new List<Students>();
            for (int i = 0; i < countOfStudents; i++)
            {
                string[] studentData = Console.ReadLine().Split(" ");
                string firstName = studentData[0];
                string lastName = studentData[1];
                double grade = double.Parse(studentData[2]);

                Students currentStudent = new Students(firstName, lastName, grade);
                students.Add(currentStudent);
            }
            students = students.OrderByDescending(s => s.Grade).ToList();
            foreach (Students student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }

        }
    }

    public class Students
    {
        public Students()
        {

        }
        public Students(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }
    }
}
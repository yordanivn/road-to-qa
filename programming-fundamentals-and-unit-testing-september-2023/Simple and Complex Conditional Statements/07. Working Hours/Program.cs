namespace _07._Working_Hours
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hour=int.Parse(Console.ReadLine());
            String dayOfWeek=Console.ReadLine();
            /* if(hour>10 && hour<18)
             {
                 if (dayOfWeek == "Saturday" || dayOfWeek == "Sunday") Console.WriteLine("closed");
                 switch(dayOfWeek)
                 {
                     case "Monday":
                     case "Tuesday":
                     case "Wednesday":
                     case "Thursday":
                     case "Friday":
                         Console.WriteLine("open"); break;
                 }
             }
             else
             {
                 Console.WriteLine("closed");
             }
             */
            if (dayOfWeek == "Saturday" || dayOfWeek == "Sunday" || hour>18 || hour<10 || hour<=0) Console.WriteLine("closed");
            else if(hour >= 10 && hour <= 18)
            {
                switch (dayOfWeek)
                {
                    case "Monday":
                    case "Tuesday":
                    case "Wednesday":
                    case "Thursday":
                    case "Friday":
                        Console.WriteLine("open"); break;
                    case "Saturday":
                    case "Sunday":
                        Console.WriteLine("closed"); break;
                }
            }
        }
    }
}
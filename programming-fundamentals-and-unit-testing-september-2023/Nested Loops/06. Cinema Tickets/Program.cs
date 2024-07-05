namespace _06._Cinema_Tickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentTickets = 0;
            int standardTickets = 0;
            int kidTickets = 0;
            while(true)
            {
                String movieName=Console.ReadLine();
                if (movieName == "Finish") break;
                int soldTickets = 0;
                int cinemaSeats=int.Parse(Console.ReadLine());
                while(soldTickets<cinemaSeats)
                {   
                    String seatType=Console.ReadLine();
                    if (seatType == "End") break;
                    soldTickets++;
                    switch (seatType) 
                    {
                        case "student": studentTickets++; break;
                        case "standard": standardTickets++; break;
                        case "kid": kidTickets++; break;
                    }
                }
                Console.WriteLine($"{movieName} - {(100.00*soldTickets)/cinemaSeats:f2}% full.");
            }
            int totalTickets = studentTickets + standardTickets + kidTickets;
            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{100.00*studentTickets/totalTickets:f2}% student tickets.");
            Console.WriteLine($"{100.00 * standardTickets / totalTickets:f2}% standard tickets.");
            Console.WriteLine($"{100.00 * kidTickets / totalTickets:f2}% kids tickets.");
        }
    }
}
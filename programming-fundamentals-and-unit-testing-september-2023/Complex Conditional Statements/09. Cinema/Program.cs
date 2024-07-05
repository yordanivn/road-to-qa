namespace _09._Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String movieType=Console.ReadLine();
            int row=int.Parse(Console.ReadLine());
            int seatsPerRow=int.Parse(Console.ReadLine());
            int totalSeats=row*seatsPerRow;
            double totalPrice = 0;
            switch (movieType)
            {
                case "Premiere":
                    totalPrice = 12.00 * totalSeats;
                    break;
                case "Normal":
                    totalPrice = 7.50 * totalSeats;
                    break;
                case "Discount":
                    totalPrice = 5.00 * totalSeats;
                    break;
            }
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
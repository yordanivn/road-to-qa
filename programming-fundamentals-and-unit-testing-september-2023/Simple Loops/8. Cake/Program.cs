namespace _8._Cake
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            int length=int.Parse(Console.ReadLine());
            int width=int.Parse(Console.ReadLine());
            int numberPieces = length * width;
            int piecesLeft=numberPieces;
            int pieceNumber = 0;
            int diff = 0;

            while(piecesLeft >= 0)
                {
                String piece = Console.ReadLine();
                if (piece == "STOP")
                {
                    break;
                }
                else
                {
                    pieceNumber=int.Parse(piece);
                    piecesLeft = piecesLeft - pieceNumber;
                }
                if (piecesLeft < 0)
                {
                    break;
                    //Console.WriteLine($"No more cake left! You need {-piecesLeft} pieces more.");
                }
                //diff=numberPieces- pieceNumber;
            }
            if (piecesLeft <=0)
            {
                Console.WriteLine($"No more cake left! You need {-piecesLeft} pieces more.");
            }
            else
            {
                Console.WriteLine($"{piecesLeft} pieces are left.");
            }
;
        }
    }
}
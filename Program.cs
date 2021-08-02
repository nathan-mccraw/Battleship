using System;
using System.Linq;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[10, 10];

            for(int i=0; i < board.GetLength(0); i++)
            {
                for(int j=0; j < board.GetLength(1); j++)
                    board[i, j] = '-';
            }
            
            //game rules: grid 10x10, 8 guesses, ship size is 5
            //deliverables: randomly assign battleship, prompted to select a grid, user informed of all prior hit/miss results, ctach incorrect input values

            //make an array containing the board
            //make an array containing the results
            //make an array containing ship placement
            //output board --seperate function -> drawBoard
            //do while !guessesLeft or isShipSunk
            //output guesses left -- seperate function -> guessesLeft
            //prompt user -- seperate function -> shootmissile
            //draw new board -> draw board
            //output prior guesses array -> PriorGuesses
            //output guesses left -> guessesLeft
            //if run out of guesses then display ship position -> add ship to board, drawBoard

            // red "x" is hit, green "M" is a miss, green "O" is unhit ship

            DisplayHeader();
            DisplayBoard(board);
            Console.ReadKey();
        }

        public static void DisplayHeader()
        {

            char[] header1 = Enumerable.Repeat('*', 37).ToArray();
            
            Console.WriteLine();
            Console.Write(Indent(22));
            Console.Write(header1);
            Console.WriteLine();
            Console.WriteLine(Indent(22) + "*" + Indent(9) + "Battleship Game!" + Indent(10) + "*");
            Console.Write(Indent(22));
            Console.Write(header1);
            Console.WriteLine();
        }

        public static void DisplayBoard(char[,] board)
        {
            int[] colLabel = {1,2,3,4,5,6,7,8,9,10};
            char[] rowLabel = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };

            Console.Write(Indent(10));
            foreach(int i in colLabel)
                Console.Write("|  {0}  ", i);

            Console.WriteLine();
            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.Write(Indent(8));
                Console.Write(rowLabel[i] + " ");
                for (int j = 0; j < board.GetLength(1); j++)
                    Console.Write("|  {0}  ", board[i, j]);

                Console.WriteLine();
            };
        }

        public static string Indent(int spaces)
        {
            return "".PadLeft(spaces);
        }
    }
}
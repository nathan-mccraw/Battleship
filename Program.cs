using System;
using System.Linq;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerGuess = "";
            int turnsLeft = 8;
            char[,] board = new char[10, 10];

            InitializeBoard(board);
            
            do //game
            {
                Console.Clear();
                DisplayHeader();
                DisplayBoard(board);
                DisplayMessage(turnsLeft);
                playerGuess = Console.ReadLine();

                while (isInputInvalid(playerGuess))
                {
                    Console.WriteLine("The input you entered is not a location. Please enter a location in format ex: 'A1'.");
                    Console.Write("Enter the Alphanumeric location to shoot a missle: ");
                    playerGuess = Console.ReadLine();
                };

                turnsLeft--;

            } while (turnsLeft > 0);
        }

/*        public static void ShootMissile(string playerGuess)
        {
            switch (playerGuess[0])
            {
                case 65:

                default:
                    break;
            }
        }*/

        public static bool isInputInvalid(string playerGuess)
        {
            //65-74 for A-J, 97-106 for a-j, 48-57 for 0-9

            if (playerGuess.Length < 2)
                return true;
            
            if (playerGuess[0] < 65 || (playerGuess[0] > 74 && playerGuess[0] < 97) || (playerGuess[0] > 106))
                return true;

            if (playerGuess.Length > 2)
                if (playerGuess.Length == 3 && playerGuess[1] == 49 && playerGuess[2] == 48)
                    return false;
                else
                    return true;
            else if (playerGuess[1] < 49 || playerGuess[1] > 57)
                return true;
            else
                return false;
        }

        public static void DisplayHeader()
        {

            char[] header1 = Enumerable.Repeat('*', 37).ToArray();
            
            Console.WriteLine();
            Console.Write(Indent(22));
            Console.WriteLine(header1);
            Console.WriteLine();
            Console.WriteLine(Indent(22) + "*" + Indent(9) + "Battleship Game!" + Indent(10) + "*");
            Console.WriteLine();
            Console.Write(Indent(22));
            Console.WriteLine(header1);
            Console.WriteLine();
        }

        public static void InitializeBoard(char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                    board[i, j] = '-';
            }
        }

        public static void DisplayBoard(char[,] board)
        {
            int[] colLabel = {1,2,3,4,5,6,7,8,9,10};
            char[] rowLabel = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };

            Console.Write(Indent(10));
            foreach(int i in colLabel)
            {
                if (i > 9)
                    Console.Write("|  {0} ", i);
                else Console.Write("|  {0}  ", i);
            }
            Console.Write("|");

            Console.WriteLine();
            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.Write(Indent(8));
                Console.Write(rowLabel[i] + " ");
                for (int j = 0; j < board.GetLength(1); j++)
                    Console.Write("|  {0}  ", board[i, j]);

                Console.Write("|");
                Console.WriteLine();
            };
        }

        public static void DisplayMessage(int turnsLeft)
        {
            Console.WriteLine();
            Console.WriteLine(Indent(18) + "O - Location of a miss; X - Location of a hit");
            Console.WriteLine(Indent(21) + "You have {0} turns left to sink the ship!", turnsLeft);
            Console.WriteLine();
            Console.Write("Enter the Alphanumeric location to shoot a missle: ");
        }

        public static string Indent(int spaces)
        {
            return "".PadLeft(spaces);
        }
    }
}
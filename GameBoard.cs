using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip_CSharp
{
    class GameBoard
    {
        public char[,] board = new char[10, 10];
        public GameBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                    board[i, j] = '-';
            }
        }

        public void DisplayBoard()
        {
            int[] colLabel = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            char[] rowLabel = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };

            Console.Write(Indent(10));
            foreach (int i in colLabel)
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

        public void DisplayHeader()
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

        public void DisplayShootMessage(int turnsLeft)
        {
            Console.WriteLine();
            Console.WriteLine(Indent(18) + "O - Location of a miss; X - Location of a hit");
            Console.WriteLine(Indent(18) + "You have {0} turns remaining to sink the ship!", turnsLeft);
            Console.WriteLine();
            Console.Write("Enter the Alphanumeric location to shoot an artillery shell: ");
        }

        public static string Indent(int spaces)
        {
            return "".PadLeft(spaces);
        }
    }
}

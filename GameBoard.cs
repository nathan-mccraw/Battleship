using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BattleShip_CSharp
{
    internal class GameBoard
    {
        public char[,] board = new char[10, 10];
        public int[,] ship = new int[5, 2];

        public GameBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                    board[i, j] = '-';
            }

            PlaceShip();
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
            Console.WriteLine();
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

        public void DisplayShootMessage(int turnsLeft)
        {
            Console.WriteLine();
            Console.WriteLine(Indent(18) + "O - Location of a miss; X - Location of a hit");
            Console.WriteLine(Indent(18) + "You have {0} turns remaining to sink the ship!", turnsLeft);
            Console.WriteLine();
            Console.Write("Enter the Alphanumeric location to shoot an artillery shell: ");
        }

        public void DisplayWinMessage()
        {
            Console.Clear();
            DisplayHeader();
            DisplayBoard();
            Console.WriteLine(Indent(35) + "YOU WIN!!!");
        }

        public void DisplayLoseMessage()
        {
            Console.Clear();
            DisplayHeader();
            DisplayBoard();
            Console.WriteLine(Indent(22) + "You lost, better luck next time.");
        }

        public static void InvalidInputMessage()
        {
            Console.WriteLine("The input you entered is not a location. Please enter a location in format ex: 'A1'.");
            Console.Write("Enter the Alphanumeric location to shoot an artillery shell: ");
        }

        public static void LastShotMessage(string lastShot)
        {
            switch (lastShot)
            {
                case "RepeatShot":
                    Console.WriteLine(Indent(18) + "You repeated a shot, you lose a turn!");
                    Console.WriteLine();
                    break;

                case "ShotHit":
                    Console.WriteLine(Indent(18) + "Your shot hit the ship!! Keep it Up");
                    Console.WriteLine();
                    break;

                case "ShotMissed":
                    Console.WriteLine(Indent(18) + "You didn't hit anything, keep trying.");
                    Console.WriteLine();
                    break;

                default:
                    Console.WriteLine();
                    break;
            }
        }

        private void PlaceShip()
        {
            Random rand = new();
            int shipDirection = rand.Next(0, 1);
            ship[0, 0] = rand.Next(0, 9);
            ship[0, 1] = rand.Next(0, 9);

            if (shipDirection == 0)
            {
                if (ship[0, 0] > 4)
                {
                    for (int i = 1; i < 5; i++)
                    {
                        ship[i, 0] = ship[0, 0] - i;
                        ship[i, 1] = ship[0, 1];
                    }
                }
                else
                {
                    for (int i = 1; i < 5; i++)
                    {
                        ship[i, 0] = ship[0, 0] + i;
                        ship[i, 1] = ship[0, 1];
                    }
                }
            }
            else
            {
                if (ship[0, 1] > 4)
                {
                    for (int i = 1; i < 5; i++)
                    {
                        ship[i, 0] = ship[0, 0];
                        ship[i, 1] = ship[0, 1] - i;
                    }
                }
                else
                {
                    for (int i = 1; i < 5; i++)
                    {
                        ship[i, 0] = ship[0, 0];
                        ship[i, 1] = ship[0, 1] + i;
                    }
                }
            }
        }

        public void MarkHit(int[] location)
        {
            board[location[0], location[1]] = 'X';
        }

        public void MarkMiss(int[] location)
        {
            board[location[0], location[1]] = 'O';
        }

        public static string Indent(int spaces)
        {
            return "".PadLeft(spaces);
        }
    }
}
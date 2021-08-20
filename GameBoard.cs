using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static System.Console;

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

        public void DisplayStartMessage()
        {
            Clear();
            WriteLine("Welcome to Battleship console App!");
            WriteLine();
            WriteLine("Press any key to start the game");
            ReadKey();
        }

        public void StartGame(string lastShot, int turnsRemaining)
        {
            Clear();
            DisplayHeader();
            DisplayBoard();
            LastShotMessage(lastShot);
            DisplayShootMessage(turnsRemaining);
        }

        public bool IsInputInvalid(string playerGuess)
        {
            //Ascii values: 65-74 for A-J, 97-106 for a-j, 48-57 for 0-9
            bool isInvalid;

            if (playerGuess.Length < 2 || playerGuess[0] < 65 || (playerGuess[0] > 74 && playerGuess[0] < 97) || (playerGuess[0] > 106 || playerGuess[1] > 57))
                return isInvalid = true;

            if (playerGuess.Length > 2)
                if (playerGuess.Length == 3 && playerGuess[1] == 49 && playerGuess[2] == 48)
                    isInvalid = false;
                else
                    isInvalid = true;
            else if (playerGuess[1] < 49)
                isInvalid = true;
            else
                isInvalid = false;

            return isInvalid;
        }

        public void DisplayBoard()
        {
            int[] colLabel = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            char[] rowLabel = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };

            Write(Indent(10));
            foreach (int i in colLabel)
            {
                if (i > 9)
                    Write("|  {0} ", i);
                else Write("|  {0}  ", i);
            }
            Write("|");

            WriteLine();
            for (int i = 0; i < board.GetLength(0); i++)
            {
                Write(Indent(8));
                Write(rowLabel[i] + " ");
                for (int j = 0; j < board.GetLength(1); j++)
                    Write("|  {0}  ", board[i, j]);

                Write("|");
                WriteLine();
            };
            WriteLine();
        }

        public void DisplayHeader()
        {
            char[] header1 = Enumerable.Repeat('*', 37).ToArray();

            WriteLine();
            Write(Indent(22));
            WriteLine(header1);
            WriteLine();
            WriteLine(Indent(22) + "*" + Indent(9) + "Battleship Game!" + Indent(10) + "*");
            WriteLine();
            Write(Indent(22));
            WriteLine(header1);
            WriteLine();
        }

        public void DisplayShootMessage(int turnsLeft)
        {
            WriteLine();
            WriteLine(Indent(18) + "O - Location of a miss; X - Location of a hit");
            WriteLine(Indent(18) + "You have {0} turns remaining to sink the ship!", turnsLeft);
            WriteLine();
            Write("Enter the Alphanumeric location to shoot an artillery shell: ");
        }

        public void DisplayWinMessage()
        {
            Clear();
            DisplayHeader();
            DisplayBoard();
            WriteLine(Indent(35) + "YOU WIN!!!");
        }

        public void DisplayLoseMessage()
        {
            Clear();
            DisplayHeader();
            DisplayBoard();
            WriteLine(Indent(22) + "You lost, better luck next time.");
        }

        public void InvalidInputMessage()
        {
            WriteLine("The input you entered is not a location. Please enter a location in format ex: 'A1'.");
            Write("Enter the Alphanumeric location to shoot an artillery shell: ");
        }

        public void LastShotMessage(string lastShot)
        {
            switch (lastShot)
            {
                case "RepeatShot":
                    WriteLine(Indent(18) + "You repeated a shot, you lose a turn!");
                    WriteLine();
                    break;

                case "ShotHit":
                    WriteLine(Indent(18) + "Your shot hit the ship!! Keep it Up");
                    WriteLine();
                    break;

                case "ShotMissed":
                    WriteLine(Indent(18) + "You didn't hit anything, keep trying.");
                    WriteLine();
                    break;

                default:
                    WriteLine();
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
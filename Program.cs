using System;
using System.Linq;

namespace BattleShip_CSharp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            char menuSelection;

            do
            {
                string playerGuess = "";
                string lastShot = "";
                int turnsRemaining = 20;
                int hitShip = 0;
                GameBoard board = new GameBoard();

                Console.Clear();
                Console.WriteLine("Welcome to Battleship console App!");
                Console.WriteLine();
                Console.WriteLine("Press any key to start the game");
                Console.ReadKey();

                do
                {
                    Console.Clear();
                    board.DisplayHeader();
                    board.DisplayBoard();
                    board.LastShotMessage(lastShot);
                    board.DisplayShootMessage(turnsRemaining);
                    playerGuess = Console.ReadLine();

                    while (IsInputInvalid(playerGuess))
                    {
                        board.InvalidInputMessage();
                        playerGuess = Console.ReadLine();
                    };

                    PlayerShot shell = new PlayerShot(playerGuess);

                    if (shell.DidRepeatShot(board.board))
                    {
                        lastShot = "RepeatShot";
                    }
                    else
                    {
                        if (shell.DidShotHitShip(board.ship, board.board))
                        {
                            hitShip++;
                            lastShot = "ShotHit";
                            board.MarkHit(shell.location);
                        }
                        else
                        {
                            lastShot = "ShotMissed";
                            board.MarkMiss(shell.location);
                        }
                    }
                    turnsRemaining--;
                } while (turnsRemaining > 0 && hitShip != 5);

                if (hitShip == 5)
                {
                    board.DisplayWinMessage();
                }
                else
                {
                    board.DisplayLoseMessage();
                }

                Console.WriteLine();
                Console.WriteLine("Press any key to return to the main menu or enter 'q' to quit");
                menuSelection = (char)Console.Read();
            } while (menuSelection != 'q');
        }

        public static bool IsInputInvalid(string playerGuess)
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
    }
}
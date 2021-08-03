using System;
using System.Linq;

namespace BattleShip_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerGuess = "";
            int turnsRemaining = 8;
            GameBoard board = new(); //randomize ship location in 'board'
            
            //create game menu
            do
            {
                Console.Clear();
                board.DisplayHeader();
                board.DisplayBoard();
                board.DisplayShootMessage(turnsRemaining);
                playerGuess = Console.ReadLine();

                while (isInputInvalid(playerGuess))
                {
                    Console.WriteLine("The input you entered is not a location. Please enter a location in format ex: 'A1'.");
                    Console.Write("Enter the Alphanumeric location to shoot an artillery shell: ");
                    playerGuess = Console.ReadLine();
                };

                PlayerShot shell = new(playerGuess);
                // if(shell.didHitShip(board) then increment hit
                turnsRemaining--;

            } while (turnsRemaining > 0);
        }

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
    }
}
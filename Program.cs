using System;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
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

            // green "x" is hit, red "M" is a miss, green "O" is unhit ship

            Console.WriteLine("* Battleship Game! *");
            Console.ReadKey();
        }

        //public static void DisplayHeader()
        //{
        // string[] header1 = {'*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*'};
        // Console.WriteLine(header1);
        //Console.WriteLine("* Battleship Game! *");
        // Console.WriteLine(header1);
        //} 
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip_CSharp
{
    class PlayerShot
    {
        private int rowOfShot;
        private int columnOfShot;

        public PlayerShot(string playerGuess)
        {
            if (playerGuess.Length == 2)
                columnOfShot = (int)Char.GetNumericValue(playerGuess[1]) - 1;
            else
                columnOfShot = Int32.Parse(playerGuess[1..]) - 1;

            switch (playerGuess[0])
            {
                case 'a':
                    rowOfShot = 0;
                    break;
                case 'A':
                    rowOfShot = 0;
                    break;
                case 'b':
                    rowOfShot = 1;
                    break;
                case 'B':
                    rowOfShot = 1;
                    break;
                case 'c':
                    rowOfShot = 2;
                    break;
                case 'C':
                    rowOfShot = 2;
                    break;
                case 'd':
                    rowOfShot = 3;
                    break;
                case 'D':
                    rowOfShot = 3;
                    break;
                case 'e':
                    rowOfShot = 4;
                    break;
                case 'E':
                    rowOfShot = 4;
                    break;
                case 'f':
                    rowOfShot = 5;
                    break;
                case 'F':
                    rowOfShot = 5;
                    break;
                case 'g':
                    rowOfShot = 6;
                    break;
                case 'G':
                    rowOfShot = 6;
                    break;
                case 'h':
                    rowOfShot = 7;
                    break;
                case 'H':
                    rowOfShot = 7;
                    break;
                case 'i':
                    rowOfShot = 8;
                    break;
                case 'I':
                    rowOfShot = 8;
                    break;
                case 'J':
                    rowOfShot = 9;
                    break;
                default:
                    rowOfShot = 0;
                    break;
            }

            Console.WriteLine("The shot was at: {0}-{1}", rowOfShot, columnOfShot);
            Console.ReadKey();
        }

        public int RowOfShot { get; set; }
        public int ColumnOfShot { get; set; }
    }
}

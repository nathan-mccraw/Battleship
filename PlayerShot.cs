using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip_CSharp
{
    internal class PlayerShot
    {
        private int rowOfShot;
        private int columnOfShot;
        public int[] location = new int[2];

        public PlayerShot(string playerGuess)
        {
            if (playerGuess.Length == 2)
                columnOfShot = (int)Char.GetNumericValue(playerGuess[1]) - 1;
            else
                columnOfShot = Int32.Parse(playerGuess[1..]) - 1;

            switch (playerGuess[0])
            {
                case 'A':
                    rowOfShot = 0;
                    break;

                case 'B':
                    rowOfShot = 1;
                    break;

                case 'C':
                    rowOfShot = 2;
                    break;

                case 'D':
                    rowOfShot = 3;
                    break;

                case 'E':
                    rowOfShot = 4;
                    break;

                case 'F':
                    rowOfShot = 5;
                    break;

                case 'G':
                    rowOfShot = 6;
                    break;

                case 'H':
                    rowOfShot = 7;
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

            location[0] = rowOfShot;
            location[1] = columnOfShot;
        }

        public bool DidRepeatShot(char[,] board)
        {
            if (board[rowOfShot, columnOfShot] == '-')
                return false;
            else
                return true;
        }

        public bool DidShotHitShip(int[,] ship, char[,] board)
        {
            for (int i = 0; i < 5; i++)
            {
                if (rowOfShot == ship[i, 0] && columnOfShot == ship[i, 1])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
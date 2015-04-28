using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TicTacToe
{
    class TicTacToe
    {
        private string[,] table;
        public string sign;
        
        public TicTacToe(){
            table = new string[3,3];
            sign = "X";
        }

        public void Init()
        {
            int seq = 1;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    table[i,j] = seq.ToString();
                    seq++;
                }
            }
        }

        public void Render()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(" {0}", table[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void Reset()
        {
            Init();
            sign = "X";
        }

        private bool Mark(int row, int col)
        {
            bool alreadyPlaced = !Regex.IsMatch(table[row, col], "[1-9]");
            if (alreadyPlaced)
            {
                return false;
            }

            table[row, col] = sign;

            return true;
        }

        public bool PlaceMark(string position)
        {
            bool invalidPosition = !Regex.IsMatch(position, "[1-9]");
            if (invalidPosition) 
            {
                return false;
            }

            int number = int.Parse(position);

            switch (number)
            {
                case 1:
                    return Mark(0, 0);

                case 2:
                    return Mark(0, 1);

                case 3:
                    return Mark(0, 2);

                case 4:
                    return Mark(1, 0);

                case 5:
                    return Mark(1, 1);

                case 6:
                    return Mark(1, 2);

                case 7:
                    return Mark(2, 0);

                case 8:
                    return Mark(2, 1);

                case 9:
                    return Mark(2, 2);

                default:
                    return false;
            }


        }

        public void ChangePlayer()
        {
            if (sign.Equals("X"))
                sign = "O";
            else
                sign = "X";
        }

        public bool IsFull()
        {
            bool full = true;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    bool isNotPlaced = Regex.IsMatch(table[i, j], "[1-9]");
                    if (isNotPlaced)
                    {
                        return false;
                    }
                }
            }

            return full;
        }

        public bool FoundWinner()
        {
            return CheckWinRow() || CheckWinCol() || CheckWinCross();
        }

        private bool CheckWinRow()
        {
            for (int row = 0; row < 3; row++)
            {
                bool win = (table[row, 0] == table[row, 1]) && (table[row,1] == table[row, 2]);
                if (win)
                    return true;
            }

            return false;
        }

        private bool CheckWinCol()
        {
            for (int col = 0; col < 3; col++)
            {
                bool win = (table[0, col] == table[1, col]) && (table[1, col] == table[2, col]);
                if (win)
                    return true;
            }

            return false;
        }

        private bool CheckWinCross()
        {
            bool win1 = (table[0,0] == table[1,1]) && (table[1,1] == table[2,2]);
            bool win2 = (table[0,2] == table[1,1]) && (table[1,1] == table[2,0]);

            return win1 || win2;
        }
    }
}

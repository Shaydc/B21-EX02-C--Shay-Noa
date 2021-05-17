﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_EX02_Shay_207480567_Noa_315856351
{
    internal class UserInput
    {

        internal sbyte GetBoardSize(out bool io_UserWantsToQuit)
        {
            string userInput;
            sbyte boardSize;

            Console.WriteLine("Please enter the board size: (3-9)");
            userInput = Console.ReadLine();

            while (!isValidBoardSize(userInput, out boardSize))
            {
                if (isQuitInput(userInput))
                {
                    io_UserWantsToQuit = true;

                    return 0;
                }

                Console.WriteLine("Oops. invalid input. please type only numbers in range 3-9:");
                userInput = Console.ReadLine();
            }

            io_UserWantsToQuit = false;
            return boardSize;
        }

        private bool isValidBoardSize(string i_userInput, out sbyte i_boardSize)
        {
            bool isSbyte;
            isSbyte = sbyte.TryParse(i_userInput, out i_boardSize);
            Console.WriteLine(isSbyte);
            return (isSbyte && i_boardSize >= 3 && i_boardSize <= 9);
        }

        internal string GetUserName(out bool io_UserWantsToQuit, int i_numOfPlayer)
        {
            string userInput;

            Console.WriteLine("Enter player " + i_numOfPlayer + " name:");
            userInput = Console.ReadLine();

            if (isQuitInput(userInput))
            {
                io_UserWantsToQuit = true;

                return userInput;
            }

            io_UserWantsToQuit = false;

            return userInput;
        }

        internal bool GetIfOpponentIsComputer(out bool io_UserWantsToQuit)
        {
            string userInput;
            string msg;

            msg = string.Format(@"Who would you like to play against? (press the option number)
(1) The computer
(2) Another player");
            Console.WriteLine(msg);
            while (true)
            {
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        {
                            io_UserWantsToQuit = false;

                            return true;
                        }
                    case "2":
                        {
                            io_UserWantsToQuit = false;

                            return false;
                        }
                }

                if (isQuitInput(userInput))
                {
                    io_UserWantsToQuit = true;

                    return true; //default return value.
                }

                Console.WriteLine("Oops. invalid input. please chooce option 1 or 2:");
            }
        }

        public (sbyte, sbyte) GetUserMove(out bool io_UserWantsToQuit, List<Cell> i_FreeCells)
        {
            string userInputRow;
            string userInputCol;
            string msg;

            while (true)
            {
                Console.Write("choose a row: ");
                userInputRow = Console.ReadLine();
                if (isQuitInput(userInputRow))
                {
                    break;
                }

                Console.Write("choose a column: ");
                userInputCol = Console.ReadLine();
                if (isQuitInput(userInputRow))
                {
                    break;
                }

                if (isSbyte(userInputRow) && isSbyte(userInputRow))
                {
                    if (isAvailableCell(i_FreeCells, userInputRow, userInputCol))
                    {
                        io_UserWantsToQuit = false;

                        return (Convert.ToSByte(userInputRow), Convert.ToSByte(userInputCol));
                    }
                    else
                    {
                        Ex02.ConsoleUtils.Screen.Clear();
                        msg = string.Format(@"The cell you were trying to reach is not avilable.
It might be not empty \ the indexes are out of the scope of this board. please try again:");
                    }
                }
                else
                {
                    Ex02.ConsoleUtils.Screen.Clear();
                    Console.WriteLine("row/column index must be a number. Try again:");
                }
            }
            io_UserWantsToQuit = true;

            return (0, 0); //default return value;
        }

        private bool isQuitInput(string i_userInput)

        {
            return i_userInput == "Q";
        }

        // Check if sign is valid
        private bool isValidSign(string i_string)
        {
            return Enum.IsDefined(typeof(Cell.Sign), i_string);
        }

        private bool isSbyte(string i_string)
        {
            return sbyte.TryParse(i_string, out sbyte n);
        }

        private bool isAvailableCell(List<Cell> i_CellList, string i_Row, string i_Col)
        {
            return i_CellList.Exists(x => (x.Row == Convert.ToSByte(i_Row)) && (x.Col == Convert.ToSByte(i_Col)));
        }


    } 
}

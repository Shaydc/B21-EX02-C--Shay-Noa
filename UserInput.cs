using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_EX02_Shay_207480567_Noa_315856351
{
    internal class UserInput
    {
        internal sbyte GetBoardSize(ref bool io_UserWantsToQuit)
        {
            string userInput;
            sbyte boardSize;
            string msg;

            msg = string.Format(@"Please enter the board size: (3-9)");
            Console.WriteLine(msg);
            userInput = Console.ReadLine();

            while (!isValidBoardSize(userInput, out boardSize))
            {
                if (isQuitInput(userInput))
                {
                    io_UserWantsToQuit = true;

                    return 0;

                }

                msg = string.Format(@"Oops. invalid input. please type only numbers in range 3-9:");
                Console.WriteLine(msg);
                userInput = Console.ReadLine();
            }

            return boardSize;
        }

        private bool isValidBoardSize(string i_userInput, out sbyte i_boardSize)
        {
            bool isSbyte;
            isSbyte = sbyte.TryParse(i_userInput, out i_boardSize);
            return (isSbyte && i_boardSize >= 3 && i_boardSize <= 9);
        }

        internal string GetUserName(ref bool io_UserWantsToQuit, int i_numOfPlayer)
        {
            string userInput;

            Console.WriteLine("Enter player " + i_numOfPlayer + " name:");
            userInput = Console.ReadLine();
            if(isQuitInput(userInput))
            {
                io_UserWantsToQuit = true;

                return userInput;
            }

            return userInput;
        }

        internal bool GetIfOpponentIsComputer(ref bool io_UserWantsToQuit)
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
                            return true;
                        }
                    case "2":
                        {
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

        public (sbyte, sbyte) GetUserMove(ref bool io_UserWantsToQuit, List<Cell> i_FreeCells)
        {
            string userInputRow;
            string userInputCol;

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
                        return (Convert.ToSByte(userInputRow), Convert.ToSByte(userInputCol));
                    }
                    else
                    {
                        Console.WriteLine("Cell is already occupied/out of the board scope. try again:");
                        
                    }
                }
                else
                {
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
            foreach(Cell cell in i_CellList)
            {
                if(cell.Row == Convert.ToSByte(i_Row) && cell.Col == Convert.ToSByte(i_Col))
                {
                    return true;       
                }
            }
            
            return false;
        }


    } 
}

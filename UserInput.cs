using System;
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
            
            while(!isValidBoardSize(userInput, out boardSize))
            {
                if(isQuitInput(userInput))
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

        private bool isValidBoardSize (string i_userInput, out sbyte i_boardSize)
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

        internal bool GetOpponentType(out bool io_UserWantsToQuit)
        {
            string userInput;
            bool isComputerOpponent;
            string msg;

            msg = string.Format(@"Who would you like to play against? (press the option number)
(1) The computer
(2) Another player");
            Console.WriteLine(msg);
            userInput = Console.ReadLine();

            while (!IsValidOpponetChoice(userInput))
            {
                if (isQuitInput(userInput))
                {
                    io_UserWantsToQuit = true;

                    return true;
                }
                Console.WriteLine("Oops. invalid input. please chooce option 1 or 2:");
                userInput = Console.ReadLine();
            }

            if (userInput == "1")
            {
                isComputerOpponent = true;
            }
            else
            {
                isComputerOpponent = false;
            }

            io_UserWantsToQuit = false;

            return isComputerOpponent;
        }

        public (sbyte, sbyte) GetUserMove(out bool io_UserWantsToQuit, List<Cell> i_FreeCells)
        {
            sbyte row;
            sbyte column;
            string userInput;

            Console.WriteLine("Pick a row for you sign:");
            userInput = Console.ReadLine();
            
        } 

        private bool IsValidOpponetChoice(string i_userInput)
        {
            return true;
        }



        private bool isQuitInput(string i_userInput)

        {
            return i_userInput == "Q";
        }

        // Check if sign is valid
        private bool isValidSign(string i_input)
        {
            return Enum.IsDefined(typeof(Cell.Sign), i_input);
        }


        private bool isValidCell
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_EX02_Shay_207480567_Noa_315856351
{
    internal class UserInput
    {

        internal sbyte GetBoardSize(out bool io_gameOver)
        {
            string userInput;
            bool isSbyte;
            sbyte boardSize;
            
            Console.WriteLine("Please enter the board size: (5-9)");
            userInput = Console.ReadLine();
            isSbyte = sbyte.TryParse(userInput, out boardSize);
            while(!isSbyte || boardSize < 5 || boardSize > 9)
            {
                if (isQuitInput(userInput))
                {
                    io_gameOver = true;

                    return 0;
                }

                Console.WriteLine("Oops. invalid input. please type only numbers in range 5-9:");
                userInput = Console.ReadLine();
                isSbyte = sbyte.TryParse(userInput, out boardSize);
            }
            
            io_gameOver = false;
            
            return boardSize;
        }

        internal string GetUserName(out bool io_gameOver)
        {
            string userInput; 

            Console.WriteLine("What is your name?");
            userInput = Console.ReadLine();

            if (isQuitInput(userInput))
            {
                io_gameOver = true;

                return "";
            }

            io_gameOver = false;

            return userInput;
        }

        internal bool GetOpponentType(out bool io_gameOver)
        {
            string userInput;
            bool isComputerOpponent;
            string msg;

            msg = string.Format("Who would you like to play against? (press the option number)" +
                "(1) The computer" +
                "(2) Another player");
            Console.WriteLine(msg);
            userInput = Console.ReadLine();

            while (!IsValidOpponetChoice(userInput))
            {
                if (isQuitInput(userInput))
                {
                    io_gameOver = true;

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

            io_gameOver = false;
            return isComputerOpponent;
        }

        private bool IsValidOpponetChoice(string i_userInput)
        {
            return true;
        }

        // The method recives the user input and checks if the user tries to quit the game.
        // Returns true if he does, false otherwise.
        private bool isQuitInput(string i_userInput)
        {
            return i_userInput == "Q";
        }

        // Check if sign is valid
        private bool isValidSign(string i_input)
        {
            return Enum.IsDefined(typeof(Cell.Sign), i_input);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_EX02_Shay_207480567_Noa_315856351
{
    internal class TicTacToeConsole
    {
        private bool m_gameOver = false;
        private Player m_player1;
        private Player m_player2;
        private Board m_ConsoleBoard;

        public void startGame()
        {
            UserInput userInput = new UserInput(); //*****ask - should it be here? *********

            WelcomeMessage();

            // Get the board size:
            sbyte boardSize = userInput.GetBoardSize(out m_gameOver);
            this.m_ConsoleBoard = new Board(boardSize);
            if (!m_gameOver)
            {
                bool isComputerOpponent = userInput.GetOpponentType(out m_gameOver);
                string playerOneName = userInput.GetUserName(out m_gameOver);
            }
            Console.WriteLine("Game over!");
            Console.ReadLine();
            


        }

        private static void WelcomeMessage()
        {
            string msg;

            msg = string.Format(@"~ Welcome to Reverse TicTacToe! ~
You can press 'Q' at any point to quit the game!");

            Console.WriteLine(msg);
        }
        
    }
}

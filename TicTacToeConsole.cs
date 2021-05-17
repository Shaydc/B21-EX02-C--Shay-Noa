using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_EX02_Shay_207480567_Noa_315856351
{
    internal class TicTacToeConsole
    {
        private bool m_userWantsToQuit = false;
        private Player m_player1;
        private Player m_player2;
        private Board m_ConsoleBoard;

        public void playGame()
        {

            WelcomeMessage();

            // Get the board size:
            startBoard();
            if(!m_userWantsToQuit)
            {
                setUpPlayers();
                if(!m_userWantsToQuit)
                {
                    Game game = new Game(m_player1, m_player2, m_ConsoleBoard);
                    bool gameOver = game.GameOver;
                    while (!this.m_userWantsToQuit && !gameOver)
                    {
                        Player nowPlaying = game.CurrentTurn;
                        Console.WriteLine(nowPlaying.Name + " its your turn. place your sign in an empty cell:");

                        game.Board.Print();
                        
                    }
                }
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

        private void startBoard()
        {
            UserInput userInput = new UserInput();
            sbyte boardSize = userInput.GetBoardSize(out m_userWantsToQuit);

            this.m_ConsoleBoard = new Board(boardSize);
            ClearScreen();
        }

        private void setUpPlayers()
        {
            UserInput userInput = new UserInput();
            string playerOneName;
            string playerTwoName;
            bool isComputerOpponent;

            isComputerOpponent = userInput.GetOpponentType(out m_userWantsToQuit);
            if (m_userWantsToQuit)
            {
                return;
            }
            ClearScreen();

            playerOneName = userInput.GetUserName(out m_userWantsToQuit, 1);
            if (m_userWantsToQuit)
            {
                return;
            }
            ClearScreen();

            if (!isComputerOpponent)
            {
                playerTwoName = userInput.GetUserName(out m_userWantsToQuit, 2);
                if (m_userWantsToQuit)
                {
                    return;
                }
                ClearScreen();
            }
            else
            {
                playerTwoName = "Computer";
            }
            this.m_player1 = new Player(playerOneName, false);
            this.m_player2 = new Player(playerTwoName, isComputerOpponent);
        }

        private void ClearScreen()
        {
            Ex02.ConsoleUtils.Screen.Clear();
        }
    }
}

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
            setUpBoard();
            if(!m_userWantsToQuit)
            {
                setUpPlayers();
                if(!m_userWantsToQuit)
                {
                    Game game = new Game(m_player1, m_player2, m_ConsoleBoard);
                    bool gameOver = game.GameOver;

                    while (!gameOver)
                    {
                        playNextMove(ref game);
                        gameOver = game.GameOver;
                        if(m_userWantsToQuit)
                        {
                            break;
                        }
                    }
                }
            }

            Console.WriteLine("Game over!");
            Console.ReadLine();
        }

        // The method recieves a Game object, gets the next move input from the user
        // and runs the game with it to the next phase.
        public void playNextMove (ref Game i_game)
        {
            sbyte userInputRow;
            sbyte userInputCol;
            Player currentPlayer = i_game.CurrentTurn;
            UserInput userInput = new UserInput();

            if(currentPlayer.IsComputer)
            {
                i_game.MakeMove();
            }
            else{
                (userInputRow, userInputCol) = userInput.GetUserMove(ref m_userWantsToQuit, i_game.Board.FreeCells);
            }

            i_game.Board.PrintBoardToConsole();

        }

        // Print the welcome message at the begginig of the game:
        private static void WelcomeMessage()
        {
            string msg;

            msg = string.Format(@"~ Welcome to Reverse TicTacToe! ~
You can press 'Q' at any point to quit the game!");

            Console.WriteLine(msg);
        }

        // The method turns to userInput, recieves the board size from the 
        // user and sets up the board.
        private void setUpBoard()
        {
            UserInput userInput = new UserInput();
            sbyte boardSize = userInput.GetBoardSize(ref m_userWantsToQuit);

            this.m_ConsoleBoard = new Board(boardSize);
            ClearScreen();
        }

        // The method turns to userInput, gets the opponent type (computer/another user)
        // and the user name/s, and then creates two new Player Objects.
        private void setUpPlayers()
        {
            UserInput userInput = new UserInput();
            string playerOneName;
            string playerTwoName;
            bool isComputerOpponent;

            // Step 1: Checks who the player1 wants to play against. 
            isComputerOpponent = userInput.GetIfOpponentIsComputer(ref m_userWantsToQuit);
            if (m_userWantsToQuit)
            {
                return;
            }
            ClearScreen();

            // Step 2: Ask the name of Player1:
            playerOneName = userInput.GetUserName(ref m_userWantsToQuit, 1);
            if (m_userWantsToQuit)
            {
                return;
            }
            ClearScreen();

            // Step 3: if the opponent is not a computer, ask for his name too:
            if (!isComputerOpponent)
            {
                playerTwoName = userInput.GetUserName(ref m_userWantsToQuit, 2);
                if (m_userWantsToQuit)
                {
                    return;
                }
                ClearScreen();
            }
            else
            {
                playerTwoName = "Computer"; // If the opponent is a computer - default name.
            }

            // Step 4: set up the two Player objects:
            this.m_player1 = new Player(playerOneName, Cell.Sign.X, false);
            this.m_player2 = new Player(playerTwoName, Cell.Sign.O, isComputerOpponent);
        }

        // Method that clears the screen
        private void ClearScreen()
        {
            Ex02.ConsoleUtils.Screen.Clear();
        }
    }
}

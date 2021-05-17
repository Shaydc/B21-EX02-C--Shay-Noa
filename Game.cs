using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_EX02_Shay_207480567_Noa_315856351
{
    class Game
    {
        private Player m_Player1;
        private Player m_Player2;
        private Board m_Board;
        private Player m_CurrentTurn;
        private bool m_GameOver;

        public Game(Player i_player1, Player i_player2, Board i_board)
        {
            this.m_Player1 = i_player1;
            this.m_Player2 = i_player2;
            this.m_Board = i_board;
            this.m_CurrentTurn = i_player1;
            this.m_GameOver = false;
        }

        // The method recives a row and col indexes.
        // It makes a move for the current player, and put his sign in the cell in the chose index.
        // Then it check if the move got the game to be finished.
        public void MakeMove(sbyte i_row, sbyte i_col)
        {
           return;
        }

        // Computer Opponent method: makes a move for the computer
        public void MakeMove()
        {
            return;
        }

        // The methd recives a row and col indexes.
        // It makes a move for the current player, and put his sign in the cell in the chose index.
        // Then it check if the move got the game to be finished.
        public void switchCurrentPlayer()
        {
           return;
        }

        // The method return true if the board is full, false otherwise.
        public bool IsBoardFull()
        {
           return true;
        }

        //Default properties:
        public bool GameOver
        {
            get
            {
                return m_GameOver;
            }
        }
        public Player Player1
        {
            get
            {
                return m_Player1;
            }
            set
            {
                m_Player1 = value;
            }
        }

        public Player Player2
        {
            get
            {
                return m_Player2;
            }
            set
            {
                m_Player2 = value;
            }
        }

        public Board Board
        {
            get
            {
                return m_Board;
            }
            set
            {
                m_Board = value;
            }
        }

        public Player CurrentTurn
        {
            get
            {
                return m_CurrentTurn;
            }
            set
            {
                m_CurrentTurn = value;
            }
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_EX02_Shay_207480567_Noa_315856351
{
    class Game
    {
        // set variables 
        private Player m_Player1;
        private Player m_Player2;
        private Board m_Board;
        private Player m_CurrentTurn;
        private bool m_GameOver;

        // init game 
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
            this.Board.WriteToCell(i_col, i_row, this.CurrentTurn.Sign);
            this.checkIfGameOver();
        }

        // Computer Opponent method: makes a move for the computer
        public void MakeMove()
        {
            // temp random like noob
            Random rand = new Random();
            sbyte index = Convert.ToSByte(rand.Next(0, this.Board.FreeCells.Count));
            this.Board.WriteToCell(index, this.CurrentTurn.Sign);
            this.checkIfGameOver();
        }

        // The methd recives a row and col indexes.
        // It makes a move for the current player, and put his sign in the cell in the chose index.
        // Then it check if the move got the game to be finished.
        public void switchCurrentPlayer()
        {
            if (this.CurrentTurn == this.Player1)
            {
                this.CurrentTurn = this.Player2;
            }
            else {
                this.CurrentTurn = this.Player1;
            }
        }

        // The method return true if the board is full, false otherwise.
        private bool isBoardFull()
        {
            return this.Board.FreeCells.Count == 0;
        }

        // Check if game finish
        private void checkIfGameOver() {
            if (this.isBoardFull()) {
                this.m_GameOver = true;
            }

            // cross default check value true 
            bool incrossltf = true;
            bool incrossrtl = true;

            sbyte boardSize = this.m_Board.BoardSize;

            // create list of false (will use to check the row when goin over the cells)
            bool[] rowStrike = new bool[boardSize];
            for (int i = 0; i < boardSize; i++)
            {
                rowStrike[i] = true;
            }

            // check rows + cols strikes 
            for (sbyte row = 0; row < boardSize; row++) {
                bool colstrikes = true;
                for (sbyte col = 0; col < boardSize; col++)
                {
                    if (this.CurrentTurn.Sign != this.m_Board.TheBoard[row, col].CellSign){
                        colstrikes = false;
                        rowStrike[col] = false;
                    }

                    // check cross left to right
                    if (row == col && this.CurrentTurn.Sign != this.m_Board.TheBoard[row, col].CellSign) {
                        incrossrtl = false;
                    }

                    if (row + col == boardSize && this.CurrentTurn.Sign != this.m_Board.TheBoard[row, col].CellSign)
                    {
                        incrossltf = false;
                    }
                }
                if (colstrikes) {
                    this.m_GameOver = true;
                    break;
                }
            }
            if (rowStrike.Contains(true) || incrossltf || incrossrtl){
                this.m_GameOver = true;
            }
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

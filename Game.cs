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

        public Game(Player i_player1, Player i_player2, Board i_board)
        {
            this.m_Player1 = i_player1;
            this.m_Player2 = i_player2;
            this.m_Board = i_board;
            m_CurrentTurn = i_player1;
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

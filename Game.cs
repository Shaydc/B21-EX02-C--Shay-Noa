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
            m_CurrentTurn = this.m_Player1;
        }
    }
}

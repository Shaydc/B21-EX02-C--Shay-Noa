using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_EX02_Shay_207480567_Noa_315856351
{
    class Player
    {
        private string m_PlayerName;
        private bool m_IsComputer;
        private int m_Score;

        public Player(string i_PlayerName, bool i_IsComputer)
        {
            this.m_PlayerName = i_PlayerName;
            this.m_IsComputer = i_IsComputer;
            this.m_Score = 0;
        }

        public string PlayerName
        {
            get
            {
                return m_PlayerName;
            }
        }
        public bool IsComputer
        {
            get
            {
                return m_IsComputer;
            }
        }
        public int Score
        {
            get
            {
                return m_Score;
            }
        }
    }
}

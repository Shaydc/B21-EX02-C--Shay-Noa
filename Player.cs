using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_EX02_Shay_207480567_Noa_315856351
{
    class Player
    {
        // Set variables 
        private string m_Name;
        private bool m_IsComputer;
        private int m_Score;
        private Cell.Sign m_Sign;

        // init player 
        public Player(string i_PlayerName, Cell.Sign i_Sign, bool i_IsComputer)
        {
            this.m_Name = i_PlayerName;
            this.m_IsComputer = i_IsComputer;
            this.m_Sign = i_Sign;
            this.m_Score = 0;
        }

        // Get player name value
        public string Name
        {
            get
            {
                return m_Name;
            }
        }

        // Get player isComputer value
        public bool IsComputer
        {
            get
            {
                return m_IsComputer;
            }
        }

        // Get player score value
        public int Score
        {
            get
            {
                return m_Score;
            }
        }

        // Get player sing value
        public Cell.Sign Sign
        {
            get
            {
                return m_Sign;
            }
        }
    }
}

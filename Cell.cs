using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_EX02_Shay_207480567_Noa_315856351
{
    class Cell
    {
        // Set variables 
        public enum Sign
        {
            Empty = 0,
            X = 1,
            O = 2,
        }
        private sbyte m_Col;
        private sbyte m_Row;
        private Sign m_CellSign;

        // init cell 
        public Cell(sbyte i_row, sbyte i_col, Sign i_sign = Sign.Empty)
        {
            this.m_Col = i_col;
            this.m_Row = i_row;
            this.m_CellSign = i_sign;
        }


        // Get/Set cellsign value 
        public Sign CellSign
        {
            get
            {
                return this.m_CellSign;
            }
            set
            {
                this.m_CellSign = value;
            }
        }

        // Get col value 
        public sbyte Col
        {
            get
            {
                return this.m_Col;
            }
        }

        // Get row value 
        public sbyte Row
        {
            get
            {
                return this.m_Row;
            }
        }
    }
}

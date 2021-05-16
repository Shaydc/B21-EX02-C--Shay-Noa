using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_EX02_Shay_207480567_Noa_315856351
{
    class Board
    {
        private Cell[,] m_BoardImage;
        private sbyte m_BoardSize;
        private sbyte m_NumberOfTakenCells;
        private List<Cell> m_FreeCells;

        public Board(sbyte i_boardSize)
        {
            this.m_NumberOfTakenCells = 0;
            this.m_BoardSize = i_boardSize;
            this.m_BoardImage = new Cell[i_boardSize, i_boardSize];
        }

        private void initialBoard()
        {
            for(sbyte row = 0; row < this.m_BoardSize; row++)
            {
                for (sbyte col = 0; col < this.m_BoardSize; col++)
                {

                    Cell newcell = new Cell(row, col, Cell.Sign.E);
                }
            }
        } 
    }
}

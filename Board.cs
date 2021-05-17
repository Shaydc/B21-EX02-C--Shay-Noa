using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_EX02_Shay_207480567_Noa_315856351
{
    class Board
    {
        // Set variables 
        private Cell[,] m_Board; 
        private sbyte m_BoardSize; 
        private sbyte m_NumberOfTakenCells; 
        private List<Cell> m_FreeCells;

        // init borad 
        public Board(sbyte i_boardSize)
        {
            // set default parameters 
            this.m_NumberOfTakenCells = 0;
            this.m_BoardSize = i_boardSize;
            this.m_Board = new Cell[i_boardSize, i_boardSize];
            this.m_FreeCells = new List<Cell>();
            // create clean board 
            initialBoard();
        }


        // create each cell with location and default vaule
        private void initialBoard()
        {
            for (sbyte row = 0; row < this.m_BoardSize; row++)
            {
                for (sbyte col = 0; col < this.m_BoardSize; col++)
                {
                    this.m_Board[row, col] = new Cell(row, col, Cell.Sign.Empty);
                    this.m_FreeCells.Add(this.m_Board[row, col]);
                }
            }
        }

        // check if the borad is full 
        // if full return true else false 
        public bool IsBoardFull()
        {
            return this.m_FreeCells.Count == 0;
        }

        // borad printer 
        public void PrintBoardToConsole()
        {
            string seperator = "=====";
            string tab = "    ";
            StringBuilder seperationLine = new StringBuilder();
            StringBuilder index = new StringBuilder(tab);

            for (sbyte i = 1; i <= this.m_BoardSize; i++)
            {
                seperationLine.Append(seperator);
                index.AppendFormat("  {0}  ", i);
            }

            StringBuilder matrix = new StringBuilder();
            matrix.Append(index);
            matrix.AppendLine();
            int column = 0;
            for (sbyte row = 0; row < this.m_BoardSize; row++)
            {
                matrix.AppendFormat(" {0} |", column + 1);

                for (sbyte col = 0; col < this.m_BoardSize; col++)
                {
                    if(this.m_Board[row, col].CellSign is 0)
                    {
                        matrix.AppendFormat("{0}   ", " ");
                    } 
                    else
                    {
                        matrix.AppendFormat("  {0}  ", this.m_Board[row, col].CellSign);
                    }
                    matrix.Append("|");

                }
                column++;
                matrix.AppendLine();
                matrix.Append(tab);
                matrix.Append(seperationLine);
                matrix.AppendLine();
            }
            Console.WriteLine(matrix);
        }

        // Default properites:
        public List<Cell> FreeCells
        {
            get
            {
                return m_FreeCells;
            }
        }

        // Return the index of the free cell on freecells list 
        // if not found return -1
        private int getFreeCellIndex(sbyte m_Col, sbyte m_Rol) {
            // go over each free cell in the freecells list
            for(sbyte i=0; i<this.m_FreeCells.Count; i++) {
                
                // check if the function input refer to this cell
                if (this.m_FreeCells[i].Col == m_Col && this.m_FreeCells[i].Row == m_Rol) {
                    return i;
                }
            }

            // if cell not found after loop return -1
            return -1;
        }

        // Write the sing to the cell and remove the 
        // returning the cell by location + if the cell was empty
        public void WriteToCell(sbyte m_Col, sbyte m_Rol, Cell.Sign m_Sign){

            // getting the cell index on the free list
            int indexofcell = this.getFreeCellIndex(m_Rol,m_Col);

            // change the sing and remove it from the free 
            if (indexofcell != -1) {
                this.m_FreeCells[indexofcell].CellSign = m_Sign;
                this.m_FreeCells.RemoveAt(indexofcell);
            }
        }
    }
}

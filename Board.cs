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
            
            // Create clean board 
            initialBoard();
        }


        // create each cell with location and default vaule
        private void initialBoard()
        {
            for (sbyte row = 1; row <= this.m_BoardSize; row++)
            {
                for (sbyte col = 1; col <= this.m_BoardSize; col++)
                {
                    this.m_Board[row - 1, col - 1] = new Cell(row, col, Cell.Sign.Empty);
                    this.m_FreeCells.Add(this.m_Board[row - 1, col - 1]);
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
            string seperator = "====";

            string tab = "     ";
            StringBuilder seperationLine = new StringBuilder();
            StringBuilder index = new StringBuilder(tab);

            for (sbyte i = 1; i <= this.m_BoardSize; i++)
            {
                seperationLine.Append(seperator);
                index.AppendFormat("{0}   ", i);
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
                        matrix.AppendFormat(" {0} ", " ");
                    } 
                    else
                    {
                        matrix.AppendFormat(" {0} ", this.m_Board[row, col].CellSign);
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
        private int getFreeCellIndex(sbyte i_Row, sbyte i_Col) {
            // go over each free cell in the freecells list
            for(sbyte i=0; i<this.m_FreeCells.Count; i++) {
                
                // check if the function input refer to this cell
                if (this.m_FreeCells[i].Col == i_Col && this.m_FreeCells[i].Row == i_Row) {
                    return i;
                }
            }

            // if cell not found after loop return -1
            return -1;
        }

        // Write the sing to the cell and remove the cell from free list 
        // returning the cell by location + if the cell was empty
        public void WriteToCell(sbyte i_Col, sbyte i_Row, Cell.Sign i_Sign){

            // getting the cell index on the free list

            int indexofcell = this.getFreeCellIndex(i_Row,i_Col);

            // change the sing and remove it from the free 
            //********************* To Do - exception -1 *********************
            if (indexofcell != -1) {
                this.m_FreeCells[indexofcell].CellSign = i_Sign;
                this.m_FreeCells.RemoveAt(indexofcell);
            }
        }

        // Write to cell by the computer, counts on ranodm choose of cell in m_FreeCells
        public void WriteToCell(sbyte i_index, Cell.Sign i_Sign)
        {
            // getting the cell index on the free list
            sbyte indexofcell = i_index;

            // change the sing and remove it from the free 
            if (indexofcell != -1)
            {
                this.m_FreeCells[indexofcell].CellSign = i_Sign;
                this.m_FreeCells.RemoveAt(indexofcell);
            }
        }
        public sbyte BoardSize
        {
            get
            {
                return m_BoardSize;
            }
        }
        public Cell[,] TheBoard
        {
            get
            {
                return m_Board;
            }
        }
    }
}

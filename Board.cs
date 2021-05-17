using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_EX02_Shay_207480567_Noa_315856351
{
    class Board
    {
        private Cell[,] m_Board;
        private sbyte m_BoardSize;
        private sbyte m_NumberOfTakenCells;
        private List<Cell> m_FreeCells;

        public Board(sbyte i_boardSize)
        {
            this.m_NumberOfTakenCells = 0;
            this.m_BoardSize = i_boardSize;
            this.m_Board = new Cell[i_boardSize, i_boardSize];
            initialBoard();
        }

        private void initialBoard()
        {
            for (sbyte row = 0; row < this.m_BoardSize; row++)
            {
                for (sbyte col = 0; col < this.m_BoardSize; col++)
                {

                    this.m_Board[row, col] = new Cell(row, col, Cell.Sign.Empty);

                }
            }
        }

        public bool IsBoardFull()
        {
            return this.m_FreeCells.Count == 0;
        }

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

        public List<Cell> FreeCells
        {
            get
            {
                return m_FreeCells;
            }        
        }
    }
}

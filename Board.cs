using System.Collections.Generic;
using System;

namespace Assing3
{

    // This objeect use to store user paremeters to create shapes
    public class Board : AbsBoard
    {
        
        private Cell[,] cells = new Cell[3, 3];


        public Board(Mediator m)
        {
            mediator = m;
            cells[0, 0] = new Cell(0);
            cells[0, 1] = new Cell(0);
            cells[0, 2] = new Cell(0);
            cells[1, 0] = new Cell(0);
            cells[1, 1] = new Cell(0);
            cells[1, 2] = new Cell(0);
            cells[2, 0] = new Cell(0);
            cells[2, 1] = new Cell(0);
            cells[2, 2] = new Cell(0);
        }

        public override IBoard Clone()
        {
            Board clone = new Board(this.mediator);
            // clone.cells = (Cell[,]) this.cells.Clone();
            return clone;
        }


        public override bool IsVaildMove(int num)
        {
            return !GetSelectedCell(num).IsMarked();
        }

        public override int ResolveBoard(List<int> cellNum)
        {

            if (IsDone())
            {
                return GetWon();
            }
            if (cells[0, 0].GetValue() != 0 && cells[0, 0].GetValue() == cells[0, 1].GetValue() && cells[0, 0].GetValue() == cells[0, 2].GetValue())
            {
                wining.Add(0);
                wining.Add(1);
                wining.Add(2);
                SetWon(cells[0, 0].GetValue());
                return GetWon();
            }
            else if (cells[1, 0].GetValue() != 0 && cells[1, 0].GetValue() == cells[1, 1].GetValue() && cells[1, 0].GetValue() == cells[1, 2].GetValue())
            {
                wining.Add(3);
                wining.Add(4);
                wining.Add(5);
                SetWon(cells[1, 0].GetValue());
                return GetWon();
            }
            else if (cells[2, 0].GetValue() != 0 && cells[2, 0].GetValue() == cells[2, 1].GetValue() && cells[2, 0].GetValue() == cells[2, 2].GetValue())
            {
                wining.Add(6);
                wining.Add(7);
                wining.Add(8);
                SetWon(cells[2, 0].GetValue());
                return GetWon();
            }
            else if (cells[0, 0].GetValue() != 0 && cells[0, 0].GetValue() == cells[1, 0].GetValue() && cells[0, 0].GetValue() == cells[2, 0].GetValue())
            {
                wining.Add(0);
                wining.Add(3);
                wining.Add(6);
                SetWon(cells[0, 0].GetValue());
                return GetWon();
            }
            else if (cells[0, 1].GetValue() != 0 && cells[0, 1].GetValue() == cells[1, 1].GetValue() && cells[0, 1].GetValue() == cells[2, 1].GetValue())
            {
                wining.Add(1);
                wining.Add(4);
                wining.Add(7);
                SetWon(cells[0, 1].GetValue());
                return GetWon();
            }
            else if (cells[0, 2].GetValue() != 0 && cells[0, 2].GetValue() == cells[1, 2].GetValue() && cells[0, 2].GetValue() == cells[2, 2].GetValue())
            {
                wining.Add(2);
                wining.Add(5);
                wining.Add(8);
                SetWon(cells[0, 2].GetValue());
                return GetWon();
            }
            else if (cells[0, 0].GetValue() != 0 && cells[0, 0].GetValue() == cells[1, 1].GetValue() && cells[0, 0].GetValue() == cells[2, 2].GetValue())
            {
                wining.Add(0);
                wining.Add(4);
                wining.Add(8);
                SetWon(cells[0, 0].GetValue());
                return GetWon();
            }
            else if (cells[0, 2].GetValue() != 0 && cells[0, 2].GetValue() == cells[1, 1].GetValue() && cells[0, 2].GetValue() == cells[2, 0].GetValue())
            {
                wining.Add(2);
                wining.Add(4);
                wining.Add(6);
                SetWon(cells[0, 2].GetValue());
                return GetWon();
            }



            return 0;
        }

        public override bool MarkCell(int player, List<int> cellNum)
        {
            int f = cellNum[0];
            if (IsVaildMove(f))
            {
                return GetSelectedCell(f).Mark(player);
            }
            return false;
        }

        public override bool IsWiningMove(int player, List<int> cellNum)
        {
            if (player == won)
            {
                return wining.Contains(cellNum[0]);
            }
            return false;
        }



        private Cell GetSelectedCell(int num)
        {

            switch (num)
            {

                case 0:
                    return cells[0, 0];
                case 1:
                    return cells[0, 1];
                case 2:
                    return cells[0, 2];
                case 3:
                    return cells[1, 0];
                case 4:
                    return cells[1, 1];
                case 5:
                    return cells[1, 2];
                case 6:
                    return cells[2, 0];
                case 7:
                    return cells[2, 1];
                case 8:
                    return cells[2, 2];
                default:
                    return cells[0, 0];

            }
        }


    }

}
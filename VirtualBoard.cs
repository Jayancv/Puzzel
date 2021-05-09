using System.Collections.Generic;
using System;

namespace Assing3
{

    // This objeect use to store user paremeters to create shapes
    public class VirtualBoard : IBoard
    {
        private Mediator mediator;
        private int level;
        private bool done;
        private int won;
        List<int> wings = new List<int>();


        List<IBoard> boards = new List<IBoard>();
        List<int> wining = new List<int>();


        public VirtualBoard(Mediator m)
        {
            mediator = m;
            //   boards[0,0] = new Board();
            //   boards[0,1] = new Board();
            //   boards[0,2] = new Board();
            //   boards[1,0] = new Board();
            //   boards[1,1] = new Board();
            //   boards[1,2] = new Board();
            //   boards[2,0] = new Board();
            //   boards[2,1] = new Board();
            //   boards[2,2] = new Board();               
        }

        public bool AddBoard(int x, int y, IBoard board)
        {
            boards.Add(board);
            return true;
        }


        public IBoard Clone()
        {
            VirtualBoard clone = (VirtualBoard)this.MemberwiseClone();
            clone.boards = this.boards.ConvertAll(boo => boo.Clone());
            return clone;
        }


        public void SetWon(int y0)
        {
            //done = true;
            won = y0;
            mediator.Update(this.level, y0);

        }
        public int GetWon()
        {
            return won;
        }
        public void SetLevel(int x0)
        {
            level = x0;
        }
        public int GetLevel()
        {
            return level;
        }

        public bool IsDone()
        {
            return done;
        }

        public List<int> GetWinings()
        {
            return wining;
        }
        public bool IsVaildMove(int num)
        {
            return !GetSelectedBoard(num).IsDone();
        }

        public int ResolveBoard(List<int> cellNum)
        {
            int f = cellNum[0];
            List<int> v = new List<int>(cellNum);
            v.RemoveAt(0);
            int s = GetSelectedBoard(f).ResolveBoard(v);
            if (s == 0)
            {
                return 0;
            }
            return ResolveBoard();
        }

        public int ResolveBoard()
        {

            if (IsDone())
            {
                return GetWon();
            }
            if (boards[0].GetWon() != 0 && boards[0].GetWon() == boards[1].GetWon() && boards[0].GetWon() == boards[2].GetWon())
            {
                wining.Add(0);
                wining.Add(1);
                wining.Add(2);
                SetWon(boards[0].GetWon());
                return GetWon();
            }
            else if (boards[3].GetWon() != 0 && boards[3].GetWon() == boards[4].GetWon() && boards[3].GetWon() == boards[5].GetWon())
            {
                wining.Add(3);
                wining.Add(4);
                wining.Add(5);
                SetWon(boards[3].GetWon());
                return GetWon();
            }
            else if (boards[6].GetWon() != 0 && boards[6].GetWon() == boards[7].GetWon() && boards[6].GetWon() == boards[8].GetWon())
            {
                wining.Add(6);
                wining.Add(7);
                wining.Add(8);
                SetWon(boards[6].GetWon());
                return GetWon();
            }
            else if (boards[0].GetWon() != 0 && boards[0].GetWon() == boards[3].GetWon() && boards[0].GetWon() == boards[6].GetWon())
            {
                wining.Add(0);
                wining.Add(3);
                wining.Add(6);
                SetWon(boards[0].GetWon());
                return GetWon();
            }
            else if (boards[1].GetWon() != 0 && boards[1].GetWon() == boards[4].GetWon() && boards[1].GetWon() == boards[7].GetWon())
            {
                wining.Add(1);
                wining.Add(4);
                wining.Add(7);
                SetWon(boards[1].GetWon());
                return GetWon();
            }
            else if (boards[2].GetWon() != 0 && boards[2].GetWon() == boards[5].GetWon() && boards[2].GetWon() == boards[8].GetWon())
            {
                wining.Add(2);
                wining.Add(5);
                wining.Add(8);
                SetWon(boards[2].GetWon());
                return GetWon();
            }
            else if (boards[0].GetWon() != 0 && boards[0].GetWon() == boards[4].GetWon() && boards[0].GetWon() == boards[8].GetWon())
            {
                wining.Add(0);
                wining.Add(4);
                wining.Add(8);
                SetWon(boards[0].GetWon());
                return GetWon();
            }
            else if (boards[2].GetWon() != 0 && boards[2].GetWon() == boards[4].GetWon() && boards[2].GetWon() == boards[6].GetWon())
            {
                wining.Add(2);
                wining.Add(4);
                wining.Add(6);
                SetWon(boards[2].GetWon());
                return GetWon();
            }

            return 0;
        }

        public bool MarkCell(int player, List<int> cellNum)
        {
            int f = cellNum[0];
            List<int> v = new List<int>(cellNum);
            if (IsVaildMove(f))
            {
                v.RemoveAt(0);
                return GetSelectedBoard(f).MarkCell(player, v);
            }
            return false;
        }


        public bool IsWiningMove(int player, List<int> cellNum)
        {
            int f = cellNum[0];
            List<int> v = new List<int>(cellNum);
            v.RemoveAt(0);
            return GetSelectedBoard(f).IsWiningMove(player, v);
            
        }


        public IBoard GetSelectedBoard(int num)
        {

            switch (num)
            {

                case 0:
                    return boards[0];
                case 1:
                    return boards[1];
                case 2:
                    return boards[2];
                case 3:
                    return boards[3];
                case 4:
                    return boards[4];
                case 5:
                    return boards[5];
                case 6:
                    return boards[6];
                case 7:
                    return boards[7];
                case 8:
                    return boards[8];
                default:
                    return boards[0];

            }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

}
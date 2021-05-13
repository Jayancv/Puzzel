using System.Collections.Generic;
using System;

namespace Assing3
{

    // Abstract board implements common details for all boards
    public abstract class AbsBoard : IBoard
    {
        protected int level;
        protected Mediator mediator;
        protected bool done;
        protected int won;
        protected List<int> wining = new List<int>();

        public abstract bool IsVaildMove(int num);

        public abstract int ResolveBoard(List<int> cellNum);

        public abstract bool MarkCell(int player, List<int> cellNum);

        public abstract IBoard Clone();

        public abstract bool IsWiningMove(int player, List<int> cellNum);


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

        public bool IsDone()
        {
            return done;
        }

        public List<int> GetWinings()
        {
            return wining;
        }

        public IBoard GetColned(VirtualBoard vBoard, IBoard board)
        {

            vBoard.AddBoard(0, 0, board.Clone());
            vBoard.AddBoard(0, 1, board.Clone());
            vBoard.AddBoard(0, 2, board.Clone());
            vBoard.AddBoard(1, 0, board.Clone());
            vBoard.AddBoard(1, 1, board.Clone());
            vBoard.AddBoard(1, 2, board.Clone());
            vBoard.AddBoard(2, 0, board.Clone());
            vBoard.AddBoard(2, 1, board.Clone());
            vBoard.AddBoard(2, 2, board.Clone());

            return vBoard;
        }

        public void SetLevel(int x0)
        {
            level = x0;
        }
        public int GetLevel()
        {
            return level;
        }
    }
}